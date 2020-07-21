using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Planet
    {
        public int Gravity { get; protected set; }

        public Planet(int g = 10)
        {
            Gravity = g;
        }
    }
}
