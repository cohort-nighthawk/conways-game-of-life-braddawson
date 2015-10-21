using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Neighbourhood : List<Cell>
    {
        public void AddEmptyCell(int xcoord, int ycoord, bool extant)
        {
            Cell cell = new Cell(xcoord, ycoord, extant);
            this.Add(cell);
        }
    }
}