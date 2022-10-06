using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_James
{
    public partial class AddQuote : Form
    {
        private DesktopMaterial dm;
        private Rush r;
        private Form _mainMenu;
        public AddQuote(Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Desk d = new Desk(width.Value, depth.Value, (int)drawerNum.Value, dm);

            DeskQuote dq = new DeskQuote(name.Text, r, d);

            decimal price = dq.getQuotePrice();

            /*            
             *            
            get quote amount
            write quote to quotes.json
            show displayquote form
            */

  
        }

        private void AddQuote_Load(object sender, EventArgs e)
        {
            matType.DataSource = Enum.GetValues(typeof(DesktopMaterial));

            rushType.DataSource = Enum.GetValues(typeof(Rush));
        }

        private void matType_SelectedValueChanged(object sender, EventArgs e)
        {
            DesktopMaterial mat = (DesktopMaterial)matType.SelectedItem;
            dm = mat;
  
        }

        private void rushType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rush rush = (Rush)rushType.SelectedItem;
            this.r = rush;
         
        }
    }
}
