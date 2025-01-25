using BookStoreApp.AdminPanalFroms.ControlBooksAndAuthors.Authors;
using BussinessLayer;
using DataAccessLayer;
using System;
using System.Windows.Forms;

namespace BookStoreApp.AdminPanalFroms.ControlBooksAndAuthors
{
    public partial class BooksListOptionsFrm : Form
    {
        public BooksListOptionsFrm()
        {
            InitializeComponent();
        }

        private void _LoadBooks()
        {
            guna2DataGridView1.DataSource = clsBooks.GetAllBooks();
        }
        
        private int selectID()
        {
            int RowIndex = guna2DataGridView1.CurrentCell.RowIndex;
            int ID = (int)guna2DataGridView1.Rows[RowIndex].Cells[0].Value;
            return ID;
        }

        private void BooksListOptionsFrm_Load(object sender, EventArgs e)
        {
            _LoadBooks();
            foreach (var item in clsAuthors.GetAuthorsList())
            {
                cbAuthors.Items.Add(item);
            }
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            string author = (string)cbAuthors.SelectedItem;

            if (author == "Add new author")
            {
                AddAuthorFrm frm = new AddAuthorFrm();
                frm.ShowDialog();
                author = clsAuthors.GetLatestAddedAuthorName();
                cbAuthors.Items.Add(author);
            }

            if (author == "")
            {
                MessageBox.Show("Please, Select author to add");
                return;
            }

            foreach (ListViewItem item in authorsList.Items)
            {
                if (item.Text == author)
                {
                    MessageBox.Show("This author already exists.");
                    return;
                }
            }

            authorsList.Items.Add(author);
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (authorsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please, Select a row to remove.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (authorsList.Items.Count == 0) return;

            authorsList.Items.Remove(authorsList.SelectedItems[0]);
        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            if (authorsList.Items.Count == 0)
            {
                MessageBox.Show("Please, Add Author(s) to the book");
                return;
            }

            clsBooks newBook = new clsBooks(-1, tbTitle.Text, (int)numPrice.Value, (int)numQuantity.Value, "", 0);

            if (!newBook.SaveAdd())
            {
                MessageBox.Show("Failed");
                return;
            }

            foreach (ListViewItem item in authorsList.Items)
            {
                int id = clsAuthors.FindAuthor(item.Text).AuthorID;
                newBook.AddAuthorToTheBook(id);
            }

            MessageBox.Show("Success!");
            _LoadBooks();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = selectID();

            util.UtilActions._DeleteBook(id);
            _LoadBooks();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = selectID();
            EditBookFrm frm = new EditBookFrm(id);
            frm.ShowDialog();
            _LoadBooks();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AuthorsPanelFrm frm = new AuthorsPanelFrm();
            frm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            util.UtilActions._GoBackToMainPanel(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = (int)numUserID.Value;
            FindBookFrm frm = new FindBookFrm(id);
            frm.ShowDialog();
            _LoadBooks();
        }
    }
}
