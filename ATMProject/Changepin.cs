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
    public partial class Changepin : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Changepin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        String Acc = Login.AccNumber;
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (Pin1Tb.Text == "" || Pin2Tb.Text == "")
            {
                MessageBox.Show("Enter And Confirm The New Pin");
            }
            else if (Pin2Tb.Text != Pin1Tb.Text) 
            {
                MessageBox.Show("Pin1 and Pin2 Are Different");
            }
            else
            {

                try
                {
                    conn.Open();
                    string query = "UPDATE regis SET PIN=" + Pin1Tb.Text + " WHERE Accnum='" + Acc + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("เปลี่ยน PIN เสร็จสิ้น");
                    conn.Close();
                    Login home = new Login();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

