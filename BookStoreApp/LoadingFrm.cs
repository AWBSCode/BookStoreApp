using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookStoreApp
{
    public partial class LoadingFrm : Form
    {
        public LoadingFrm()
        {
            InitializeComponent();
        }

        private void LoadingFrm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2ProgressBar1.Value < guna2ProgressBar1.Maximum)
            {
                guna2ProgressBar1.Value += 1;
            }
            else
            {
                timer1.Stop();
                this.Hide();
                SignUpFrm frm = new SignUpFrm();
                frm.ShowDialog();
                this.Close();
            }

        }
    }
}
