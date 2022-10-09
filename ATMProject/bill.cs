using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ATMProject
{
    public partial class bill : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public bill(string data)
        {
            InitializeComponent();
            tonlbl.Text = "จำนวนเงินที่ท่านถอน : " + data + " Bath";
        }
        String Acc = Login.AccNumber;
        
        private void getname()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Name FROM regis WHERE AccNum = '" + Acc + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Namelbl.Text = "ชื่อ : " + dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void getphone()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Phone FROM regis WHERE AccNum = '" + Acc + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            phonelbl.Text = "Phone : " + dt.Rows[0][0].ToString() ;
            conn.Close();
        }
        private void getFname()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT FaName FROM regis WHERE AccNum = '" + Acc + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Fnamelbl.Text = "  " + dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void getDob()
        {
            
            Doblbl.Text = "เวลา : " + System.DateTime.Now.ToString("dd/MM/yyyy HH : mm : ss น.");
        }

        private void bill_Load(object sender, EventArgs e)
        {
            getname();
            getphone();
            getFname();
            getDob();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
