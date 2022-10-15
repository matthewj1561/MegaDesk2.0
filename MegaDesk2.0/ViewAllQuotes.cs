using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MegaDesk_James
{
    public partial class ViewAllQuotes : Form
    {
        private Form _mainMenu;
        public ViewAllQuotes(Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            dataGridView1.RowHeadersVisible = false;
            var quotesFile = @"quotes.json";

            if (File.Exists(quotesFile))
            {
                using (StreamReader sr = new StreamReader(quotesFile))
                {
                    string quotes = sr.ReadToEnd();
                    //List<DeskQuote> deskQuotes = JsonSerializer.Deserialize<List<DeskQuote>>(quotes);
                    List<DeskQuote> deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotes);
                    dataGridView1.DataSource = deskQuotes.Select(d => new
                    {
                        Date = d.Date.ToString("MM/dd/yyyy"),
                        Customer = d.CustomerNames,
                        Depth = d.Desk.Height,
                        Width = d.Desk.Width,
                        Drawers = d.Desk.NumberOfDrawers,
                        SurfaceMaterial = d.Desk.DesktopMaterial,
                        DeliveryType = d.Rush,
                        QuoteAmount = d.QuotePrice.ToString("c")

                    }).ToList();
                }
            }
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
