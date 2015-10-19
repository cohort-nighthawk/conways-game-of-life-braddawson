using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {

            Board<bool, int, int> board = new Board<bool, int, int>();
            Board<bool, int, int> nextGeneration = new Board<bool, int, int>();

            //Board<bool, int, int> noDupesOnBoard = new Board<bool, int, int>();

            //take user input
            string userInput;
            Console.Write("Enter 'x,y' coordinates for a living cell:");
            userInput = Console.ReadLine();

            //convert user input and add to Board

            int xcoord;
            int ycoord;

            string[] xyString = userInput.Split(',');
            int[] convertedxyString = Array.ConvertAll<string, int>(xyString, int.Parse);

            xcoord = convertedxyString[0];
            ycoord = convertedxyString[1];

            Console.WriteLine("x: {0}, y: {1}", xcoord, ycoord);

            //add cell to board
            board.Add(true, xcoord, ycoord);

            //add more cells to board
            do
            {
                Console.Write("Enter 'x,y' coordinates for another living cell or enter 'start':");
                userInput = Console.ReadLine();

                if (userInput == "start")
                {
                    break;
                }

                //convert user input and add to Board
                xyString = userInput.Split(',');
                convertedxyString = Array.ConvertAll<string, int>(xyString, int.Parse);
                xcoord = convertedxyString[0];
                ycoord = convertedxyString[1];

                //Console.WriteLine("x: {0}, y: {1}", xcoord, ycoord);

                board.Add(true, xcoord, ycoord);
                //Console.WriteLine("board in loop: {0}", board);

            } while (userInput != "start");

            foreach (var item in board)
            {
                //Console.WriteLine(item);
            }

            //remove duplicates
            IEnumerable<Tuple<bool, int, int>> noDupesOnBoard = board.Distinct();

            //Console.WriteLine(noDupesOnBoard);

            foreach (var item in noDupesOnBoard)
            {
                //Console.WriteLine(item);
            }


            Board<bool, int, int> transGen = new Board<bool, int, int>();
            //add eight neighboors for each distint cell on initial board set up
            foreach (var item in noDupesOnBoard)
            {
                transGen.Add(false, item.Item2 + 0, item.Item3 + 1);
                transGen.Add(false, item.Item2 + 1, item.Item3 + 1);
                transGen.Add(false, item.Item2 + 1, item.Item3 + 0);
                transGen.Add(false, item.Item2 + 1, item.Item3 - 1);
                transGen.Add(false, item.Item2 - 0, item.Item3 - 1);
                transGen.Add(false, item.Item2 - 1, item.Item3 - 1);
                transGen.Add(false, item.Item2 - 1, item.Item3 + 0);
                transGen.Add(false, item.Item2 - 1, item.Item3 + 1);
            }

            int addedNCount = 0;
            foreach (var item in transGen)
            {
                addedNCount++;
                //Console.WriteLine("{1}: {0}",item, addedNCount);

            }

            //combine initial set up with neighbors
            IEnumerable<Tuple<bool, int, int>> boardOfTheLivingAndDead = board.Concat(transGen);
            int boardOfTheLivingAndDeadNumber = 0;
            foreach (var item in boardOfTheLivingAndDead)
            {
                boardOfTheLivingAndDeadNumber++;
                //Console.WriteLine("{0}: {1}", boardOfTheLivingAndDeadNumber, item);
            }

            //count how many time each cell in in the list, this is the count of adjacent living cells used for birth
            var groups = boardOfTheLivingAndDead.GroupBy(cell => cell);
            foreach (var item in groups)
            {
                //Console.WriteLine("{0} occurs {1} times, if 3 and false: birth!",item.Key, item.Count());
                if (item.Count() == 3 && item.Key.Item1 == false)
                {
                    nextGeneration.Add(item.Key);
                }

            }

            //find living cells that will survive to next generation
            // item1 == true && 2 or 3 neighbors with item1 == true
            // look at initial board set up (board)
            foreach (var item in noDupesOnBoard)
            {
                int numberOfLiveNeighbors = 0;
                // create local neighbor list
                Board<bool, int, int> localNeighbors = new Board<bool, int, int>();
                localNeighbors.Add(true, item.Item2 + 0, item.Item3 + 1);
                localNeighbors.Add(true, item.Item2 + 1, item.Item3 + 1);
                localNeighbors.Add(true, item.Item2 + 1, item.Item3 + 0);
                localNeighbors.Add(true, item.Item2 + 1, item.Item3 - 1);
                localNeighbors.Add(true, item.Item2 - 0, item.Item3 - 1);
                localNeighbors.Add(true, item.Item2 - 1, item.Item3 - 1);
                localNeighbors.Add(true, item.Item2 - 1, item.Item3 + 0);
                localNeighbors.Add(true, item.Item2 - 1, item.Item3 + 1);

                foreach (var liveCell in noDupesOnBoard)
                {
                    if (localNeighbors.Contains(liveCell))
                    {
                        numberOfLiveNeighbors++;
                    }
                }

                if (numberOfLiveNeighbors == 2 || numberOfLiveNeighbors == 3)
                {
                    //Console.WriteLine("the cell {0} survives with {1} neighbors", item, numberOfLiveNeighbors);
                    nextGeneration.Add(item);
                }
            }

            Console.WriteLine("These are the living in the next generation:");
            foreach (var item in nextGeneration)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
