using BussinessLayer;
using System;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class SignUpFrm : Form
    {
        public SignUpFrm()
        {
            InitializeComponent();
        }


        private void LoginAdmin()
        {
            bool isSuccess = clsLoginAndSignupBussinessLayer.LoginAdmin(logEmail.Text, logPass.Text);

            if (isSuccess)
            {
                MessageBox.Show($"Admin Logged in successfully.");
                this.Hide();
                AdminPanalFrm theForm = new AdminPanalFrm();
                theForm.ShowDialog();
                this.Close();
            } else
            {
                MessageBox.Show("Username or password is wrong. Please, Try again.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginAdmin();
        }

    }
}
