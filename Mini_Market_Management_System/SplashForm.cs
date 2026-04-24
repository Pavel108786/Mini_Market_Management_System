using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Market_Management_System
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

private void SplashForm_Load_1(object sender,EventArgs e)
        {
            timer1.Start();
        }
//private void PictureBox_load(object sender, EventArgs e)
//        {
//            timer1.Start();
//        }
         
        int startPoint = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startPoint += 2;
            ProgressBar.Value = startPoint;
            if(ProgressBar.Value == 100)
            {
                ProgressBar.Value = 0;
                timer1.Stop();
                LoginForm loginform = new LoginForm();
                this.Hide();
                loginform.Show();
            }
        }

        private void ProgressBar_ValueChanged(object sender, EventArgs e)
        {

        }

        

        //private void SplashForm_Load_1(object sender, EventArgs e)
        //{
        //    timer1.Start();
        //}
    }
}
