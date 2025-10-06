using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GYM
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        string user, pass;
        private void button1_Click(object sender, EventArgs e)
        {
            user = TextUserName.Text;
            pass = TextPassword.Text;
            Home.LoggedInUser = user;
            Home_.LoggedInUser = user;
            Administration.LoggedInUser = user;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
            conn.Open();
            SqlCommand cmd = new SqlCommand("select UserName,pass from responsible where UserName='" + user + "'and pass='" + pass + "'",conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.Read())
            {
                //MessageBox.Show("login Succufull");
                Home_ home = new Home_(); 
                home.Show();
                this.Hide();
            }
            else
            {
                //MessageBox.Show("login Failed");
                label4.Text = "Login Failed";
                label4.ForeColor = Color.Red;
            }
            conn.Close();
            rdr.Close();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
