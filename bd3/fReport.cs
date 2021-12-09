using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace bd3
{
    public partial class fReport : Form
    {
        string str = "server=DESKTOP-T5OA1IV\\SQLEXPRESS;database=myAirline; Integrated Security=True;";
        string tableP = "Passenger";
        public fReport()
        {
            InitializeComponent();
            showDataPassenger();
        }

        /*Dictionary<string, string> cocolumns = new Dictionary<string, string>
        {
            {"email", "email"},
            {"Имя", "name"},
            {"Фамилия", "surname"}
        };*/

        
        public void ConvertColumn(string tmp1)
        {
            tmp1 = tmp.Text;
            /*foreach (var pair in cocolumns)
            {*/
                //Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                if (tmp1 == "Имя")
                {
                   tmp.Text = "name";
                }
                else if (tmp1 == "Фамилия")
                {
                   tmp.Text = "surname";
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (agr.SelectedItem.ToString() == "МИН")
            {
                ConvertColumn(tmp.Text);
                min(tableP, tmp.Text);
            }
            else if (agr.SelectedItem.ToString() == "МАКС")
            {
                ConvertColumn(tmp.Text);
                max(tableP, tmp.Text);
            }
            else if(agr.SelectedItem.ToString() == "СРЗНАЧ")
            {
                ConvertColumn(tmp.Text);
                medium(tableP, tmp.Text);
            }
            else if (agr.SelectedItem.ToString() == "СУММ")
            {
                ConvertColumn(tmp.Text);
                sum(tableP, tmp.Text);
            }
            else if (agr.SelectedItem.ToString() == "КОЛ-ВО")
            {
                ConvertColumn(tmp.Text);
                count(tableP, tmp.Text);
            }

        }

        public void min(string table, string column)
        {
            try
            {
                string query = $"SELECT min({column}) FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                dataGridView1.BackgroundColor = Color.White;
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void max(string table, string column)
        {
            try
            {
                string query =  $"SELECT max({column}) FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                dataGridView1.BackgroundColor = Color.White;
                
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void sum(string table, string column)
        {
            try
            {
                string query = $"SELECT sum({column}) FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                dataGridView1.BackgroundColor = Color.White;

            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void count(string table, string column)
        {
            try
            {
                string query = $"SELECT count({column}) FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                dataGridView1.BackgroundColor = Color.White;

            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void medium(string table, string column)
        {
            try
            {
                string query = $"SELECT avg({column}) FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                dataGridView1.BackgroundColor = Color.White;

            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void showDataAirplane()
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
                
                con.Close();
                dataGridView1.BackgroundColor = Color.White;
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void showDataTicket()
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
                con.Close();
                dataGridView1.BackgroundColor = Color.White;
                
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void showDataPassenger()
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
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void showDataFlight()
        {
            try
            {
                string query = "SELECT * FROM Flight Left JOIN Airplane ON Airplane.id = airplaneId;";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                
                con.Close();
                dataGridView1.BackgroundColor = Color.White;
                
            }

            catch (Exception es)

            {
                MessageBox.Show(es.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tmp.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showDataPassenger();
        }
    }
}