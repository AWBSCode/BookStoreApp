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

        }

        private void btnEditUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanalFroms.UsersListOptionsFrm frm = new AdminPanalFroms.UsersListOptionsFrm();
            frm.ShowDialog();
            this.Close();

        }
    }
}
