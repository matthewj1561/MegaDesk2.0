using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_James
{
    public enum DesktopMaterial{
        oak,
        laminate,
        pine,
        rosewood,
        veneer
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

        public Desk (decimal h, decimal w, int numOfDraw, DesktopMaterial dM)
        {
       
            this.Height = h;
            this.Width = w;
            this.NumberOfDrawers = numOfDraw;
            this.DesktopMaterial = dM;
     
        }
    }
}
