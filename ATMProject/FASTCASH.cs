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
    public partial class FASTCASH : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public FASTCASH()
        {
            InitializeComponent();
        }
        int newbalance=0;
        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
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
            balancelbl.Text = "Balance : " + dt.Rows[0][0].ToString() + " Bath";
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            conn.Close();
        }

        private void FASHCASH_Load(object sender, EventArgs e)
        {
            getbalance();
        }
       
        private void addtransaction1()
        {
            MySqlConnection conn = databaseConnection();
            string TrType = "FashCash";
            newbalance = bal - 100;
            try
            {

                conn.Open();
                string query = "INSERT INTO tran (AccNum,Type,Amount,Balance) VALUES('" + Acc + "','" + TrType + "'," + 100 + ",,"+newbalance+")";
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
        private void addtransaction2()
        {
            MySqlConnection conn = databaseConnection();
            string TrType = "FashCash";
            newbalance = bal - 200;
            try
            {

                conn.Open();
                string query = "INSERT INTO tran (AccNum,Type,Amount,Balance) VALUES('" + Acc + "','" + TrType + "'," + 200 + "," + newbalance + ")";
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
        private void addtransaction3()
        {
            MySqlConnection conn = databaseConnection();
            string TrType = "FashCash";
            newbalance = bal - 500;
            try
            {

                conn.Open();
                string query = "INSERT INTO tran (AccNum,Type,Amount,Balance) VALUES('" + Acc + "','" + TrType + "'," + 500 + "," + newbalance + ")";
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
        private void addtransaction4()
        {
            MySqlConnection conn = databaseConnection();
            string TrType = "FashCash";
            newbalance = bal - 1000;
            try
            {

                conn.Open();
                string query = "INSERT INTO tran (AccNum,Type,Amount,Balance) VALUES('" + Acc + "','" + TrType + "'," + 1000 + "," + newbalance + ")";
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
        private void addtransaction5()
        {
            MySqlConnection conn = databaseConnection();
            string TrType = "FashCash";
            newbalance = bal - 2000;
            try
            {

                conn.Open();
                string query = "INSERT INTO tran (AccNum,Type,Amount,Balance) VALUES('" + Acc + "','" + TrType + "'," + 2000 + "," + newbalance + ")";
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
        private void addtransaction6()
        {
            MySqlConnection conn = databaseConnection();
            string TrType = "FashCash";
            newbalance = bal - 5000;
            try
            {

                conn.Open();
                string query = "INSERT INTO tran (AccNum,Type,Amount,Balance) VALUES('" + Acc + "','" + TrType + "'," + 5000 + "," + newbalance + ")";
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
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (bal < 100)
            {
                MessageBox.Show("ยอดเงินในบัญชีไม่เพียงพอ");
            }
            else
            {
               int newbalance = bal - 100;
                try
                {
                    conn.Open();
                    string query = "UPDATE regis SET Balance=" + newbalance + " WHERE Accnum='" + Acc + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ถอนเงิน สำเร็จ");
                    conn.Close();
                    addtransaction1();
                    Home home = new Home();
                    home.Show();
                    bill billform = new bill(button100.Text);
                    billform.Show();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (bal < 200)
            {
                MessageBox.Show("ยอดเงินในบัญชีไม่เพียงพอ");
            }
            else
            {
                int newbalance = bal - 200;
                try
                {
                    conn.Open();
                    string query = "UPDATE regis SET Balance=" + newbalance + " WHERE Accnum='" + Acc + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ถอนเงิน สำเร็จ");
                    conn.Close();
                    addtransaction2();
                    Home home = new Home();
                    home.Show();
                    bill billform = new bill(button200.Text);
                    billform.Show();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (bal < 500)
            {
                MessageBox.Show("ยอดเงินในบัญชีไม่เพียงพอ");
            }
            else
            {
                int newbalance = bal - 500;
                try
                {
                    conn.Open();
                    string query = "UPDATE regis SET Balance=" + newbalance + " WHERE Accnum='" + Acc + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ถอนเงิน สำเร็จ");
                    conn.Close();
                    addtransaction3();
                    Home home = new Home();
                    home.Show();
                    bill billform = new bill(button500.Text);
                    billform.Show();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (bal < 1000)
            {
                MessageBox.Show("ยอดเงินในบัญชีไม่เพียงพอ");
            }
            else
            {
                int newbalance = bal - 1000;
                try
                {
                    conn.Open();
                    string query = "UPDATE regis SET Balance=" + newbalance + " WHERE Accnum='" + Acc + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ถอนเงิน สำเร็จ");
                    conn.Close();
                    addtransaction4();
                    Home home = new Home();
                    home.Show();
                    bill billform = new bill(button1000.Text);
                    billform.Show();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (bal < 2000)
            {
                MessageBox.Show("ยอดเงินในบัญชีไม่เพียงพอ");
            }
            else
            {
                int newbalance = bal - 2000;
                try
                {
                    conn.Open();
                    string query = "UPDATE regis SET Balance=" + newbalance + " WHERE Accnum='" + Acc + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ถอนเงิน สำเร็จ");
                    conn.Close();
                    addtransaction5();
                    Home home = new Home();
                    home.Show();
                    bill billform = new bill(button2000.Text);
                    billform.Show();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (bal < 5000)
            {
                MessageBox.Show("ยอดเงินในบัญชีไม่เพียงพอ");
            }
            else
            {
                int newbalance = bal - 5000;
                try
                {
                    conn.Open();
                    string query = "UPDATE regis SET Balance=" + newbalance + " WHERE Accnum='" + Acc + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ถอนเงิน สำเร็จ");
                    conn.Close();
                    addtransaction6();
                    Home home = new Home();
                    home.Show();
                    bill billform = new bill(button5000.Text);
                    billform.Show();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
