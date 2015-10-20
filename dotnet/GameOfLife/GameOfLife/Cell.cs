using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        public int xcoord;
        public int ycoord;
        

        public Cell(int xcoord, int ycoord)
        {
            this.xcoord = xcoord;
            this.ycoord = ycoord;
            this.extant = true;
        }

        public bool extant { get; set; }
    }
}
