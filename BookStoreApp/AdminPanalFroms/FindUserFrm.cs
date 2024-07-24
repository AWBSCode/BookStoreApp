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
    public partial class FindUserFrm : Form
    {
        public FindUserFrm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsUsers.stUser UserData = BussinessLayer.clsUsers.GetUserByID((int)numUserId.Value);

            lblPersonID.Text = UserData.PersonID.ToString();
            lblName.Text = UserData.Name;
            lblPhone.Text = UserData.Phone;
            lblEmail.Text = UserData.Email;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
