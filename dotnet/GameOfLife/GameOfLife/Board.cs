using GameOfLife;
using System;
using System.Collections.Generic;

namespace GameOfLife
{
    //below is for code in Program.cs, works for one turn of the game and uses user input to start game
    public class Board<T1, T2, T3> : List<Tuple<T1, T2, T3>>, IEnumerable<Tuple<T1, T2, T3>>
    {
        public void Add(T1 alive, T2 xcoord, T3 ycoord)
        {
            Add(new Tuple<T1, T2, T3>(alive, xcoord, ycoord));
        }
    }
}