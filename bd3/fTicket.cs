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

            //show passengers
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string query = "SELECT [email], [name], [surname] FROM Passenger";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                comboBox1.Items.Add(da.GetValue(0).ToString() + da.GetValue(1).ToString() + da.GetValue(2).ToString());
                comboBox3.Items.Add(da.GetValue(0).ToString() + da.GetValue(1).ToString() + da.GetValue(2).ToString());
            }
            con.Close();

            //show flights
            SqlConnection con2 = new SqlConnection(str);
            con2.Open();

            string query2 = "SELECT [flightNumber], [departureTime], [arrivalTime], [airportFrom], [airportTo] FROM Flight";

            SqlCommand cmd2 = new SqlCommand(query2, con2);
            SqlDataReader da2 = cmd2.ExecuteReader();
            while (da2.Read())
            {
                comboBox2.Items.Add(da2.GetValue(0).ToString()+"  "+da2.GetValue(1).ToString()+da2.GetValue(2).ToString()+da2.GetValue(3).ToString()+da2.GetValue(4).ToString());
                comboBox4.Items.Add(da2.GetValue(0).ToString() + "  " + da2.GetValue(1).ToString() + da2.GetValue(2).ToString() + da2.GetValue(3).ToString() + da2.GetValue(4).ToString());
            }
            con.Close();

        }
        public void showData()
        {
            try
            {
                string query = "SELECT * FROM Ticket INNER JOIN Passenger ON Passenger.id = passengerId INNER JOIN Flight ON Flight.id = flightId;";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[4].HeaderText = "email";
                dataGridView1.Columns[5].HeaderText = "Имя";
                dataGridView1.Columns[6].HeaderText = "Фамилия";
                dataGridView1.Columns[8].HeaderText = "Номер рейса";
                dataGridView1.Columns[9].HeaderText = "Время взлета";
                dataGridView1.Columns[10].HeaderText = "Время посадки";
                dataGridView1.Columns[12].HeaderText = "Аэропорт взлета";
                dataGridView1.Columns[13].HeaderText = "Аэропорт посадки";

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
            
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string passengerId = (comboBox1.SelectedIndex + 1).ToString();
            string flightId = (comboBox2.SelectedIndex + 1).ToString();


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
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить строчку", "Удаление", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                deleteRow(id);
            }
            showData();
        }

        public void editRow(string id, string passengerId, string flightId)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string query = $"UPDATE [dbo].[Ticket] SET [passengerId] = {passengerId}, [flightId] = '{flightId}' WHERE id='{id}';";

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

        private void bEdit_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            
            editRow(id, (comboBox3.SelectedIndex+1).ToString(), (comboBox4.SelectedIndex+1).ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                //id = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[0].Value.ToString();
                comboBox3.Text = row.Cells[4].Value.ToString() + row.Cells[5].Value.ToString() + row.Cells[6].Value.ToString(); 
                comboBox4.Text = " " + row.Cells[8].Value.ToString()+" "  + row.Cells[9].Value.ToString()+" "+ row.Cells[10].Value.ToString() +" "+ row.Cells[11].Value.ToString() + " "+row.Cells[12].Value.ToString()+" "+row.Cells[13].Value.ToString();
                /*string query = $"SELECT TOP 1 email, name, surname FROM [dbo].[Passenger] WHERE id={row.Cells[0].Value};";

                SqlConnection con = new SqlConnection(str);
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                var da = cmd.ExecuteReader();

                while (da.Read())
                {
                    comboBox3.Text = da.GetValue(0).ToString()+" "+da.GetValue(1).ToString()+" " + da.GetValue(2).ToString();
                }*/


                // con.Close();

                //comboBox3.SelectedItem = dt.ToString();
                // con.Close();
                // comboBox3.SelectedIndex = 1;
                // comboBox4.SelectedIndex = "cdsc";
            }
        }
    }
}
