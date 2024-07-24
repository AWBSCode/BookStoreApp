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
    public partial class ListUsersFrm : Form
    {
        public ListUsersFrm()
        {
            InitializeComponent();
        }

        private void ListUsersFrm_Load(object sender, EventArgs e)
        {
            dvAllUsers.DataSource = BussinessLayer.clsUsers.GetAllUsersData();
        }
    }
}
