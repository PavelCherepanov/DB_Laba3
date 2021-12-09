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
    public partial class frFlight : Form
    {
        public frFlight()
        {
            InitializeComponent();
            showDataFlight();
        }
        string str = "server=DESKTOP-T5OA1IV\\SQLEXPRESS;database=myAirline; Integrated Security=True;";
        string table = "Flight";

        public void ConvertColumn(string tmp1)
        {
            tmp1 = tmp.Text;

            if (tmp1 == "Номер рейса")
            {
                tmp.Text = "flightNumber";
            }
            else if (tmp1 == "Время взлета")
            {
                tmp.Text = "departureTime";
            }
            else if (tmp1 == "Время посадки")
            {
                tmp.Text = "arrivalTime";
            }    
            else if (tmp1 == "Аэропорт взлета")
            {
                tmp.Text = "airportFrom";
            }
            else if (tmp1 == "Аэропорт посадки")
            {
                tmp.Text = "airportTo";
            }
            else if (tmp1 == "Кол-во пассажиров")
            {
                tmp.Text = "maxNumberOfPassenger";
            }
            else if (tmp1 == "Производитель")
            {
                tmp.Text = "manufacturer";
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
                dataGridView1.Columns[1].HeaderText = "Номер рейса";
                dataGridView1.Columns[2].HeaderText = "Время взлета";
                dataGridView1.Columns[3].HeaderText = "Время посадки";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "Аэропорт взлета";
                dataGridView1.Columns[6].HeaderText = "Аэропорт посадки";
                //dataGridView1.Columns[7].HeaderText = "id самолета";
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].HeaderText = "Кол-во пассажиров";
                dataGridView1.Columns[9].HeaderText = "Производитель";
                con.Close();
                dataGridView1.BackgroundColor = Color.White;

            }

            catch (Exception es)

            {
                MessageBox.Show(es.Message);
            }
        }
        public void min(string table, string column)
        {
            try
            {
                string query = $"SELECT min({column}) as min FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                //dataGridView1.Columns[0].HeaderText = "Результат";
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
                string query = $"SELECT max({column}) as max FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
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
                string query = $"SELECT sum({column}) as sum FROM {table}";

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
                string query = $"SELECT count({column}) as count FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
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
                string query = $"SELECT avg({column}) as medium FROM {table}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                con.Close();
                dataGridView1.BackgroundColor = Color.White;

            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (agr.SelectedItem.ToString() == "МИН")
            {
                ConvertColumn(tmp.Text);
                min(table, tmp.Text);
            }
            else if (agr.SelectedItem.ToString() == "МАКС")
            {
                ConvertColumn(tmp.Text);
                max(table, tmp.Text);
            }
            else if (agr.SelectedItem.ToString() == "СРЗНАЧ")
            {
                ConvertColumn(tmp.Text);
                medium(table, tmp.Text);
            }
            else if (agr.SelectedItem.ToString() == "СУММ")
            {
                ConvertColumn(tmp.Text);
                sum(table, tmp.Text);
            }
            else if (agr.SelectedItem.ToString() == "КОЛ-ВО")
            {
                ConvertColumn(tmp.Text);
                count(table, tmp.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tmp.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showDataFlight();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"select * from Flight inner join Airplane on airplaneId=Airplane.id";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
                dataGridView1.BackgroundColor = Color.White;

            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //select* from Flight inner join Airplane on airplaneId = Airplane.id where departureTime > 2021
                string query = $"select * from Flight inner join Airplane on airplaneId=Airplane.id where month(departureTime) = {dateTimePicker1.Value.Month} and year(departureTime) = {dateTimePicker1.Value.Year}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.BackgroundColor = Color.White;

            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
