using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        //int[,] rushPrices = new int[,] { {0,0,0 },{ 60, 70, 80 }, { 40, 50, 60 }, { 30, 35, 40 } };
        int[] surfaceCosts = new int[] {200, 100, 50, 300, 125 };
        private int[,] GetRushOrder ()
        {
            int[,] finalPrices = new int[4, 3];
            List<int> values = new List<int>();
            string path = @"C:\Users\matth\source\repos\MegaDesk2.0\MegaDesk2.0\cit365_document_rushOrderPrices.txt";
            string[] readText = File.ReadAllLines(path);
            foreach(string price in readText)
            {
                values.Add(int.Parse(price));
            }
            int counter = 0;
            for(int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        finalPrices[i, j] = 0;
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        finalPrices[i, j] = values[counter];
                        counter += 1;
                    }
                }
            }
            return finalPrices;
        }

        public static void Serialize(object obj, string filePath)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static object Deserialize(string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(path))
            using (var reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize(reader);
            }
        }

        public void getQuotePrice()
        {
            int[,] rushPrices = GetRushOrder();
            foreach(int price in rushPrices)
            {
                Debug.WriteLine(price);
            }
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
            Serialize(this, @"C:\\Users\\matth\\source\\repos\\MegaDesk2.0\\MegaDesk2.0\\quotes.json");




            
        }

        public string CustomerNames { get; set; }
    }
}
