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
    public partial class Login : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Show();
            this.Hide();
        }
        public static String AccNumber; 
        private void button1_Click(object sender, EventArgs e) ///ปุ่มล็อคอิน
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            String query = "SELECT * FROM regis WHERE AccNum  = '" +AccNumTb.Text.Trim() + "' and Pin = '" + PinTb.Text.Trim() + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count > 0)
            {
                AccNumber = AccNumTb.Text;
                Home home = new Home();
                home.Show();
                this.Hide();
                conn.Close();
            }
            else 
            {
                MessageBox.Show("รหัสผ่านหรือชื่อของผู้ใช้ ไม่ถูกต้อง");
            }
            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adminlog ADM = new Adminlog();
            ADM.Show();
            this.Hide();
        }
    }
}
