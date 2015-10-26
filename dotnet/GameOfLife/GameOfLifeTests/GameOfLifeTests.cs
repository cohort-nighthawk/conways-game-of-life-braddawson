using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;
using System.Collections.Generic;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void CovertUserInput()
        {
            var expectedXValue = 0;
            var expectedYValue = 1;
            var userInput = "0,1";
            UserInput.Covert(userInput);
            Assert.AreEqual(expectedXValue, UserInput.xcoord);
            Assert.AreEqual(expectedYValue, UserInput.ycoord);
        }


















        [TestMethod]
        public void TheCellIsAlive()
        {
            Cell cell = new Cell(0, 0);
            Assert.IsTrue(cell.extant);
        }

        [TestMethod]
        public void CellAddedToGameBoardIsAlive()
        {
            GameBoard board = new GameBoard();
            board.AddCell(0, 0);
            Assert.IsTrue(board[0].extant);
        }

        [TestMethod]
        public void AddCellMethodAddsACellToGameBoard()
        {
            GameBoard dish = new GameBoard();
            dish.AddCell(0, 0);
            Assert.IsTrue(dish.Count == 1);
        }

        [TestMethod]
        public void TheCellsLocation()
        {
            var expectedXcoord = 0;
            var expectedYcoord = 1;
            GameBoard board = new GameBoard();
            board.AddCell(0, 1);
            Assert.AreEqual(expectedXcoord, board[0].xcoord);
            Assert.AreEqual(expectedYcoord, board[0].ycoord);
        }

        [TestMethod]
        public void ACellsNeighbourhoodIsEveryLocationAroundACell()//creates only one neighbour for now
        {
            Neighbourhood expected = new Neighbourhood();
            expected.AddEmptyCell(0, 1, false);
            expected.AddEmptyCell(1, 1, false);
            expected.AddEmptyCell(1, 0, false);
            expected.AddEmptyCell(1, -1, false);
            expected.AddEmptyCell(0, -1, false);
            expected.AddEmptyCell(-1, -1, false);
            expected.AddEmptyCell(-1, 0, false);
            expected.AddEmptyCell(-1, 1, false);
            Cell cell = new Cell(0, 0, true);
            Assert.AreEqual(expected.ToString(), cell.neighbourhood.ToString());
        }

        [TestMethod]
        public void CombineStartingCellWithNeighbourCells()
        {
            GameBoard board = new GameBoard();
            board.AddCell(0, 1);
            board.AddCell(0, 0);
            board.AddCell(0, -1);
            board.Transition();

        }

        //Any live cell with fewer than two live neighbours dies, as if caused by under-population.



        //Any live cell with two or three live neighbours lives on to the next generation.



        //Any live cell with more than three live neighbours dies, as if by overcrowding.



        //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.



    }
}
