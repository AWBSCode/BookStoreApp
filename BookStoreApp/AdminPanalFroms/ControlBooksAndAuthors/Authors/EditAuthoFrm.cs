using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;

namespace BookStoreApp.AdminPanalFroms.ControlBooksAndAuthors.Authors
{
    public partial class EditAuthoFrm : Form
    {
        int ID;
        public EditAuthoFrm(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private int PersonID = -1;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            clsAuthors author = clsAuthors.FindAuthor(ID);
            
            tbName.Text = author.Name;
            tbEmail.Text = author.Email;
            tbPhone.Text = author.Phone;
            guna2NumericUpDown1.Value = author.Rate;
            PersonID = author.PersonId;
        }
        
        // save changes
        private void button1_Click(object sender, EventArgs e)
        {
            clsAuthors author = new clsAuthors(ID, PersonID, tbName.Text, tbEmail.Text, tbPhone.Text, (int)guna2NumericUpDown1.Value);
            bool isUpdated = author.UpdateSave();
            if (isUpdated)
            {
                MessageBox.Show("Success");
            } else
            {
                MessageBox.Show("Failed"); 
            }
        }
    }
}
