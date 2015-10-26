using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class UserInput
    {
        public static int xcoord { get; set; }
        public static int ycoord { get; set; }

        public static void Covert(string userInput)
        {
            string[] xyString = userInput.Split(',');
            int[] convertedxyString = Array.ConvertAll<string, int>(xyString, int.Parse);

            xcoord = convertedxyString[0];
            ycoord = convertedxyString[1];
        }
    }
}
