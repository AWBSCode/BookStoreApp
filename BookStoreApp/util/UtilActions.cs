using BussinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookStoreApp.util
{
    internal class UtilActions
    {
        static public void _DeleteAdmin(int id)
        {
            clsAdmins admin = clsAdmins.FindAdminByID(id);

            if (admin.PersonId == 0)
            {
                MessageBox.Show("Not Found");
                return;
            }

            if (admin.Delete())
            {
                MessageBox.Show("Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Deleted Failed");
            }
        }

        static public void _DeleteUser(int chosenID)
        {
            BussinessLayer.clsUsers userData = BussinessLayer.clsUsers.FindUserByID(chosenID);

            if (userData.UserID == chosenID)
            {
                var dialogResult = MessageBox.Show(
                    $"The User with ID {userData.UserID} and Person with ID {userData.PersonId} and Name {userData.Name} 'll be deleted.",
                    "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {
                    if (userData.Delete())
                    {
                        MessageBox.Show("Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Deleting Failed");
                    }
                }
            }
            else
            {
                MessageBox.Show($"The user with ID {chosenID} is not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void _AddAuthor(clsAuthors author)
        {
            bool isAdded = author.AddSave();
            if (isAdded)
            {
                MessageBox.Show("Success");
            }
        }

        static public void _DeleteAuthor(int id)
        {
            clsAuthors author = clsAuthors.FindAuthor(id);
            if (author != null)
            {
                var result = MessageBox.Show($"The Author {author.Name} will be deleted and his books. Are you sure?", "", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    bool isDeleted = author.DeleteAuthorAndHisBooks();
                    if (isDeleted)
                    {
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Failed");
                    }
                }
            }
        }

        static public void _GoBackToMainPanel(Form th)
        {
            th.Hide();
            AdminPanalFrm frm = new AdminPanalFrm();
            frm.ShowDialog();
            th.Close();
        }

        static public void _DeleteBook(int id)
        {
            clsBooks book = clsBooks.FindBook(id);
            if (book != null)
            {
                var dialogResult = MessageBox.Show($"Book With Title {book.Title} 'll be deleted. Are you sure?", "", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    if (book.Delete())
                    {
                        MessageBox.Show("Success!");
                        
                    }
                    else
                    {
                        MessageBox.Show("Faild!");
                    }
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND!");
            }
        }
    }
}
