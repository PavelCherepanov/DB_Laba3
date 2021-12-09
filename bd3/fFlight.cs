using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace bd3
{
    public partial class fFlight : Form
    {
        string str = "server=DESKTOP-T5OA1IV\\SQLEXPRESS;database=myAirline; Integrated Security=True;";
        public fFlight()
        {

            InitializeComponent();
            //ADD
            dateTimePicker1.Format = DateTimePickerFormat.Custom; 
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";

            dateTimePicker8.Format = DateTimePickerFormat.Custom;
            dateTimePicker8.CustomFormat = "hh:mm:sss";

            dateTimePicker9.Format = DateTimePickerFormat.Custom;
            dateTimePicker9.CustomFormat = "hh:mm:sss";
            //EDIT
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "dd-MM-yyyy";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd-MM-yyyy";

            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.CustomFormat = "hh:mm:sss";

            dateTimePicker6.Format = DateTimePickerFormat.Custom;
            dateTimePicker6.CustomFormat = "hh:mm:sss";
            showData();
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string query = "SELECT [id], [maxNumberOfPassengers], [manufacturer] FROM Airplane";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                comboBox1.Items.Add(da.GetValue(1).ToString() + " " + da.GetValue(2).ToString());
                comboBox2.Items.Add(da.GetValue(1).ToString() + " " + da.GetValue(2).ToString());
            }
            con.Close();
        }
        
        public void editRow(string id, int flightNumber, string departureTime, string arrivalTime, string airportFrom, string airportTo, int airplaneId)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string query = $"UPDATE [dbo].[Flight] SET [flightNumber] = {flightNumber}," +
                $" [departureTime] = '{departureTime}'," +
                $" [arrivalTime] = '{arrivalTime}'," +
                $" [airportFrom] = '{airportFrom}', " +
                $"[airportTo] = '{airportTo}'," +
                $"[airplaneId] = '{airplaneId}'" +
                $" WHERE id='{id}';";

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
            //string id = textBoxId.Text;

            string query = $"DELETE FROM [dbo].[Flight] WHERE id={id};";

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
        public void showData()
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
                //dataGridView1.RowHeadersVisible = false;
            }

            catch (Exception es)

            {
                MessageBox.Show(es.Message);
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string flightNumber = tbFlight.Text;
            //string flightNumber = tbFlight.Text;
            string departureTime = dateTimePicker1.Text + " " + dateTimePicker8.Text;
            string arrivalTime = dateTimePicker2.Text + " " + dateTimePicker9.Text;
            //string airplaneId = tbManufacturer.Text;
            string airportFrom = textBox3.Text;
            string airportTo = textBox4.Text;

            bool isFlightNumber = Regex.IsMatch(flightNumber, @"[\d]");
            bool isDepartureTime = Regex.IsMatch(departureTime, @"[\d]\-|\.[\d]\-|\.[\d](.+)[\d]\:[\d]\:[\d]");
            bool isArrivalTime = Regex.IsMatch(arrivalTime, @"[\d]\-|\.[\d]\-|\.[\d](.+)[\d]\:[\d]\:[\d]");
            bool isAirportFrom = Regex.IsMatch(airportFrom, @"[a-zA-ZА-Яа-я]");
            bool isAirportTo = Regex.IsMatch(airportTo, @"[a-zA-ZА-Яа-я]");

            SqlConnection con = new SqlConnection(str);
            con.Open();
            string[] ss = comboBox1.Text.Split(" ");
            string maxNumberOfPassengers = ss[0];
            string manufacturer = ss[1];
            string query = $"SELECT * FROM Airplane where maxNumberOfPassengers='{maxNumberOfPassengers}' and manufacturer='{manufacturer}'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
            label15.Text = da.GetValue(0).ToString();
            }
            con.Close();

            
            
            if (isFlightNumber == true & isDepartureTime == true & isArrivalTime == true & isAirportFrom == true & isAirportTo == true)
            {
                SqlConnection con2 = new SqlConnection(str);
                con2.Open();

                string query2 = $"INSERT INTO [dbo].[Flight] ([flightNumber], [departureTime], [arrivalTime], [airportFrom], [airportTo], [airplaneId]) VALUES " +
                    $"('{flightNumber}', '{departureTime}', '{arrivalTime}', '{airportFrom}', '{airportTo}', '{label15.Text}');";

                
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                
                try
                {
                    cmd2.ExecuteNonQuery();
                   // cmd2.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

                con2.Close();
                showData();
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные");
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {

            string id = textBox6.Text;
            string flightNumber = textBox5.Text;
            string departureTime = dateTimePicker4.Text + " " + dateTimePicker5.Text;
            string arrivalTime = dateTimePicker3.Text + " " + dateTimePicker6.Text;
            string airportFrom = textBox2.Text;
            string airportTo = textBox1.Text;

            bool isFlightNumber = Regex.IsMatch(flightNumber, @"[\d]");
            bool isDepartureTime = Regex.IsMatch(departureTime, @"[\d]\-|\.[\d]\-|\.[\d](.+)[\d]\:[\d]\:[\d]");
            bool isArrivalTime = Regex.IsMatch(arrivalTime, @"[\d]\-|\.[\d]\-|\.[\d](.+)[\d]\:[\d]\:[\d]");
            bool isAirportFrom = Regex.IsMatch(airportFrom, @"[a-zA-ZА-Яа-я]");
            bool isAirportTo = Regex.IsMatch(airportTo, @"[a-zA-ZА-Яа-я]");
            

            SqlConnection con = new SqlConnection(str);
            con.Open();
            string[] ss = comboBox2.Text.Split(" ");
            string maxNumberOfPassengers = ss[0];
            string manufacturer = ss[1];
            string query = $"SELECT * FROM Airplane where maxNumberOfPassengers='{maxNumberOfPassengers}' and manufacturer='{manufacturer}'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                label17.Text = da.GetValue(0).ToString();
            }
            con.Close();
            int airplaneId = Convert.ToInt32(label17.Text);

            if (isFlightNumber == true & isDepartureTime == true & isArrivalTime == true & isAirportFrom == true & isAirportTo == true)
            {
                editRow(id, Convert.ToInt32(flightNumber), departureTime, arrivalTime, airportFrom, airportTo, airplaneId);

                showData();
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox6.Text = row.Cells[0].Value.ToString();
                textBox5.Text = row.Cells[1].Value.ToString();
                string[] dateD = row.Cells[2].Value.ToString().Split(" ");
                string[] dateA = row.Cells[3].Value.ToString().Split(" ");

                string[] timeD = row.Cells[2].Value.ToString().Split(" ");
                string[] timeA = row.Cells[3].Value.ToString().Split(" ");

                dateTimePicker4.Text = dateD[0];
                dateTimePicker5.Text = timeD[1];
                dateTimePicker3.Text = dateA[0];
                dateTimePicker6.Text = timeA[1];
       
                textBox2.Text = row.Cells[5].Value.ToString();
                textBox1.Text = row.Cells[6].Value.ToString();

                comboBox2.Text = row.Cells[8].Value.ToString()+" "+ row.Cells[9].Value.ToString();
            }
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
        }
    }
}