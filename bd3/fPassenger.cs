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
    public partial class fPassenger : Form
    {
        string str = "server=DESKTOP-T5OA1IV\\SQLEXPRESS;database=myAirline; Integrated Security=True;";
        public fPassenger()
        {
            InitializeComponent();
            showData();
        }
        public void showData()
        {
            try
            {
                string query = "SELECT * FROM Passenger";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "email";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Фамилия";
                con.Close();
                dataGridView1.BackgroundColor = Color.White;
                //dataGridView1.RowHeadersVisible = false;
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        public void deleteRow(string id)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            //string id = textBoxId.Text;

            string query = $"DELETE FROM [dbo].[Passenger] WHERE id={id};";

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

        public void editRow(string id, string email, string name, string surname)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string query = $"UPDATE [dbo].[Passenger] SET [email]='{email}', [name]='{name}', [surname]='{surname}' WHERE id={id}";

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
            string email = tbEmail.Text;
            string name = tbName.Text;
            string surname = tbSurname.Text;

            string query = $"INSERT INTO [dbo].[Passenger] ([email], [name], [surname]) VALUES " +
                $"('{email}', '{name}', '{surname}');";


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
            string id = "";
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id = row.Cells[0].Value.ToString();
            }
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить строчку ", "Удаление", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                deleteRow(id);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string id = "";
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                //id = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox1.Text = row.Cells[3].Value.ToString();
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;
            string email = textBox3.Text;
            string name = textBox2.Text;
            string surname = textBox1.Text;

            editRow(id, email, name, surname);
 
            showData();
        }
    }
}
