using System;
using System.Windows.Forms;
using BussinessLayer;

namespace BookStoreApp.AdminPanalFroms.ControlBooksAndAuthors
{
    public partial class FindBookFrm : Form
    {
        int ID;
        public FindBookFrm(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsBooks Book = clsBooks.FindBook(ID);
            
            if (Book == null)
            {
                MessageBox.Show("Couldn't find the book");
                return;
            }

            lblTitle.Text = Book.Title;
            lblPrice.Text = Book.Price.ToString();
            lblCopies.Text = Book.CountOfCopies.ToString();
            lblAuthor.Text = Book.Authors;
            lblRate.Text = Book.AuthorsAverageRate.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditBookFrm frm = new EditBookFrm(ID);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            util.UtilActions._DeleteBook(ID);
        }
    }
}
