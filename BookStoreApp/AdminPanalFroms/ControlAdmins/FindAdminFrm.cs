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

namespace BookStoreApp.AdminPanalFroms.ControlAdmins
{
    public partial class FindAdminFrm : Form
    {
        int ID;
        public FindAdminFrm(int id)
        {
            InitializeComponent();
            ID = id;
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindAdminFrm_Load(object sender, EventArgs e)
        {
            BussinessLayer.clsAdmins UserData = BussinessLayer.clsAdmins.FindAdminByID(ID);

            lblPersonID.Text = UserData.PersonId.ToString();
            lblName.Text = UserData.Name;
            lblPhone.Text = UserData.Phone;
            lblEmail.Text = UserData.Email;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            EditAdminFrm frm = new EditAdminFrm(ID);
            frm.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UtilActions._DeleteAdmin(ID);
        }
    }
}
