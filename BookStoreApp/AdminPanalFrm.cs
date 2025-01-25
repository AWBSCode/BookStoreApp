using BookStoreApp.AdminPanalFroms.ConrolUsers;
using BookStoreApp.AdminPanalFroms.ControlAdmins;
using BookStoreApp.AdminPanalFroms.ControlBooksAndAuthors;
using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class AdminPanalFrm : Form
    {
        public AdminPanalFrm()
        {
            InitializeComponent();
        }

        private void btnEditAdmin_Click(object sender, EventArgs e)
        {
            clsAdmins currentAdmin = clsAdmins.FindAdminByID(clsLoginAndSignupBussinessLayer.CurrentAdminID);
            if (currentAdmin == null || !currentAdmin.HasPermissionFor(clsAdmins.enPermissions.enAdmins))
            {
                MessageBox.Show("You don't have the persmission.");
                return;
            }

            this.Hide();
            AdminControlFrm frm = new AdminControlFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnEditUsers_Click(object sender, EventArgs e)
        {
            clsAdmins currentAdmin = clsAdmins.FindAdminByID(clsLoginAndSignupBussinessLayer.CurrentAdminID);
            if (currentAdmin == null || !currentAdmin.HasPermissionFor(clsAdmins.enPermissions.enUsers))
            {
                MessageBox.Show("You don't have the persmission.");
                return;
            }
            this.Hide();
            UsersControlPanelFrm frm = new UsersControlPanelFrm();
            frm.ShowDialog();
            this.Close();

        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            clsAdmins currentAdmin = clsAdmins.FindAdminByID(clsLoginAndSignupBussinessLayer.CurrentAdminID);
            if (currentAdmin == null || !currentAdmin.HasPermissionFor(clsAdmins.enPermissions.enUsers))
            {
                MessageBox.Show("You don't have the persmission.");
                return;
            }

            this.Hide();
            BooksListOptionsFrm frm = new BooksListOptionsFrm();
            frm.ShowDialog();
            this.Close();
        }
    }
}
