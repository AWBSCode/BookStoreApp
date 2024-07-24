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

        private struct UserData      
        {
            public string Name;
            public string Password;
            public string Email;
            public string Phone;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Login
            UserData newUserData = new UserData();
            newUserData.Name = tbName.Text;
            newUserData.Email = tbEmail.Text;
            newUserData.Phone = tbPhone.Text;
            newUserData.Password = tbPassword.Text;
            
            bool isSuccess = clsLoginAndSignupBussinessLayer.UserSignup(newUserData.Name, newUserData.Phone, newUserData.Password, newUserData.Email);

            if (isSuccess)
            {
                MessageBox.Show($"User {newUserData.Name} Signed up successfully.");
                this.Hide();
                HomeFrm theForm = new HomeFrm();
                theForm.ShowDialog();
                this.Close();
                /*HomeFrm homeForm = new HomeFrm();
                homeForm.ShowDialog()*/;
            } else
            {
                MessageBox.Show("Something went worng. Rooh Shoof Codak Ya ben El-Nnass");
            }
            //MessageBox.Show($" Name: {newUserData.Name}, Phone: {newUserData.Phone}, Password: {newUserData.Password} , Email: {newUserData.Email} The ID is {id}");
        }

        private void LoginUserAndAdmin()
        {
            bool isSuccess = clsLoginAndSignupBussinessLayer.LoginUser(logEmail.Text, logPass.Text);

            if (isSuccess)
            {
                MessageBox.Show($"User Logged in successfully.");

                this.Hide();
                HomeFrm theForm = new HomeFrm();
                theForm.ShowDialog();
                this.Close();
                // TODO: Close the sign up dialog.
            }
            else
            {
                isSuccess = clsLoginAndSignupBussinessLayer.LoginAdmin(logEmail.Text, logPass.Text);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginUserAndAdmin();
        }

    }
}
