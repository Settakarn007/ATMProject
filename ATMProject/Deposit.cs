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
    public partial class Deposit : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Deposit()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }
        string Acc = Login.AccNumber;
        private void addtransaction() 
        {
            MySqlConnection conn = databaseConnection();
            string TrType = "Deposit";
            try
            {

                conn.Open();
                string query = "INSERT INTO tran (AccNum,Type,Amount,Balance) VALUES('" + Acc + "','" + TrType + "'," + DepoAtmTb.Text + "," + newbalance + ")";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Account Created Successfully");
                conn.Close();
                Login log = new Login();
                log.Show();
                this.Hide();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (DepoAtmTb.Text == "" || Convert.ToInt32(DepoAtmTb.Text) <= 0)
            {
                MessageBox.Show("กรุณากรอกจำนวนที่จะฝาก");
            }
            else 
            {
               
                newbalance = oldbalance + Convert.ToInt32(DepoAtmTb.Text);
                try
                {
                    conn.Open();
                    string query = "UPDATE regis SET Balance="+newbalance+" WHERE Accnum='"+Acc+"'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ฝากเงินสำเร็จ");
                    conn.Close();
                    addtransaction();
                    Home home = new Home();
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
        int oldbalance,newbalance;
        private void getbalance()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Balance FROM regis WHERE AccNum = '" + Acc + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            conn.Close();
        }
        private void Deposit_Load(object sender, EventArgs e)
        {
            getbalance();
        }
    }
}
