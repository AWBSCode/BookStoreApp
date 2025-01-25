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
    public partial class FindAuthorFrm : Form
    {
        int ID;
        public FindAuthorFrm(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private void _LoadData()
        {
            clsAuthors author = clsAuthors.FindAuthor(ID);
            if (author == null)
            {
                MessageBox.Show("Not Found Yasta");
                return;
            }

            lblPersonID.Text = author.PersonId.ToString();
            lblName.Text = author.Name;
            lblEmail.Text = author.Email;
            lblPhone.Text = author.Phone;

            guna2DataGridView1.DataSource = author.GetAuthorsBooks();
        }

        private void FindAuthorFrm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditBookFrm frm = new EditBookFrm(ID);
            frm.ShowDialog();
            _LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            util.UtilActions._DeleteAuthor(ID);
            this.Close();
        }
    }
}
