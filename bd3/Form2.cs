using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace bd3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            showDataTicket();

            //fill combobox with airports
            try
            {
                string query = $"SELECT DISTINCT airportFrom, airportTo FROM Flight";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);

                SqlDataReader da = cmd.ExecuteReader();

                while (da.Read())
                {
                    comboBox1.Items.Add(da.GetValue(0).ToString());
                    comboBox1.Items.Add(da.GetValue(1).ToString());
                }
                con.Close();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            dataGridView1.BackgroundColor = Color.White;
        }
        string str = "server=DESKTOP-T5OA1IV\\SQLEXPRESS;database=myAirline; Integrated Security=True;";
        string table = "Ticket";
        private void button2_Click(object sender, EventArgs e)
        {
            showDataTicket();
  
        }

        public void ConvertColumn(string tmp1)
        {
            tmp1 = tmp.Text;

            if (tmp1 == "Имя")
            {
                tmp.Text = "name";
            }
            else if (tmp1 == "Фамилия")
            {
                tmp.Text = "surname";
            }
            else if (tmp1 == "Номер рейса")
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
                string query = $"SELECT min({column}) as min FROM {table} INNER JOIN Passenger ON Passenger.id = passengerId INNER JOIN Flight ON Flight.id = flightId";

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
                string query = $"SELECT max({column}) as max FROM {table} INNER JOIN Passenger ON Passenger.id = passengerId INNER JOIN Flight ON Flight.id = flightId";

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
                string query = $"SELECT sum({column}) as sum FROM {table} INNER JOIN Passenger ON Passenger.id = passengerId INNER JOIN Flight ON Flight.id = flightId";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                

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
                string query = $"SELECT count({column}) as count FROM {table} INNER JOIN Passenger ON Passenger.id = passengerId INNER JOIN Flight ON Flight.id = flightId";

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
                string query = $"SELECT avg({column}) as madium FROM {table} INNER JOIN Passenger ON Passenger.id = passengerId INNER JOIN Flight ON Flight.id = flightId";

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //select* from Flight inner join Airplane on airplaneId = Airplane.id where departureTime > 2021
                string query = $"SELECT * FROM Ticket INNER JOIN Passenger ON Passenger.id = passengerId INNER JOIN Flight ON Flight.id = flightId WHERE month(departureTime) = {dateTimePicker1.Value.Month} and year(departureTime) = {dateTimePicker1.Value.Year}";

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                

            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
               
                string query = $"SELECT airportFrom,  T1.A1, airportTo, T2.A2  FROM (SELECT airportFrom as B1,  count(*) as A1 from Flight INNER JOIN Airplane ON Airplane.id = airplaneId GROUP BY airportFrom ) T1, (SELECT airportTo,  count(*) as A2 from Flight INNER JOIN Airplane ON Airplane.id = airplaneId GROUP BY airportTo ) T2";
                //string guery2 = $"SELECT airportTo, count(*) FROM Flight INNER JOIN Airplane ON Airplane.id = airplaneId GROUP BY airportTo";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
