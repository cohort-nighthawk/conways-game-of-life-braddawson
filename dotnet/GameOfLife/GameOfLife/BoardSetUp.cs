using GameOfLife;
using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class BoardSetUp<T1, T2, T3> : List<Tuple<T1, T2, T3>>
    {
        public void Add(T1 alive, T2 xcoord, T3 ycoord)
        {
            Add(new Tuple<T1, T2, T3>(alive, xcoord, ycoord));
        }

        
    }


}