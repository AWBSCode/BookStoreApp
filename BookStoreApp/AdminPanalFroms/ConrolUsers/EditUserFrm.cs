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
        int ID;
        public EditUserFrm(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsUsers userData = new BussinessLayer.clsUsers();
            
            userData.UserID = ID;
            userData.Name = tbName.Text; 
            userData.Phone = tbPhone.Text;
            userData.Email = tbEmail.Text;
            userData.Password = tbPassword.Text;
            userData.PersonId = PersonID;

            bool isUpdated = userData.Save();

            if (isUpdated)
            {
                MessageBox.Show("Updated Successfully!");
            } else
            {
                MessageBox.Show("Updating Failed!");
            }
        }

        private void EditUserFrm_Load(object sender, EventArgs e)
        {
            BussinessLayer.clsUsers userData = BussinessLayer.clsUsers.FindUserByID(ID);
            tbName.Text = userData.Name;
            tbPhone.Text = userData.Phone;
            tbEmail.Text = userData.Email;
            tbPassword.Text = userData.Password;
            PersonID = userData.PersonId;
        }
    }
}
