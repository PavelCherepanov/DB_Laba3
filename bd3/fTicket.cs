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
    public partial class fTicket : Form
    {
        string str = "server=DESKTOP-T5OA1IV\\SQLEXPRESS;database=myAirline; Integrated Security=True;";
        public fTicket()
        {
            InitializeComponent();
            showData();
        }
        public void showData()
        {
            try
            {
                string query = "SELECT * FROM Ticket";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "id пассажира";
                dataGridView1.Columns[2].HeaderText = "id рейса";
                
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

            string query = $"DELETE FROM [dbo].[Ticket] WHERE id={id};";

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
            string passengerId = tbIdP.Text;
            string flightId = tbIdF.Text;
            

            string query = $"INSERT INTO [dbo].[Ticket] ([passengerId], [flightId]) VALUES " +
                $"('{passengerId}', '{flightId}');";


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
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить строчку с id ={id}", "Удаление", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                deleteRow(id);
            }
        }
    }
}
