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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnAddQuote_Click(object sender, EventArgs e)
        {
            // create and show add quote form
            var addQuote = new AddQuote(this);
            addQuote.Show();

            // hide main menu
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewQuotes_Click(object sender, EventArgs e)
        {
            var viewQuote = new ViewAllQuotes(this);
            viewQuote.Show();

            this.Hide();
        }

        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            var searchQuotes = new SearchQuotes(this);
            searchQuotes.Show();

            this.Hide();
        }
    }
}
