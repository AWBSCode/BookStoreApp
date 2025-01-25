using BussinessLayer;
using System;
using System.Windows.Forms;

namespace BookStoreApp.AdminPanalFroms.ControlAdmins
{
    public partial class EditAdminFrm : Form
    {
        int ID;
        public EditAdminFrm(int id)
        {
            InitializeComponent();
            ID = id;
            btnChooseID_Click();
        }

        int personId = 0;

        private void btnChooseID_Click()
        {
            clsAdmins userData = clsAdmins.FindAdminByID(ID);
            tbName.Text = userData.Name;
            tbPhone.Text = userData.Phone;
            tbEmail.Text = userData.Email;
            tbPassword.Text = userData.Password;
            personId = userData.PersonId;

            if (userData.HasPermissionFor(clsAdmins.enPermissions.enUsers))
            {
                cbUserPerm.Checked = true;
            } else
            {
                cbUserPerm.Checked = false;
            }

            if (userData.HasPermissionFor(clsAdmins.enPermissions.enBook))
            {
                cbBookPerm.Checked = true;
            } else { 
                cbBookPerm.Checked = false;
            }

            if (userData.HasPermissionFor(clsAdmins.enPermissions.enAdmins))
            {
                cbAdminPerm.Checked = true;
            } else
            {
                cbAdminPerm.Checked = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int code = clsAdmins.GetPermissionCode(cbUserPerm.Checked, cbBookPerm.Checked, cbAdminPerm.Checked);
            clsAdmins userData = new clsAdmins(
                ID,
                code,
                personId,
                tbName.Text,
                tbPassword.Text,
                tbEmail.Text,
                tbPhone.Text
            );


            bool isUpdated = userData.SaveUpdate();

            if (isUpdated)
            {
                MessageBox.Show("Updated Successfully!");
            }
            else
            {
                MessageBox.Show("Updating Failed!");
            }
        }
    }
}
