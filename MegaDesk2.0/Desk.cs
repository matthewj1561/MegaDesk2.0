using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_James
{
    public enum DesktopMaterial{
        laminate,
        Oak,
        Rosewood,
        Veneer,
        Pine
    }
    public enum Rush
    {
        none,
        three,
        five,
        seven
        
    }
    internal class Desk
    {
        public const short MIN_WIDTH = 24;
        public const short MAX_WIDTH = 96;
        public const short MIN_DEPTH = 12;
        public const short MAX_DEPTH = 48;
        public const short MIN_DESK_DRAWERS = 0;
        public const short MAX_DESK_DRAWERS = 7;
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int NumberOfDrawers { get; set; }

        public DesktopMaterial DesktopMaterial { get; set; }

        public Rush Rush { get; set; }

        public Desk (string n, decimal h, decimal w, int numOfDraw, DesktopMaterial dM, Rush r)
        {
            this.Name = n;
            this.Height = h;
            this.Width = w;
            this.NumberOfDrawers = numOfDraw;
            this.DesktopMaterial = dM;
            this.Rush = r;
        }
    }
}
