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
    public partial class WITHDRAW : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public WITHDRAW()
        {
            InitializeComponent();
        }
        String Acc = Login.AccNumber;
        int bal;
        private void getbalance()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Balance FROM regis WHERE AccNum = '" + Acc + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "Balance : " + dt.Rows[0][0].ToString() +" Bath";
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());    
            conn.Close();
        }
        private void addtransaction()
        {
            MySqlConnection conn = databaseConnection();
            string TrType = "WithDraw";
            try
            {

                conn.Open();
                string query = "INSERT INTO tran (AccNum,Type,Amount,Balance) VALUES('" + Acc + "','" + TrType + "'," + wdamtTB.Text + "," +newbalance+ ")";
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
        private void WITHDRAW_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            getbalance();
        }
        int oldbalance, newbalance;

        private void label3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int money = int.Parse(wdamtTB.Text);
            MySqlConnection conn = databaseConnection();
            if (wdamtTB.Text == "")
            {
                MessageBox.Show("กรุณากรอกจำนวนเงินที่จะถอน");
            }
            else if (Convert.ToInt32(wdamtTB.Text) <= 0)
            {
                MessageBox.Show("กรุณากรอกจำนวนเงินที่จะถอน");
            }
            else if (Convert.ToInt32(wdamtTB.Text) > bal)
            {
                MessageBox.Show("ไม่สามารถถอนได้เนื่องจากเงินในบัญชีไม่เพียงพอ");
            }
            else if (money % 100 != 0)
            {
                MessageBox.Show("ตู้นี้บรรจุธนบัตร 100,500,1000");
            }
            else 
            {
                try
                {
                        newbalance = bal - Convert.ToInt32(wdamtTB.Text);
                        conn.Open();
                        string query = "UPDATE regis SET Balance=" + newbalance + " WHERE Accnum='" + Acc + "'";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ถอนเงิน'สำเร็จ'");
                        conn.Close();
                        addtransaction();
                        Home home = new Home();
                        home.Show();
                        bill billform = new bill(wdamtTB.Text);
                        billform.Show();
                        this.Close();
                        
                }
                catch (Exception Ex) 
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
