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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.AxHost;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;


namespace GYM
{

    public partial class Administration : Form
    {
        public static string LoggedInUser { get; set; }
        
        public Administration()
        {
            InitializeComponent();

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Administration_Load(object sender, EventArgs e)
        {
            panel9.BringToFront();

            panel12.Click += new EventHandler(panel12_Click);
            panel13.Click += new EventHandler(panel13_Click);
            panel14.Click += new EventHandler(panel14_Click);


            panel12.MouseLeave += new EventHandler(Panel_X_MouseLeave);
            panel12.MouseEnter += new EventHandler(Panel_X);

            panel13.MouseLeave += new EventHandler(Panel_Sq_MouseLeave);
            panel13.MouseEnter += new EventHandler(Panel_Sq);

            panel14.MouseLeave += new EventHandler(Panel_Mi_MouseLeave);
            panel14.MouseEnter += new EventHandler(Panel_Mi);

            if(LoggedInUser== "Admin")
            {
               pictureBox2.BackgroundImage = Image.FromFile("D:\\projects\\م.مهند\\Imge\\Admin3.jpg");
               label31.Text = LoggedInUser + " :المدير";
            }

            


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
            conn.Open();
            //عدد المشتركين
            SqlCommand cmd = new SqlCommand("SELECT COUNT(Name) \r\nFROM Subscriber\r\nWHERE Name IS NOT NULL;", conn);
            int NumberSubscriber = (int)cmd.ExecuteScalar();
            label19.Text = NumberSubscriber.ToString();
            //اسم افضل مدرب 
            SqlCommand cmd1 = new SqlCommand("\r\nSELECT TOP 1 Coach, COUNT(*) AS occurrence\r\nFROM Subscriber\r\nWHERE Coach IS NOT NULL AND Coach <> ''\r\nGROUP BY Coach\r\nORDER BY occurrence DESC;\r\n ", conn);
            string NameC = (string)cmd1.ExecuteScalar();
            label21.Text = NameC;
            //الارباح 
            SqlCommand cmd2 = new SqlCommand("\r\nSELECT SUM(TRY_CAST(REPLACE(price, 'RY', '') AS DECIMAL(10, 0)))\r\nFROM Subscriber\r\nWHERE TRY_CAST(REPLACE(price, 'RY', '') AS DECIMAL(10, 2)) IS NOT NULL;  ", conn);
            object result = cmd2.ExecuteScalar();
            label23.Text = result + " RY";
            //نسبة الحضور
            SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) \r\nFROM Subscriber\r\nWHERE Available = 1;  \r\n ", conn);
            int NumberAvailable = (int)cmd3.ExecuteScalar();
            double attendanceRate = ((double)NumberAvailable / NumberSubscriber) * 100;
            label26.Text = attendanceRate.ToString("F2") + " %";
            //افضل قسم 
            SqlCommand cmd4 = new SqlCommand("SELECT TOP 1 Section\r\nFROM Subscriber", conn);
            string NameSection = (string)cmd4.ExecuteScalar();
            label28.Text = "ال"+NameSection;
            //افضل موظف 
            SqlCommand cmd5 = new SqlCommand("SELECT Name_responsible\r\nFROM responsible\r\nWHERE best = 1;", conn);
            string BestEmp = (string)cmd5.ExecuteScalar();
            label27.Text = BestEmp;

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
        bool sidebar;
       
        private void MenuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebar)
            {
                //if sidebar is MinimumSize
                panel1.Width -= 10;

                if (panel1.Width == panel1.MinimumSize.Width)
                {

                    sidebar = false;

                    sidebarTimer.Stop();

                }
            }
            else
            {
                //if sidebar is MaximumSize
                panel1.Width += 10;

                if (panel1.Width == panel1.MaximumSize.Width)
                {
                    sidebar = true;

                    sidebarTimer.Stop();

                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home_ home = new Home_();
            home.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login fm2 = new Login();
            fm2.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }


        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void timerdate_Tick(object sender, EventArgs e)
        {
            label18.Text = DateTime.Now.ToString();

            if (label19.ForeColor == Color.White && label23.ForeColor == Color.White && label21.ForeColor == Color.White && label26.ForeColor == Color.White && label28.ForeColor == Color.White && label27.ForeColor == Color.White)
            {
                label19.ForeColor = Color.Yellow;
                label23.ForeColor = Color.Yellow;
                label21.ForeColor = Color.Yellow;
                label26.ForeColor = Color.Yellow;
                label28.ForeColor = Color.Yellow;
                label27.ForeColor = Color.Yellow;


            }
            else if (label19.ForeColor == Color.Yellow && label23.ForeColor == Color.Yellow && label21.ForeColor == Color.Yellow && label26.ForeColor == Color.Yellow && label28.ForeColor == Color.Yellow && label27.ForeColor == Color.Yellow)
            {
                label19.ForeColor = Color.White;
                label23.ForeColor = Color.White;
                label21.ForeColor = Color.White;
                label26.ForeColor = Color.White;
                label28.ForeColor = Color.White;
                label27.ForeColor = Color.White;
            }

        }
       
        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
        string F_Name, L_Name, DOB, pass, N_user, P_Num, IsBest, N_id;

        private void button2_Click(object sender, EventArgs e)
        {
            panel8.BringToFront();
            label8.Text = "      اداراة الموظفين";
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel7.BringToFront();
            label8.Text = "      اداراة المدربين";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel10.BringToFront();
            label8.Text = "      طباعة الاستمارات";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            F_Name = textBox7.Text;
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("ادخل اسم المدرب للبحث", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Coach WHERE Name = @F_Name", conn);
                cmd.Parameters.AddWithValue("@F_Name", F_Name);

                // تنفيذ الاستعلام واسترجاع البيانات
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // استرجاع البيانات من القارئ
                        string lastName = reader["LastName"].ToString();
                        string dob = reader["DOB"].ToString();
                        DateTime B_D = Convert.ToDateTime(reader["DOB"]);
                        int Age = D_Now - B_D.Year;
                        string phone = reader["Phone"].ToString();
                        string Nat_id = reader["National_ID"].ToString();

                        string message = $"الاسم الاول : {F_Name}\n" + $"الاسم الأخير: {lastName}\n" + $"العمر : {Age.ToString() + "سنة"}\n" + $"رقم الهاتف: {phone}\n" +  $"رقم الهوية : {Nat_id}\n";

                        MessageBox.Show(message, "بيانات المدرب", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على المدرب", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                }


                reader.Close();
                conn.Close();
            }
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox4.Clear();
            dateTimePicker2.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {


                F_Name = textBox7.Text;
                if (string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    MessageBox.Show("ادخل اسم المدرب للبحث", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                }
                else
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Coach WHERE Name = @F_Name", conn);
                    cmd.Parameters.AddWithValue("@F_Name", F_Name);

                    // تنفيذ الاستعلام واسترجاع البيانات
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // استرجاع البيانات من القارئ
                            string lastName = reader["LastName"].ToString();
                            string dob = reader["DOB"].ToString();
                            DateTime B_D = Convert.ToDateTime(reader["DOB"]);
                            int Age = D_Now - B_D.Year;
                            string phone = reader["Phone"].ToString();
                            string Nat_id = reader["National_ID"].ToString();

                            string message = $"الاسم الاول : {F_Name}\n" + $"الاسم الأخير: {lastName}\n" + $"العمر : {Age.ToString() + "سنة"}\n" + $"رقم الهاتف: {phone}\n" + $"رقم الهوية : {Nat_id}\n";
                            DialogResult result = MessageBox.Show(message, "هل هو المدرب المطلوب؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                textBox7.Text = F_Name;
                                textBox8.Text = lastName;
                                dateTimePicker2.Text = dob;
                                textBox9.Text = phone;
                                textBox4.Text = Nat_id;
                                

                            }
                            else
                            {
                                MessageBox.Show("لم يتم العثور على المدرب", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على المدرب", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            else
            {
                SqlConnection conn = new SqlConnection("server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true");
                conn.Open();
                F_Name = textBox7.Text;
                L_Name = textBox8.Text;
                DOB = dateTimePicker2.Text;
                P_Num = textBox9.Text;
                N_id = textBox4.Text;
               
                SqlCommand updateCmd = new SqlCommand("UPDATE Coach SET LastName = @L_Name, DOB = @DOB, Phone = @P_Num, National_ID = @N_id WHERE Name = @F_Name;", conn);
                updateCmd.Parameters.AddWithValue("@F_Name", F_Name);
                updateCmd.Parameters.AddWithValue("@L_Name", L_Name);
                updateCmd.Parameters.AddWithValue("@DOB", DOB);
                updateCmd.Parameters.AddWithValue("@P_Num", P_Num);
                updateCmd.Parameters.AddWithValue("@N_id", N_id);
                updateCmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("تم تعديل بيانات المدرب بنجاح", "الادارة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox4.Clear();
                dateTimePicker2.Text = "";
            }



        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string pdfPath = "\"D:\\projects\\م.مهند\\pdf\\استمارة العضو.pdf\"";
            Process.Start(pdfPath);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string pdfPath = "\"D:\\projects\\م.مهند\\pdf\\استمارة طلب توظيف.pdf\"";
            Process.Start(pdfPath);
        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel26.BringToFront();
            label8.Text = "      بانات الموظفين ";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Name,LastName,Phone\r\nFROM Coach; ", conn);
            SqlCommand cmd1 = new SqlCommand("SELECT Name_responsible,LastName_responsible,Phone FROM responsible;", conn);

            //استخدام SqlDataAdapter لتحميل البيانات
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);

            // DataTable ب dataGridView ربط 
            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table1;
            conn.Close();

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            F_Name = textBox7.Text;
            L_Name = textBox8.Text;
            DOB = dateTimePicker2.Text;
            P_Num = textBox9.Text;
            N_id = textBox4.Text;

            if (string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(dateTimePicker2.Text) || string.IsNullOrWhiteSpace(textBox9.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("يجب تعبئة كافة الحقول عند الاضافة", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Coach(Name, LastName, DOB,Phone,National_ID) VALUES(@F_Name, @L_Name ,@DOB ,@P_Num,@N_id)", conn);

                cmd.Parameters.AddWithValue("@F_Name", F_Name);
                cmd.Parameters.AddWithValue("@L_Name", L_Name);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@P_Num", P_Num);
                cmd.Parameters.AddWithValue("@N_id", N_id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("تم إضافة المدرب بنجاح!", "الأدارة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox4.Clear();
            dateTimePicker2.Text = "";

        }
    


        private void button1_Click(object sender, EventArgs e)
        {
            panel9.BringToFront();
            label8.Text = "      قسم الادارة";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {


                F_Name = textBox1.Text;
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("ادخل اسم العميل للتعديل", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                }
                else
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM responsible WHERE Name_responsible = @F_Name", conn);
                    cmd.Parameters.AddWithValue("@F_Name", F_Name);


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            string lastName = reader["LastName_responsible"].ToString();
                            string dob = reader["DOB"].ToString();
                            DateTime B_D = Convert.ToDateTime(reader["DOB"]);
                            int Age = D_Now - B_D.Year;
                            string phone = reader["Phone"].ToString();
                            string User = reader["UserName"].ToString();
                            string Password = reader["Pass"].ToString();
                            string IsBest1 = reader["Best"].ToString();
                            if (IsBest1 == "False")
                            {
                                IsBest1 = "لا";
                            }
                            else
                                IsBest1 = "نعم";

                            string message = $"الاسم الاول : {F_Name}\n" + $"الاسم الأخير: {lastName}\n" + $"العمر : {Age.ToString() + "سنة"}\n" + $"رقم الهاتف: {phone}\n" + $"  {User} :اسم المستخدم\n" + $"كلمة السر: {Password}\n" + $" هل هو افضل موظف؟ {IsBest1}\n";

                            DialogResult result = MessageBox.Show(message, "هل هو الموظف المطلوب؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                textBox1.Text = F_Name;
                                textBox2.Text = lastName;
                                dateTimePicker1.Text = dob;
                                textBox5.Text = phone;
                                textBox6.Text = User;
                                textBox3.Text = Password;
                                comboBox2.Text = IsBest1;
                                
                            }
                            else
                            {
                                MessageBox.Show("لم يتم العثور على المستخدم", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على المستخدم", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            else
            {
                SqlConnection conn = new SqlConnection("server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true");
                conn.Open();
                F_Name = textBox1.Text;
                L_Name = textBox2.Text;
                DOB = dateTimePicker1.Text;
                P_Num = textBox5.Text;
                N_user = textBox6.Text;
                pass = textBox3.Text;
                IsBest = comboBox2.Text;
                SqlCommand updateCmd = new SqlCommand("UPDATE responsible SET LastName_responsible = @L_Name, DOB = @DOB, Phone = @P_Num, UserName = @N_user, Pass = @pass, Best = @IsBest WHERE Name_responsible = @F_Name;", conn);
                updateCmd.Parameters.AddWithValue("@F_Name", F_Name);
                updateCmd.Parameters.AddWithValue("@L_Name", L_Name);
                updateCmd.Parameters.AddWithValue("@DOB", DOB);
                updateCmd.Parameters.AddWithValue("@P_Num", P_Num);
                updateCmd.Parameters.AddWithValue("@N_user", N_user);
                updateCmd.Parameters.AddWithValue("@pass", pass);
                updateCmd.Parameters.AddWithValue("@IsBest", IsBest);
                updateCmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("تم تعديل بيانات المستخدم بنجاح", "الادارة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox6.Clear();
                dateTimePicker1.Text = "";
                comboBox2.Text = "";
            }
            
        }

        int D_Now = Convert.ToUInt16(DateTime.Now.Year);
        private void button6_Click(object sender, EventArgs e)
        {
            F_Name = textBox1.Text;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("ادخل اسم الموظف للبحث", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM responsible WHERE Name_responsible = @F_Name", conn);
                cmd.Parameters.AddWithValue("@F_Name", F_Name);

                // تنفيذ الاستعلام واسترجاع البيانات
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // استرجاع البيانات من القارئ
                        string lastName = reader["LastName_responsible"].ToString();
                        string dob = reader["DOB"].ToString();
                        DateTime B_D = Convert.ToDateTime(reader["DOB"]);
                        int Age = D_Now - B_D.Year;
                        string phone = reader["Phone"].ToString();
                        string User = reader["UserName"].ToString();
                        string Password = reader["Pass"].ToString();
                        string IsBest1 = reader["Best"].ToString();
                        if(IsBest1 == "False")
                        {
                            IsBest1 = "لا";
                        }else
                            IsBest1 = "نعم";

                        string message = $"الاسم الاول : {F_Name}\n" + $"الاسم الأخير: {lastName}\n" + $"العمر : {Age.ToString() + "سنة"}\n" + $"رقم الهاتف: {phone}\n" + $"  {User} :اسم المستخدم\n" + $"كلمة السر: {Password}\n" + $" هل هو افضل موظف؟ {IsBest1}\n";

                        MessageBox.Show(message, "بيانات الموظف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على الموظف", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                }
               

            reader.Close();
            conn.Close();
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Text = "";
            comboBox2.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = true;
            }
            else
            {
                textBox3.UseSystemPasswordChar =false ;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            F_Name = textBox1.Text;
            L_Name = textBox2.Text;
            DOB = dateTimePicker1.Text;
            P_Num = textBox5.Text;
            N_user = textBox6.Text;
            pass = textBox3.Text;
            IsBest = comboBox2.Text;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||  string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) ||  string.IsNullOrWhiteSpace(comboBox2.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("يجب تعبئة كافة الحقول عند الاضافة", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO responsible(Name_responsible, LastName_responsible, DOB,Phone,UserName,Pass,Best) VALUES(@F_Name, @L_Name ,@DOB ,@P_Num,@N_user,@pass ,@IsBest)", conn);

                cmd.Parameters.AddWithValue("@F_Name", F_Name);
                cmd.Parameters.AddWithValue("@L_Name", L_Name);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@P_Num", P_Num);
                cmd.Parameters.AddWithValue("@N_user", N_user);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@IsBest", IsBest);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("تم إضافة موظف بنجاح!", "الأدارة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Text = "";
            comboBox2.Text = "";
        }
    }
}
