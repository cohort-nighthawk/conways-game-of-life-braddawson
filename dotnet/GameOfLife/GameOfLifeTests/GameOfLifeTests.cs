using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void TheCellIsAlive()
        {
            Cell cell = new Cell(0, 0);
            Assert.IsTrue(cell.extant);
        }

        [TestMethod]
        public void AddCellMethodAddsACellToGameBoard()
        {
            GameBoard dish = new GameBoard();
            dish.AddCell(0, 0);
            Assert.IsTrue(dish.Count == 1);
        }










        //Any live cell with fewer than two live neighbours dies, as if caused by under-population.



        //Any live cell with two or three live neighbours lives on to the next generation.



        //Any live cell with more than three live neighbours dies, as if by overcrowding.



        //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.



    }
}
