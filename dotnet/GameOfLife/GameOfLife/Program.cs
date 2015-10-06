﻿using System;
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

            //add eight neighboors for each distint cell added to board


            Console.ReadKey();
        }
    }
}
