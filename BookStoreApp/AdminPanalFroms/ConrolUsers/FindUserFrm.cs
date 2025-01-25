using BookStoreApp.util;
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
        int ID;
        public FindUserFrm(int id)
        {
            InitializeComponent();
             ID = id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindUserFrm_Load(object sender, EventArgs e)
        {
            BussinessLayer.clsUsers UserData = BussinessLayer.clsUsers.FindUserByID(ID);

            lblPersonID.Text = UserData.PersonId.ToString();
            lblName.Text = UserData.Name;
            lblPhone.Text = UserData.Phone;
            lblEmail.Text = UserData.Email;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UtilActions._DeleteUser(ID);
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditUserFrm frm = new EditUserFrm(ID);
            frm.ShowDialog();
        }
    }
}
