using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();    
            this.Hide();
            bal.Show();
        }
        public static String AccNumber;
        private void Home_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = "Account Number:" + Login.AccNumber;
            AccNumber = Login.AccNumber;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            depo.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Changepin Pin = new Changepin();
            Pin.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WITHDRAW wd = new WITHDRAW();
            wd.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FASTCASH Fcash = new FASTCASH();
            Fcash.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ministatement ministatement = new Ministatement(); 
            ministatement.Show();
            this.Hide();
        }
    }
}
