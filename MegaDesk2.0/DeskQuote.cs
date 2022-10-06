using System;
using System.Collections.Generic;
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

        public decimal getQuotePrice()
        {

            return (decimal)0.0;
        }

        public string CustomerNames { get; set; }
    }
}
