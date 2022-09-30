using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_James
{
    public partial class ViewAllQuotes : Form
    {
        private Form _mainMenu;
        public ViewAllQuotes(Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }
    }
}
