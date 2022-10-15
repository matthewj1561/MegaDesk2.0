using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MegaDesk_James
{
    public partial class AddQuote : Form
    {
        private DesktopMaterial dm;
        private Rush r;
        private Form _mainMenu;
        private Desk deskPricer;
        private DeskQuote deskQuotePricer;
        private System.Timers.Timer aTimer;

        private List<DeskQuote> quotes = new List<DeskQuote>();
        public AddQuote(Form mainMenu)
        {
            InitializeComponent();
            this.deskPricer = new Desk(width.Value, depth.Value, (int)drawerNum.Value, dm);

            this. deskQuotePricer  = new DeskQuote(name.Text, r, deskPricer);

            _mainMenu = mainMenu;
            var quotesFile = @"quotes.json";

            if (File.Exists(quotesFile))
            {
                using (StreamReader sr = new StreamReader(quotesFile))
                {
                    string quotesText = sr.ReadToEnd();
                    //List<DeskQuote> deskQuotes = JsonSerializer.Deserialize<List<DeskQuote>>(quotes);
                    quotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotesText);
                }
            }
        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // reset everything
            lblToast.Text = "";
            lblPriceText.Text = "Price: $";
            width.Value = 24;
            depth.Value = 12;
            drawerNum.Value = 0;
            matType.DataSource = Enum.GetValues(typeof(DesktopMaterial));
            rushType.DataSource = Enum.GetValues(typeof(Rush));
            this.aTimer.Stop();
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Desk d = new Desk(width.Value, depth.Value, (int)drawerNum.Value, dm);

            DeskQuote dq = new DeskQuote(name.Text, r, d);

            dq.GetQuotePrice();

            lblPrice.Text = dq.QuotePrice.ToString();

            lblToast.Text = "Quote Saved!";
            
            quotes.Add(dq);
            var json = JsonConvert.SerializeObject(quotes);

            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(@"quotes.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, quotes);
            }

            this.aTimer = new System.Timers.Timer();
            this.aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            this.aTimer.Interval = 3000;
            this.aTimer.Enabled = true;
      



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

            this.deskPricer.DesktopMaterial = dm;

            this.deskQuotePricer.GetQuotePrice();

            lblPrice.Text = this.deskQuotePricer.QuotePrice.ToString();
        }

        private void rushType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rush rush = (Rush)rushType.SelectedItem;
            this.r = rush;

            this.deskQuotePricer.Rush = rush;

            this.deskQuotePricer.GetQuotePrice();

            lblPrice.Text = this.deskQuotePricer.QuotePrice.ToString();




        }

        private void width_ValueChanged(object sender, EventArgs e)
        {

            this.deskPricer.Width = width.Value;

            this.deskQuotePricer.GetQuotePrice();

            lblPrice.Text = this.deskQuotePricer.QuotePrice.ToString();
        }

        private void depth_ValueChanged(object sender, EventArgs e)
        {

            this.deskPricer.Height = depth.Value;


            this.deskQuotePricer.GetQuotePrice();

            lblPrice.Text = this.deskQuotePricer.QuotePrice.ToString();
        }

        private void drawerNum_ValueChanged(object sender, EventArgs e)
        {
            Desk d = new Desk(width.Value, depth.Value, (int)drawerNum.Value, dm);

            DeskQuote dq = new DeskQuote(name.Text, r, d);

            this.deskPricer.NumberOfDrawers = (int)drawerNum.Value;

            this.deskQuotePricer.GetQuotePrice();

            lblPrice.Text = this.deskQuotePricer.QuotePrice.ToString();
        }
    }
}
