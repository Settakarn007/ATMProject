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
    public partial class Account : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Account()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Account_Load(object sender, EventArgs e)
        {

        }
       
        public Boolean checkUsername() /// เช็คuser ว่าซ้ำมั้ย
        {
            MySqlConnection conn = databaseConnection();

            String username = AccNumTb.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM regis WHERE AccNum = @Accnum", conn);

            command.Parameters.Add("@Accnum", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (AccNametb.Text == "" || AccNumTb.Text == "" || FanameTb.Text == "" || PhoneTb.Text == "" || Addresstb.Text == "" || occupationtb.Text == "" || pintb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (AccNumTb.Text.Length < 3)
            {
                MessageBox.Show("กรูณาตั้งชื่อผู้ใช้ 2 ตัวอักษรขึ้นไป", "Register Failed");
            }

            else if (pintb.Text.Length < 3)
            {
                MessageBox.Show("กรูณาตั้งรหัสผ่าน 2 ตัวอักษรขึ้นไป", "Register Failed");
            }
            else if (pintb.Text != conpintb.Text)
            {
                MessageBox.Show("PIN HAVE DIFFERENT");
            }
            else if (PhoneTb.Text.Length  != 10) 
            {
                MessageBox.Show("Pls Type correct Phon number");            
            }
            else
            {
                if (checkUsername())
                {
                    MessageBox.Show("AccNum นี้มีคนใช้แล้ว");
                }
                else 
                {
                    conn.Open();
                    string query = "INSERT INTO regis (AccNum,Name,FaName,Dob,Phone,Address,Education,Occupation,Pin,Balance) VALUES('" + AccNumTb.Text + "','" + AccNametb.Text + "','" + FanameTb.Text + "','" + dobdate.Text + "','" + PhoneTb.Text + "','" + Addresstb.Text + "','" + educationtb.SelectedItem.ToString() + "','" + occupationtb.Text + "'," + pintb.Text + ",'"+BalanceTb.Text+"')";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("สร้างบัญชีสำเร็จ");
                    conn.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                
               
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
