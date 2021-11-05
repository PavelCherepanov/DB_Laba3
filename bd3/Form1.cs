using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bd3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bAirplane_Click(object sender, EventArgs e)
        {
            fAirplane airplane = new fAirplane();
            airplane.Show();
        }

        private void bFlight_Click(object sender, EventArgs e)
        {
            fFlight flight = new fFlight();
            flight.Show();
        }

        private void bPassenger_Click(object sender, EventArgs e)
        {
            fPassenger passenger = new fPassenger();
            passenger.Show();
        }

        private void bTicket_Click(object sender, EventArgs e)
        {
            fTicket ticket = new fTicket();
            ticket.Show();
        }
    }
}
