using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreApp.AdminPanalFroms
{
    public partial class EditUserFrm : Form
    {
        int PersonID = 0;

        public EditUserFrm()
        {
            InitializeComponent();
        }

        private void numUserId_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void EditUserFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseID_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsUsers.stUser userData = BussinessLayer.clsUsers.GetUserByID((int)numUserId.Value);
            tbName.Text = userData.Name;
            tbPhone.Text = userData.Phone;
            tbEmail.Text = userData.Email;
            tbPassword.Text = userData.Password;
            PersonID = userData.PersonID;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsUsers.stUser userData = new DataAccessLayer.clsUser.stUser();
            
            userData.UserID = (int)numUserId.Value;
            userData.Name = tbName.Text; 
            userData.Phone = tbPhone.Text;
            userData.Email = tbEmail.Text;
            userData.Password = tbPassword.Text;
            userData.PersonID = PersonID;

            bool isUpdated = BussinessLayer.clsUsers.UpdateUser(userData);

            if (isUpdated)
            {
                MessageBox.Show("Updated Successfully!");
            } else
            {
                MessageBox.Show("Updating Failed!");
            }
        }
    }
}
