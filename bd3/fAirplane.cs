using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bd3
{
    public partial class fAirplane : Form
    {
        string str = "server=DESKTOP-T5OA1IV\\SQLEXPRESS;database=myAirline; Integrated Security=True;";
        public fAirplane()
        {
            InitializeComponent();
            showData();
           // textBox4.Text
        }
        public void showData()
        {
            try
            {
                string query = "SELECT * FROM Airplane";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Кол-во пассажиров";
                dataGridView1.Columns[2].HeaderText = "Производитель";
                con.Close();
                dataGridView1.BackgroundColor = Color.White;
                //dataGridView1.RowHeadersVisible = false;
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void editRow(string id, int maxNumberOfPassengers, string manufacturer)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string query = $"UPDATE [dbo].[Airplane] SET [maxNumberOfPassengers] = {maxNumberOfPassengers}, [manufacturer] = '{manufacturer}' WHERE id='{id}';";

            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            con.Close();
            showData();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string maxNumberOfPassengers = tbPassenger.Text;
            string manufacturer = tbManufacturer.Text;

            string query = $"INSERT INTO [dbo].[Airplane] ([maxNumberOfPassengers], [manufacturer]) VALUES " +
                $"('{maxNumberOfPassengers}', '{manufacturer}');";


            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            con.Close();
            showData();
        }
        public void deleteRow(string id)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string query = $"DELETE FROM [dbo].[Airplane] WHERE id={id};";

            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            con.Close();
            showData();
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id="";
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id = row.Cells[0].Value.ToString();
            }
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить строчку с id ={id}", "Удаление", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                deleteRow(id);
            }
            
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            string id = textBox3.Text;
            string maxNumberOfPassengers = textBox2.Text;
            string manufacturer = textBox1.Text;

            editRow(id, Convert.ToInt32(maxNumberOfPassengers), manufacturer);

            showData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string id = "";
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                //id = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
