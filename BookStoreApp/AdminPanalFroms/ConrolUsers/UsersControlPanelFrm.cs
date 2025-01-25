using BookStoreApp.util;
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

namespace BookStoreApp.AdminPanalFroms.ConrolUsers
{
    public partial class UsersControlPanelFrm : Form
    {
        public UsersControlPanelFrm()
        {
            InitializeComponent();
        }

        private void _ClearTextBoxs()
        {
            tbName.Clear();
            tbEmail.Clear();
            tbPassword.Clear();
            tbPhone.Clear();
        }

        private void _LoadUsers()
        {
            guna2DataGridView1.DataSource = BussinessLayer.clsUsers.GetAllUsersData();
        }

        private void UsersListOptionsFrm_Load(object sender, EventArgs e)
        {
            _LoadUsers();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            clsUsers user = new clsUsers(-1, -1, tbName.Text, tbPassword.Text, tbEmail.Text, tbPhone.Text);

            if (user.AddSave())
            {
                MessageBox.Show("User added successfully!");
                _ClearTextBoxs();
                _LoadUsers();
            }
            else
            {
                MessageBox.Show("User adding failed!");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindUserFrm frm = new FindUserFrm((int)numUserID.Value);
            frm.ShowDialog();
            _LoadUsers();
        }

        private int selectID()
        {
            int RowIndex = guna2DataGridView1.CurrentCell.RowIndex;
            int ID = (int)guna2DataGridView1.Rows[RowIndex].Cells[0].Value;
            return ID;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = selectID();
            EditUserFrm frm = new EditUserFrm(id);
            frm.ShowDialog();
            _LoadUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = selectID();
            UtilActions._DeleteUser(id);
            _LoadUsers();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            util.UtilActions._GoBackToMainPanel(this);
        }
    }
}
