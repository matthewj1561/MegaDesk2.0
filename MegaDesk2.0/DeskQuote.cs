using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_James
{
    public enum Rush
    {
        fourteen,
        three,
        five,
        seven

    }
    internal class DeskQuote
    {
        public decimal quotePrice;
        private string customerName;
        private DateTime date;
        private Rush rush;
        public Desk d;

        public DeskQuote(string cm, Rush r, Desk d)
        {
            customerName = cm;
            rush = r;
            this.d = d;
            date = DateTime.Now;
            
        }

        int[,] rushPrices = new int[,] { {0,0,0 },{ 60, 70, 80 }, { 40, 50, 60 }, { 30, 35, 40 } };
        int[] surfaceCosts = new int[] {200, 100, 50, 300, 125 };

        public void getQuotePrice()
        {
            decimal basePrice = 200;
            decimal surfaceAreaPrice = 0;
            decimal drawCost = 0;
            decimal rushCost = 0;
            decimal surfaceArea = d.Width * d.Height;
            int bracket = 0;

            if (surfaceArea > 1000)
            {
                surfaceAreaPrice = surfaceArea - 1000;
            }
            if (d.NumberOfDrawers > 0)
            {
                drawCost = d.NumberOfDrawers * 50;
            }

            if (surfaceArea < 1000)
            {
                rushCost = rushPrices[(int)rush, 0];
            } else if (surfaceArea > 1000 && surfaceArea < 2000)
            {
                rushCost = rushPrices[(int)rush, 1];
            } else
            {
                rushCost = rushPrices[(int)rush, 2];
            }

            decimal totalCost = basePrice + drawCost + rushCost + surfaceAreaPrice + surfaceCosts[(int)d.DesktopMaterial];

            quotePrice = totalCost;



            
        }

        public string CustomerNames { get; set; }
    }
}
