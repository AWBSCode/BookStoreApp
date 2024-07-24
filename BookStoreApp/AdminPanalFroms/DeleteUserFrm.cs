using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreApp.AdminPanalFroms
{
    public partial class DeleteUserFrm : Form
    {
        public DeleteUserFrm()
        {
            InitializeComponent();
        }

        private void DeleteUserFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseID_Click(object sender, EventArgs e)
        {
            int chosenID = (int)numUserId.Value;

            BussinessLayer.clsUsers.stUser userData = BussinessLayer.clsUsers.GetUserByID(chosenID);
            
            if (userData.UserID == chosenID)
            {
                var dialogResult = MessageBox.Show(
                    $"The User with ID {userData.UserID} and Person with ID {userData.PersonID} and Name {userData.Name} 'll be deleted.", 
                    "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {
                    if (BussinessLayer.clsUsers.DeleteUser(chosenID))
                    {
                        MessageBox.Show("Deleted Successfully");
                    } else
                    {
                        MessageBox.Show("Deleting Failed");
                    }
                }
            } else
            {
                MessageBox.Show($"The user with ID {chosenID} is not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
