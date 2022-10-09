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
    public partial class Admin : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectatm;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Admin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void showdata() 
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM regis";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            datauser.DataSource = ds.Tables[0].DefaultView;
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            showdata();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            datauser.CurrentRow.Selected = true;
            AccNum.Text = datauser.Rows[e.RowIndex].Cells["AccNum"].FormattedValue.ToString();
            Name.Text = datauser.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            Faname.Text = datauser.Rows[e.RowIndex].Cells["FaName"].FormattedValue.ToString();
            Date.Text = datauser.Rows[e.RowIndex].Cells["Dob"].FormattedValue.ToString();
            Address.Text = datauser.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
            Balance.Text = datauser.Rows[e.RowIndex].Cells["Balance"].FormattedValue.ToString();
            Ocup.Text = datauser.Rows[e.RowIndex].Cells["Occupation"].FormattedValue.ToString();
            educationtb.Text = datauser.Rows[e.RowIndex].Cells["Education"].FormattedValue.ToString();
            Phone.Text = datauser.Rows[e.RowIndex].Cells["Phone"].FormattedValue.ToString();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRow = datauser.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(datauser.Rows[selectedRow].Cells["AccNum"].Value);
            MySqlConnection conn = databaseConnection();

            String sql = "UPDATE regis SET AccNum = '" + AccNum.Text + "',Name = '" + Name.Text + "',FaName = '" + Faname.Text + "',Phone = '" + Phone.Text + "',Education = '"+educationtb.Text+"',Occupation = '"+Ocup.Text+"',Dob = '"+Date.Text+"',Balance = '"+Balance.Text+"',Address = '"+Address.Text+"'WHERE AccNum = '" + editId + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
            }
            this.Hide();
            Admin ad = new Admin();
            ad.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRow = datauser.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(datauser.Rows[selectedRow].Cells["AccNum"].Value);

            MySqlConnection conn = databaseConnection();

            String sql = "DELETE FROM regis WHERE AccNum = '" + deleteId + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("ลบข้อมูล'USER'สำเร็จ");
            }
            this.Hide();
            Admin Ad = new Admin();
            Ad.ShowDialog();
        }
    }
}
