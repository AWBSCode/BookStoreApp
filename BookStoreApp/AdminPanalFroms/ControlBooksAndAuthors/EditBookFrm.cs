using BussinessLayer;
using System;
using System.Windows.Forms;

namespace BookStoreApp.AdminPanalFroms.ControlBooksAndAuthors
{
    public partial class EditBookFrm : Form
    {
        int ID;
        public EditBookFrm(int id)
        {
            InitializeComponent();
            ID = id;
        }

        int Rate;
        bool Changed = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string author = (string)cbAuthor.SelectedItem;

            foreach (ListViewItem item in authorsList.Items)
            {
                if (item.Text == author)
                {
                    MessageBox.Show("This author already exists.");
                    return;
                }
            }

            authorsList.Items.Add(author);
            Changed = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (authorsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please, Select a row to remove.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (authorsList.Items.Count == 0) return;

            authorsList.Items.Remove(authorsList.SelectedItems[0]);
            Changed = true;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (authorsList.Items.Count <= 0)
            {
                MessageBox.Show("Can't update with empty author list");
                return;
            }

            clsBooks book = new clsBooks(ID, tbTitle.Text, (int)numPrice.Value, (int)numCopies.Value, "", Rate);
            bool isUpdated = book.SaveUpdate();

            if (!isUpdated)
            {
                MessageBox.Show("Field to update book data");
                return;
            }

            if (!Changed)
            {
                MessageBox.Show("Success!");
            }

            

            if (!book.DeleteAllAuthorsCombos())
            {
                MessageBox.Show("Can't Do This");
            }


            foreach (ListViewItem authorItem in authorsList.Items)
            {
                int id = clsAuthors.FindAuthor(authorItem.Text).AuthorID;
                if (id > 0)
                {
                    book.AddAuthorToTheBook(id);
                }
                else
                {
                    MessageBox.Show($"Can't Add Author {authorItem.Text}");
                }
            }

            MessageBox.Show("Success!");
        }

        private void EditBookFrm_Load(object sender, EventArgs e)
        {
            clsBooks Book = clsBooks.FindBook(ID);

            if (Book == null)
            {
                MessageBox.Show("Could not find the book.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tbTitle.Text = Book.Title;
            numCopies.Value = Book.CountOfCopies;
            numPrice.Value = Book.Price;
            Rate = Book.AuthorsAverageRate;

            string[] authorsNames = Book.Authors.Split(',');

            authorsList.Items.Clear();

            foreach (string authorName in authorsNames)
            {
                authorsList.Items.Add(authorName.TrimStart());
            }


            foreach (var item in clsAuthors.GetAuthorsList())
            {
                cbAuthor.Items.Add(item);
            }
        }

    }  
}
