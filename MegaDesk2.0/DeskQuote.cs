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
        private decimal quotePrice;
        private string customerName;
        private DateTime date;
        private Rush rush;
        public Desk d;

        public DeskQuote (string cm, Rush r, Desk d )
        {
            customerName = cm;
            rush = r;
            this.d = d;
            date = DateTime.Now;
        }

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
                surfaceAreaPrice = surfaceArea + 1000;
            }
            if (d.NumberOfDrawers > 0)
            {
                drawCost = d.NumberOfDrawers * 50;
            }
            if ((int)rush != 0)
            {
                switch ((int)rush)
                {
                    case 1:
                        bracket = 1;
                        break;
                    case 2:
                        bracket = 2;
                        break;
                    default:
                        bracket = 3;
                        break;
                }
            }


            
        }

        public string CustomerNames { get; set; }
    }
}
