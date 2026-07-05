using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mini_Market_Management_System
{
    public partial class SignupForm : Form
    {
        DBConnect dBCon = new DBConnect();
        // Database Connection String
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MarketDb.mdf;Integrated Security=True");
        //string vCode; // To store OTP

        public SignupForm()
        {
            InitializeComponent();
        }

        // Button to send OTP to Email
        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email address first.");
                return;
            }

            try
            {
                Random rand = new Random();
               // vCode = rand.Next(1000, 9999).ToString(); // 4 Digit Code

                SmtpClient smtp = new SmtpClient("://gmail.com", 587)
                {
                    Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password"),
                    EnableSsl = true
                };

                // Sending Email
               // smtp.Send("your-email@gmail.com", txtEmail.Text, "Admin Verification Code", "Your verification code is: " + vCode);

                MessageBox.Show("Verification code has been sent to your email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email. Error: " + ex.Message);
            }
        }

        // Button to complete Registration
        
            // Verify OTP
            // if (txtOTP.Text == vCode && !string.IsNullOrEmpty(vCode))

           
                    

                   
                
                
             

                

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtName_MouseEnter(object sender, EventArgs e)
        {
            nameLine.Visible = true;
            nameLine.BackColor = Color.LimeGreen;
        }

        private void txtName_MouseLeave(object sender, EventArgs e)
        {
            nameLine.Visible = false;
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)//re pass
        {

        }

      
            private void signupbtn_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || textBox1.Text == "" || txtRePass.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (textBox1.Text != txtRePass.Text)
            {
                MessageBox.Show("Password does not match.");
                return;
            }

            dBCon.OpenCon();

            // Check if Admin already exists
            SqlCommand checkAdmin = new SqlCommand("SELECT COUNT(*) FROM AdminTbl", dBCon.GetCon());

            int adminCount = (int)checkAdmin.ExecuteScalar();

            if (adminCount > 0)
            {
                MessageBox.Show("Admin already exists.");
                dBCon.CloseCon();
                return;
            }

            // Check duplicate email
            SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM AdminTbl WHERE AdminEmail=@email", dBCon.GetCon());
            checkEmail.Parameters.AddWithValue("@email", txtEmail.Text);

            int emailCount = (int)checkEmail.ExecuteScalar();

            if (emailCount > 0)
            {
                MessageBox.Show("Email already exists.");
                dBCon.CloseCon();
                return;
            }

            // Insert Admin
            SqlCommand cmd = new SqlCommand("INSERT INTO AdminTbl(AdminName,AdminEmail,AdminPass) VALUES(@name,@email,@pass)", dBCon.GetCon());

            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@pass", textBox1.Text);

            cmd.ExecuteNonQuery();

            dBCon.CloseCon();

            MessageBox.Show("Registration Successful.");

            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Gainsboro;
        }
    }
}

