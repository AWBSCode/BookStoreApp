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
    public partial class AddAuthorFrm : Form
    {
        public AddAuthorFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsAuthors author = new clsAuthors(-1, -1, tbName.Text, tbEmail.Text, tbPhone.Text, (int)guna2NumericUpDown1.Value);
            util.UtilActions._AddAuthor(author);
        }
    }
}
