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

namespace BookStoreApp.AdminPanalFroms.ControlBooksAndAuthors.Authors
{
    public partial class AuthorsPanelFrm : Form
    {
        public AuthorsPanelFrm()
        {
            InitializeComponent();
        }
            
        private void _LoadAuthors()
        {
            guna2DataGridView1.DataSource = clsAuthors.GetAllAuthors();
        }

        private void AuthorsPanelFrm_Load(object sender, EventArgs e)
        {
            _LoadAuthors();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = selectID();
            EditAuthoFrm frm = new EditAuthoFrm(id);
            frm.ShowDialog();
            _LoadAuthors();
        }

        private int selectID()
        {
            int RowIndex = guna2DataGridView1.CurrentCell.RowIndex;
            int ID = (int)guna2DataGridView1.Rows[RowIndex].Cells[0].Value;
            return ID;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = selectID();
            util.UtilActions._DeleteAuthor(id);
            _LoadAuthors();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ID = (int)numUserID.Value;
            FindAuthorFrm frm = new FindAuthorFrm(ID);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsAuthors author = new clsAuthors(-1, -1, tbName.Text, tbEmail.Text, tbPhone.Text, (int)guna2NumericUpDown1.Value);
            util.UtilActions._AddAuthor(author);
            _LoadAuthors();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksListOptionsFrm frm = new BooksListOptionsFrm();
            frm.ShowDialog();
            this.Close();
        }
    }
}
