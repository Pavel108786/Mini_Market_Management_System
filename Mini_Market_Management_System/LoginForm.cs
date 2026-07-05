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
using System.Configuration;

namespace Mini_Market_Management_System
{
    public partial class LoginForm : Form


    {
        DBConnect dBCon = new DBConnect();
        public static string sellerName;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.DarkGreen;
        }

        private void Button_clear_MouseEnter(object sender, EventArgs e)
        {
            Button_clear.ForeColor = Color.Red;
        }

        private void Button_clear_MouseLeave(object sender, EventArgs e)
        {
            Button_clear.ForeColor= Color.DarkGreen;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            TextBox_username.Clear();
            TextBox_password.Clear();
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (TextBox_username.Text == "" || TextBox_password.Text == "")
            {
                MessageBox.Show("Please Enter  Username And Password", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            { 
                if (comboBox_role.SelectedIndex > -1)
                {

                    if (comboBox_role.SelectedItem.ToString() == "ADMIN")
                    {
                        SqlCommand cmd = new SqlCommand(
     "SELECT * FROM AdminTbl WHERE AdminName=@name AND AdminPass=@pass",
     dBCon.GetCon());

                        cmd.Parameters.AddWithValue("@name", TextBox_username.Text);
                        cmd.Parameters.AddWithValue("@pass", TextBox_password.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            ProductForm product = new ProductForm();
                            product.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Admin Username or Password");
                        }

                    }
                    else
                    {
                                        // string selectQuery = "SELECT * FROM Seller WHERE SellerName ='" + TextBox_username.Text + "' AND SellerPass='" + TextBox_password.Text + "'  ";

                                           
                                        //SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, dBCon.GetCon());

                                        //DataTable table = new DataTable();

                                        //adapter.Fill(table);
                                        //if (table.Rows.Count > 0)
                                        //{
                                        //    sellerName = TextBox_username.Text;
                                        //    SellingForm selling = new SellingForm();
                                        //    selling.Show();
                                        //    this.Hide();
                                        //}
                                        //else
                                        //{
                                        //    MessageBox.Show("Wrong Username or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //}

                     SqlCommand cmd = new SqlCommand("SELECT * FROM Seller WHERE SellerName=@name AND SellerPass=@pass",dBCon.GetCon());

                    cmd.Parameters.AddWithValue("@name", TextBox_username.Text);
                    cmd.Parameters.AddWithValue("@pass", TextBox_password.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        sellerName = TextBox_username.Text;
                        SellingForm selling = new SellingForm();
                        selling.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    }
                }
                else
                {
                    MessageBox.Show("Please Select Role", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void Label_admin_MouseEnter(object sender, EventArgs e)
        {
            Label_admin.ForeColor = Color.Blue;
        }

        private void Label_admin_MouseLeave(object sender, EventArgs e)
        {
            Label_admin.ForeColor = Color.DarkOliveGreen;
        }

        private void Label_admin_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            db.OpenCon();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM AdminTbl", db.GetCon());

            int count = (int)cmd.ExecuteScalar();

            db.CloseCon();

            if (count == 0)
            {
                SignupForm signup = new SignupForm();
                signup.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Admin account already exists.");
            }
        }

        
    }
}
