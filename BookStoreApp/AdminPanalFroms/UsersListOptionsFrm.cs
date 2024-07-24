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
    public partial class UsersListOptionsFrm : Form
    {
        public UsersListOptionsFrm()
        {
            InitializeComponent();
        }

        private void btnListUsers_Click(object sender, EventArgs e)
        {
            ListUsersFrm theForm = new ListUsersFrm();
            theForm.ShowDialog();
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            FindUserFrm frm = new FindUserFrm();
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditUserFrm frm = new EditUserFrm();
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteUserFrm frm = new DeleteUserFrm();
            frm.ShowDialog();
        }
    }
}
