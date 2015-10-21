using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Neighbourhood : List<Cell>
    {
        public void AddEmptyCell(int v1, int v2, bool v3)
        {
            Cell cell = new Cell(v1, v2, v3);
            this.Add(cell);
        }
    }
}