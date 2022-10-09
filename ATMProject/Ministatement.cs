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
   
    public partial class Ministatement : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Ministatement()
        {
            InitializeComponent();
        }
        string Acc = Login.AccNumber;
        private void populate() 
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            string query = "SELECT * FROM tran WHERE AccNum='" + Acc + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MinistatementDGV.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void Ministatement_Load(object sender, EventArgs e)
        {
            populate();
            getbalance();
        }
        int bal;
        private void getbalance()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Balance FROM regis WHERE AccNum = '" + Acc + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "ยอดเงินคงเหลือในบัญชี : " + dt.Rows[0][0].ToString() + " Bath";
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            conn.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
