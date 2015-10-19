using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameBoard : List<Cell>
    {
        //method to add a cell
        public void AddCell(int v1, int v2)
        {
            Cell cell = new Cell(v1, v2);
            this.Add(cell);
        }
    }
}
