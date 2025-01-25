using BookStoreApp.util;
using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace BookStoreApp.AdminPanalFroms.ControlAdmins
{
    public partial class AdminControlFrm : Form
    {
        public AdminControlFrm()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            BussinessLayer.clsAdmins admin = clsAdmins.FindAdminByID(clsLoginAndSignupBussinessLayer.CurrentAdminID);
            guna2DataGridView1.DataSource = admin.GetAllAdmins();
        }

        private void AdminControlFrm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private int selectID()
        {
            int RowIndex = guna2DataGridView1.CurrentCell.RowIndex;
            int ID = (int)guna2DataGridView1.Rows[RowIndex].Cells[0].Value;
            return ID;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = selectID();

            EditAdminFrm frm = new EditAdminFrm(ID);
            frm.ShowDialog();
            _LoadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = selectID();
            UtilActions._DeleteAdmin(ID);
            _LoadData();
        }

        private void _AddAdmin()
        {
            clsAdmins admin = new clsAdmins(-1,
                clsAdmins.GetPermissionCode(cbUserPerm.Checked, cbBookPerm.Checked, cbAdminPerm.Checked),
            -1,
                tbName.Text,
                tbPassword.Text,
                tbEmail.Text,
                tbPhone.Text
            );
            bool isSaved = admin.AddNewAndSave();
            if (isSaved)
            {
                MessageBox.Show("Add Successfully");
            }
        }

        private void _ClearTextBoxs()
        {
            tbName.Clear();
            tbEmail.Clear();
            tbPassword.Clear();
            tbPhone.Clear();
        }

        private void _ClearForm()
        {
            _ClearTextBoxs();
            cbAdminPerm.Checked = false;
            cbBookPerm.Checked = false;
            cbUserPerm.Checked = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            _AddAdmin();
            _LoadData();
            _ClearForm();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int id = (int)guna2NumericUpDown1.Value;
            FindAdminFrm frm = new FindAdminFrm(id);
            frm.ShowDialog();
            _LoadData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            util.UtilActions._GoBackToMainPanel(this);
        }
    }
}
