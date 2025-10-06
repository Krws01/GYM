using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GYM
{
    public partial class Home_ : Form
    {
        public static string LoggedInUser { get; set; }

        public Home_()
        {
            InitializeComponent();
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("select UserName,pass from responsible ", conn);
            //SqlDataReader rdr = cmd.ExecuteReader();

            Home home = new Home();
            home.Show();
            this.Hide();

            

        }


        private void button4_MouseEnter(object sender, EventArgs e)
        {
            
                button4.FlatStyle = FlatStyle.Standard;
                button4.FlatAppearance.BorderColor = Color.FromArgb(35, 45, 63);
                button4.FlatAppearance.BorderSize = 2;
            
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {

            
            button5.FlatStyle = FlatStyle.Standard;
            button5.FlatAppearance.BorderColor = Color.FromArgb(35, 45, 63);
            button5.FlatAppearance.BorderSize = 2;

 
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.FlatStyle = FlatStyle.Standard;
            button6.FlatAppearance.BorderColor = Color.FromArgb(35, 45, 63);
            button6.FlatAppearance.BorderSize = 2;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        { 
                button4.FlatStyle = FlatStyle.Flat;
              
        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.FlatStyle = FlatStyle.Flat;

        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {

            button6.FlatStyle = FlatStyle.Flat;
        }

        private void Home__Load(object sender, EventArgs e)
        {
            button6.MouseLeave += new EventHandler(button6_MouseLeave);
            button6.MouseEnter += new EventHandler(button6_MouseEnter);

            button4.MouseLeave += new EventHandler(button4_MouseLeave);
            button4.MouseEnter += new EventHandler(button4_MouseEnter);

            button5.MouseLeave += new EventHandler(button5_MouseLeave);
            button5.MouseEnter += new EventHandler(button5_MouseEnter);

            panel12.Click += new EventHandler(panel12_Click);
            panel13.Click += new EventHandler(panel13_Click);
            panel14.Click += new EventHandler(panel14_Click);


            panel12.MouseLeave += new EventHandler(Panel_X_MouseLeave);
            panel12.MouseEnter += new EventHandler(Panel_X);

            panel13.MouseLeave += new EventHandler(Panel_Sq_MouseLeave);
            panel13.MouseEnter += new EventHandler(Panel_Sq);

            panel14.MouseLeave += new EventHandler(Panel_Mi_MouseLeave);
            panel14.MouseEnter += new EventHandler(Panel_Mi);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LoggedInUser != "Admin")
            {
                MessageBox.Show("غير مصرح لك بالدخول","خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Administration Admin = new Administration();
                Admin.Show();
                this.Hide();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(" قريبا          ","صيانة",MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void panel13_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                Location = new Point(356, 146);
            }
            else
            {
                WindowState = FormWindowState.Maximized;

            }
        }
        private void panel14_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Panel_X(object sender, EventArgs e)
        {

            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.BackColor = Color.Red;


        }
        private void Panel_Sq(object sender, EventArgs e)
        {


            panel13.BorderStyle = BorderStyle.FixedSingle;


        }
        private void Panel_Mi(object sender, EventArgs e)
        {
            panel14.BorderStyle = BorderStyle.FixedSingle;

        }

        private void Panel_X_MouseLeave(object sender, EventArgs e)
        {
            panel12.BorderStyle = BorderStyle.None;
            panel12.BackColor = Color.FromArgb(7, 15, 43);

        }
        private void Panel_Sq_MouseLeave(object sender, EventArgs e)
        {
            panel13.BorderStyle = BorderStyle.None;

        }
        private void Panel_Mi_MouseLeave(object sender, EventArgs e)
        {

            panel14.BorderStyle = BorderStyle.None;
        }
    }
}
