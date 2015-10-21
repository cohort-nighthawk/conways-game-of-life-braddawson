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
        public Neighbourhood neighbourhood;
        
        public Cell(int xcoord, int ycoord, bool extant)
        {
            this.xcoord = xcoord;
            this.ycoord = ycoord;
            this.extant = extant;
            if (extant == true)
            {
                this.neighbourhood = new Neighbourhood();
                this.neighbourhood.AddEmptyCell(this.xcoord + 0, this.ycoord + 1, false);
                this.neighbourhood.AddEmptyCell(this.xcoord + 1, this.ycoord + 1, false);
                this.neighbourhood.AddEmptyCell(this.xcoord + 1, this.ycoord + 0, false);
                this.neighbourhood.AddEmptyCell(this.xcoord + 1, this.ycoord - 1, false);
                this.neighbourhood.AddEmptyCell(this.xcoord + 0, this.ycoord - 1, false);
                this.neighbourhood.AddEmptyCell(this.xcoord - 1, this.ycoord - 1, false);
                this.neighbourhood.AddEmptyCell(this.xcoord - 1, this.ycoord + 0, false);
                this.neighbourhood.AddEmptyCell(this.xcoord - 1, this.ycoord + 1, false);
            }

        }

        public Cell(int xcoord, int ycoord)
        {
            this.xcoord = xcoord;
            this.ycoord = ycoord;
            this.extant = true;
        }

        public bool extant { get; set; }
    }
}
