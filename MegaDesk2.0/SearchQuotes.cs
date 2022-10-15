using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_James
{
    public partial class SearchQuotes : Form
    {
        private Form _mainMenu;
        public SearchQuotes(Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            comboBox1.DataSource = Enum.GetValues(typeof(DesktopMaterial));
            comboBox1.SelectedIndex = 0;
            dataGridView1.RowHeadersVisible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }

        private void SearchQuotes_Load(object sender, EventArgs e)
        {
            var quotesFile = @"quotes.json";
            DesktopMaterial selectedMaterial = (DesktopMaterial) comboBox1.SelectedItem;

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

                    }).Where(d => d.SurfaceMaterial == selectedMaterial).ToList();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchQuotes_Load(sender, e);
        }
    }
}
