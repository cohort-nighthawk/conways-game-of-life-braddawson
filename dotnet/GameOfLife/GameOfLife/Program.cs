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

            BoardSetUp<bool, int, int> board = new BoardSetUp<bool, int, int>();
            //BoardSetUp<bool, int, int> noDupesOnBoard = new BoardSetUp<bool, int, int>();

            //take user input
            string userInput;
            Console.Write("Enter 'x,y' coordinates for a living cell:");
            userInput = Console.ReadLine();

            //convert user input and add to BoardSetUp

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

                //convert user input and add to BoardSetUp
                xyString = userInput.Split(',');
                convertedxyString = Array.ConvertAll<string, int>(xyString, int.Parse);
                xcoord = convertedxyString[0];
                ycoord = convertedxyString[1];

                //Console.WriteLine("x: {0}, y: {1}", xcoord, ycoord);

                board.Add(true, xcoord, ycoord);
                Console.WriteLine("board in loop: {0}", board);

            } while (userInput != "start");







            foreach (var item in board)
            {
                Console.WriteLine(item);
            }

            //remove duplicates
            IEnumerable<Tuple<bool, int, int>> noDupesOnBoard = board.Distinct();

            Console.WriteLine(noDupesOnBoard);

            foreach (var item in noDupesOnBoard)
            {
                Console.WriteLine(item);
            }


            BoardSetUp<bool, int, int> nextGeneration = new BoardSetUp<bool, int, int>();
            //add eight neighboors for each distint cell on initial board set up
            foreach (var item in noDupesOnBoard)
            {
                nextGeneration.Add(false, xcoord + 0, ycoord + 1);
                nextGeneration.Add(false, xcoord + 1, ycoord + 1);
                nextGeneration.Add(false, xcoord + 1, ycoord + 0);
                nextGeneration.Add(false, xcoord + 1, ycoord - 1);
                nextGeneration.Add(false, xcoord - 0, ycoord - 1);
                nextGeneration.Add(false, xcoord - 1, ycoord - 1);
                nextGeneration.Add(false, xcoord - 1, ycoord + 0);
                nextGeneration.Add(false, xcoord - 1, ycoord + 1);
            }

            int addedNCount = 0;
            foreach (var item in nextGeneration)
            {
                addedNCount++;
                Console.WriteLine("{1}: {0}",item, addedNCount);

            }

            //combine initial set up with neighbors
            //int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
            //int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };

            //IEnumerable<int> union = ints1.Union(ints2);
            IEnumerable<Tuple<bool, int, int>> boardOfTheLivingAndDead = board.Concat(nextGeneration);
            int boardOfTheLivingAndDeadNumber = 0;
            foreach (var item in boardOfTheLivingAndDead)
            {
                boardOfTheLivingAndDeadNumber++;
                Console.WriteLine("{0}: {1}", boardOfTheLivingAndDeadNumber, item);
            }
            

            Console.ReadKey();
        }
    }
}
