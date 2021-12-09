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
    public partial class fReport2 : Form
    {
        public fReport2()
        {
            InitializeComponent();
            showDataAirplane();
        }

        public void ConvertColumn(string tmp1)
        {
            tmp1 = tmp.Text;
            
            if (tmp1 == "Кол-во пассажиров")
            {
                tmp.Text = "maxNumberOfPassengers";
            }
            else if (tmp1 == "Производитель")
            {
                tmp.Text = "manufacturer";
            }

        }
        
        string str = "server=DESKTOP-T5OA1IV\\SQLEXPRESS;database=myAirline; Integrated Security=True;";
        string table = "Airplane";
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
                string query = $"SELECT max({column}) FROM {table}";

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
                
                dataGridView1.Columns[1].HeaderText = "Кол-во пассажиров";
                dataGridView1.Columns[2].HeaderText = "Производитель";
                dataGridView1.Columns[0].Visible = false;
                con.Close();
                dataGridView1.BackgroundColor = Color.White;
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public void groupAgr(string agr, string cName)
        {
            try
            {
                string query = $"SELECT manufacturer, {agr}(maxNumberOfPassengers) as {cName} FROM Airplane GROUP BY manufacturer";
                
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tmp.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showDataAirplane();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gr.SelectedItem.ToString() == "МАКС")
            {
                groupAgr("max", "количество");
            }
            else if (gr.SelectedItem.ToString() == "МИН")
            {
                groupAgr("min", "количество");
            }
            else if (gr.SelectedItem.ToString() == "КОЛ-ВО")
            {
                groupAgr("count", "количество");
            }
            
            
        }
    }
}
