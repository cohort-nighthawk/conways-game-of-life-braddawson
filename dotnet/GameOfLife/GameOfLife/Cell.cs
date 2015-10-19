using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        private int xcoord;
        private int ycoord;
        

        public Cell(int xcoord, int ycoord)
        {
            this.xcoord = xcoord;
            this.ycoord = ycoord;
            this.vitalStatus = true;
        }

        public bool vitalStatus { get; set; }
    }
}
