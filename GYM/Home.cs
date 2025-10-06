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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
//using static System.Collections.Specialized.BitVector32;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GYM
{
    public partial class Home : Form
    {
        public static string LoggedInUser { get; set; }
        public Home()
        {
            InitializeComponent();
        }
        
        private void Home_Load(object sender, EventArgs e)
        {
            panel11.BringToFront();

            FillComboBox();
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;


            panel12.MouseLeave += new EventHandler(Panel_X_MouseLeave);
            panel12.MouseEnter += new EventHandler(Panel_X);

            panel13.MouseLeave += new EventHandler(Panel_Sq_MouseLeave);
            panel13.MouseEnter += new EventHandler(Panel_Sq);

            panel14.MouseLeave += new EventHandler(Panel_Mi_MouseLeave);
            panel14.MouseEnter += new EventHandler(Panel_Mi);


            panel12.Click += new EventHandler(panel12_Click); 
            panel13.Click += new EventHandler(panel13_Click); 
            panel14.Click += new EventHandler(panel14_Click);

            label18.Text = DateTime.Now.ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
            conn.Open();
            //عدد المشتركين
            SqlCommand cmd = new SqlCommand("SELECT COUNT(Name) \r\nFROM Subscriber\r\nWHERE Name IS NOT NULL;",conn);
            int NumberSubscriber = (int)cmd.ExecuteScalar();   
            label19.Text = NumberSubscriber.ToString();
            //عدد الابطال 
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) \r\nFROM Subscriber\r\nWHERE Hero = 1;  ", conn);
            int NumberHero = (int)cmd1.ExecuteScalar();
            label21.Text = NumberHero.ToString();
            //عدد المتواجدين 
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) \r\nFROM Subscriber\r\nWHERE Available = 1;  \r\n  ", conn);
            int NumberAvailable = (int)cmd2.ExecuteScalar();
            label23.Text = NumberAvailable.ToString();
            //عدد المسجلين بقسم الحديد 
            SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*)\r\nFROM Subscriber\r\nWHERE Section LIKE N'%حديد%';\r\n ", conn);
            int NumberSection = (int)cmd3.ExecuteScalar();
            label27.Text = NumberSection.ToString();
            //عدد المسجلين بقسم اللياقة 
            SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*)\r\nFROM Subscriber\r\nWHERE Section LIKE N'%لياقة%';\r\n ", conn);
            int NumberSection1 = (int)cmd4.ExecuteScalar();
            label28.Text = NumberSection1.ToString();
            //عدد المسجلين بقسم الملاكمة 
            SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*)\r\nFROM Subscriber\r\nWHERE Section LIKE N'%ملاكمة%';\r\n ", conn);
            int NumberSection2 = (int)cmd5.ExecuteScalar();
            label26.Text = NumberSection2.ToString();



            //if (WindowState == FormWindowState.Maximized)
            //{
            //    panel23.Location = new Point(380, 150);

            //}
            if (LoggedInUser == "Admin")
            {
                pictureBox2.BackgroundImage = Image.FromFile("D:\\projects\\م.مهند\\Imge\\Admin3.jpg");
            }
            else if(LoggedInUser == "Ahmed")
            {
                pictureBox2.BackgroundImage = Image.FromFile("D:\\projects\\م.مهند\\Imge\\Sul.jpg");

            }

            label31.Text= LoggedInUser + " :مرحباً"  ;




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        bool sidebar;
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebar) 
            {
                //if sidebar is MaximumSize
                flowLayoutPanel1.Width -= 10;

                if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width )
                { 
                    
                    sidebar=false;
                    
                    sidebarTimer.Stop();
                    
                }
            }
            else
            {
                //if sidebar is MinimumSize 
                flowLayoutPanel1.Width += 10;

                if(flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
                {
                    sidebar=true;
                    
                    sidebarTimer.Stop();

                }
            }

        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            
            panel11.BringToFront();
            label8.Text = "      قسم العملاء";
        }


        private void label3_Click(object sender, EventArgs e)
        {
            //Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            panel10.BringToFront();
            label8.Text = "      المشتركين";


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Name,LastName,Phone,Finsh_Date,Coach,National_ID\r\nFROM Subscriber\r\nWHERE Section LIKE N'%لياقة%'; ", conn);
            SqlCommand cmd1 = new SqlCommand("SELECT Name,LastName,Phone,Finsh_Date,Coach,National_ID\r\nFROM Subscriber\r\nWHERE Section LIKE N'%حديد%';", conn);
            SqlCommand cmd2 = new SqlCommand("SELECT Name,LastName,Phone,Finsh_Date,Coach,National_ID\r\nFROM Subscriber\r\nWHERE Section LIKE N'%ملاكمة%';", conn);

            //استخدام SqlDataAdapter لتحميل البيانات
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);

            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);

            // DataTable ب dataGridView ربط 
            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table1;
            dataGridView3.DataSource = table2;
            conn.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        
        int price=14000;
        private void label12_Click(object sender, EventArgs e)
        {

          
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel7.BringToFront();
            label8.Text = "      الاشتراكات";



        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            
          
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                label15.Visible = true;
                comboBox2.Visible = true;
            }
            else
            {
                label15.Visible = false;
                comboBox2.Visible = false;
            }
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            
            if (radioButton3.Checked)
            {

                // هذا عشان تجيب تاريخ انتهاء الاشتراك
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker2.Text = dateTimePicker2.Value.ToString();
                DateExit = dateTimePicker2.Value.AddMonths(6).ToString();
                dateTimePicker3.Text = DateExit;
                //هذا عشان تجيب سعر الاشتراك
                label12.Text = Convert.ToString(price * 6) + " RY";

                if (radioButton3.Checked && radioButton5.Checked)
                {
                    int a = (price * 6) + 10000;
                    label12.Text = a.ToString() + " RY";
                }
                

            }
            

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {

                // هذا عشان تجيب تاريخ انتهاء الاشتراك
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker2.Text = dateTimePicker2.Value.ToString();
                DateExit = dateTimePicker2.Value.AddMonths(3).ToString();
                dateTimePicker3.Text = DateExit;

                //هذا عشان تجيب سعر الاشتراك
                label12.Text = Convert.ToString(price * 3) + " RY";

                if (radioButton2.Checked && radioButton5.Checked)
                {
                    int a = (price * 3) + 10000;
                    label12.Text = a.ToString()+" RY";
                }
                

            }
        }
        string DateExit;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // هذا عشان تجيب تاريخ انتهاء الاشتراك
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker2.Text = dateTimePicker2.Value.ToString();
                DateExit = dateTimePicker2.Value.AddMonths(1).ToString();
                dateTimePicker3.Text = DateExit;

                //هذا عشان تجيب سعر الاشتراك
                label12.Text = Convert.ToString(price * 1) + " RY";

                if (radioButton1.Checked && radioButton5.Checked)
                {
                    int a = (price * 1) + 10000;
                    label12.Text = a.ToString()+" RY";
                }
                
            }
        }
        string F_Name, L_Name, DOB, Dep, N_Id, P_Num, Section,N_Coach,S_date,F_date,Price;

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            //Close();
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
                Location=new Point( 356,146);
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
        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
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

        private void panel11_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
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

        private void label31_Click(object sender, EventArgs e)
        {

        }
        string lastName;
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM Subscriber WHERE Name = @F_Name", conn);
                cmd.Parameters.AddWithValue("@F_Name", F_Name);

                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                         lastName = reader["LastName"].ToString();
                        string dob = reader["DOB"].ToString();
                        DateTime B_D = Convert.ToDateTime(reader["DOB"]);
                        int Age = D_Now - B_D.Year;
                        string phone = reader["Phone"].ToString();
                        string nationalId = reader["National_ID"].ToString();
                        string section = reader["Section"].ToString();
                        string coach = reader["Coach"].ToString();
                        DateTime sDate = Convert.ToDateTime(reader["Start_Date"]);
                        DateTime fDate = Convert.ToDateTime(reader["Finsh_Date"]);
                        string price_ = reader["Price"].ToString();

                        string message = $"الاسم الاول : {F_Name}\n" + $"الاسم الأخير: {lastName}\n" + $"العمر : {Age.ToString() + "سنة"}\n" + $"رقم الهاتف: {phone}\n" + $"الهوية الوطنية: {nationalId}\n" + $"القسم: {section}\n" + $"المدرب: {coach}\n" + $"تاريخ البدء: {sDate.ToString("yyyy-MM-dd")}\n" + $"تاريخ انتهاء الاشتراك: {fDate.ToString("yyyy-MM-dd")}\n" + price_ + " : السعر ";

                        DialogResult result = MessageBox.Show(message, "هل هو العميل المطلوب؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            textBox1.Text = F_Name;
                            textBox2.Text = lastName;
                            dateTimePicker1.Text = dob;
                            textBox5.Text = phone;
                            textBox6.Text = nationalId;
                            comboBox1.Text = section;
                            comboBox2.Text = coach;
                            dateTimePicker2.Text = sDate.ToString("yyyy-MM-dd");
                            dateTimePicker3.Text = fDate.ToString("yyyy-MM-dd");
                            label12.Text= price_;
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على العميل", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على العميل", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
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
                N_Id = textBox6.Text;
                Section = comboBox1.Text;
                N_Coach = comboBox2.Text;
                S_date = dateTimePicker2.Text;
                F_date = dateTimePicker3.Text;
                Price = label12.Text;
                SqlCommand updateCmd = new SqlCommand("UPDATE Subscriber SET LastName = @L_Name, DOB = @DOB, Phone = @P_Num, National_ID = @N_Id, Section = @Section, Coach = @N_Coach, Start_Date = @S_date, Finsh_Date = @F_date, Price = @Price WHERE Name = @F_Name", conn); 
                updateCmd.Parameters.AddWithValue("@F_Name", F_Name);
                updateCmd.Parameters.AddWithValue("@L_Name", L_Name); 
                updateCmd.Parameters.AddWithValue("@DOB",DOB); 
                updateCmd.Parameters.AddWithValue("@P_Num", P_Num); 
                updateCmd.Parameters.AddWithValue("@N_Id", N_Id);
                updateCmd.Parameters.AddWithValue("@Section", Section); 
                updateCmd.Parameters.AddWithValue("@N_Coach", N_Coach); 
                updateCmd.Parameters.AddWithValue("@S_date", S_date);
                updateCmd.Parameters.AddWithValue("@F_date", F_date);
                updateCmd.Parameters.AddWithValue("@Price", Price);
                updateCmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("تم تعديل بيانات العميل بنجاح", "الادارة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string N_Id = textBox6.Text;
            if (string.IsNullOrWhiteSpace(N_Id))
            {
                MessageBox.Show("ادخل رقم الهوية العميل", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Subscriber WHERE National_ID = @N_Id", conn);
                cmd.Parameters.AddWithValue("@N_Id", N_Id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    string FirstName = "";
                    string LastName = "";
                    DateTime B_D = DateTime.MinValue;
                    int Age = 0;
                    string Phone = "";
                    string Section = "";
                    string Coach = "";
                    DateTime SDate = DateTime.MinValue;
                    DateTime FDate = DateTime.MinValue;
                    string Price = "";

                    while (reader.Read())
                    {
                        FirstName = reader["Name"].ToString();
                        LastName = reader["LastName"].ToString();
                        B_D = Convert.ToDateTime(reader["DOB"]);
                        Age = DateTime.Now.Year - B_D.Year;
                        Phone = reader["Phone"].ToString();
                        Section = reader["Section"].ToString();
                        Coach = reader["Coach"].ToString();
                        SDate = Convert.ToDateTime(reader["Start_Date"]);
                        FDate = Convert.ToDateTime(reader["Finsh_Date"]);
                        Price = reader["Price"].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    string message = $"الاسم الاول : {FirstName}\n" +
                                     $"الاسم الأخير: {LastName}\n" +
                                     $"العمر : {Age} سنة\n" +
                                     $"رقم الهاتف: {Phone}\n" +
                                     $"الهوية الوطنية: {N_Id}\n" +
                                     $"القسم: {Section}\n" +
                                     $"المدرب: {Coach}\n" +
                                     $"تاريخ البدء: {SDate:yyyy-MM-dd}\n" +
                                     $"تاريخ انتهاء الاشتراك: {FDate:yyyy-MM-dd}\n" +
                                     $"السعر : {Price}";

                    DialogResult result = MessageBox.Show(message, "هل تريد الغاء اشتراكه؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand deleteCmd = new SqlCommand("DELETE FROM Subscriber WHERE National_ID = @N_Id", conn);
                        deleteCmd.Parameters.AddWithValue("@N_Id", N_Id);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("تم حذف المشترك بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("حدث خطأ أثناء حذف المشترك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close(); 
                    }
                }
                else
                {
                    MessageBox.Show("لا يوجد رقم هوية مطابق", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                }

                reader.Close();
                conn.Close();
            }


        }

        int D_Now = Convert.ToUInt16(DateTime.Now.Year);
        private void button6_Click(object sender, EventArgs e)
        {

            F_Name = textBox1.Text;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("ادخل اسم العميل للبحث", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Subscriber WHERE Name = @F_Name", conn); 
                cmd.Parameters.AddWithValue("@F_Name", F_Name);

                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while( reader.Read() ) 
                   {
                        
                        string lastName = reader["LastName"].ToString(); 
                        string dob = reader["DOB"].ToString();
                        DateTime B_D = Convert.ToDateTime(reader["DOB"]);
                        int Age = D_Now - B_D.Year ;
                        string phone = reader["Phone"].ToString(); 
                        string nationalId = reader["National_ID"].ToString();
                        string section = reader["Section"].ToString(); 
                        string coach = reader["Coach"].ToString();
                        DateTime sDate = Convert.ToDateTime(reader["Start_Date"]);
                        DateTime fDate = Convert.ToDateTime(reader["Finsh_Date"]);
                        string price_ = reader["Price"].ToString();
                       
                        string message = $"الاسم الاول : {F_Name}\n" + $"الاسم الأخير: {lastName}\n" + $"العمر : {Age.ToString()+"سنة"}\n" + $"رقم الهاتف: {phone}\n" + $"الهوية الوطنية: {nationalId}\n" + $"القسم: {section}\n" + $"المدرب: {coach}\n" + $"تاريخ البدء: {sDate.ToString("yyyy-MM-dd")}\n" + $"تاريخ انتهاء الاشتراك: {fDate.ToString("yyyy-MM-dd")}\n" +price_ + " : السعر ";
                       
                        MessageBox.Show(message, "بيانات العميل", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                } 
                else
                {
                    MessageBox.Show("لم يتم العثور على العميل", "نتيجة البحث", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information); 
                } 
                  
                  reader.Close();
                  conn.Close();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            F_Name = textBox1.Text;
            L_Name = textBox2.Text;
            DOB = dateTimePicker1.Text;
            P_Num = textBox5.Text;
            N_Id = textBox6.Text;
            Section = comboBox1.Text;
            N_Coach=comboBox2.Text;
            S_date=dateTimePicker2.Text;
            F_date=dateTimePicker3.Text;
            Price=label12.Text;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(dateTimePicker2.Text) || string.IsNullOrWhiteSpace(dateTimePicker3.Text) || string.IsNullOrWhiteSpace(label12.Text))
            {
                MessageBox.Show("يجب تعبئة كافة الحقول عند الاضافة", "خطأ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Subscriber(Name, LastName, DOB,Phone,National_ID,Section,Coach,Start_Date,Finsh_Date,price) VALUES(@F_Name, @L_Name ,@DOB ,@P_Num ,@N_Id, @Section,@N_Coach,@S_date,@F_date,@Price)", conn);

                cmd.Parameters.AddWithValue("@F_Name", F_Name);
                cmd.Parameters.AddWithValue("@L_Name", L_Name);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@N_Id", N_Id);
                cmd.Parameters.AddWithValue("@P_Num", P_Num);
                cmd.Parameters.AddWithValue("@Section", Section);
                cmd.Parameters.AddWithValue("@N_Coach", N_Coach);
                cmd.Parameters.AddWithValue("@S_date", S_date);
                cmd.Parameters.AddWithValue("@F_date", F_date);
                cmd.Parameters.AddWithValue("@Price", Price);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("تم إضافة المشترك بنجاح!", "الأدارة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            comboBox2.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
            label12.Text = "";
        }

private void FillComboBox()
    {
       
       
        
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=MSI\\SQLEXPRESS;database=DBGYM;integrated security=true";
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Name FROM Coach", conn);
            SqlDataReader reader = cmd.ExecuteReader();

          
            comboBox2.Items.Clear();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["Name"].ToString());
            }

            reader.Close();
            conn.Close();
        
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
