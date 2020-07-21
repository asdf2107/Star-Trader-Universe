using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Planet
    {
        public int Gravity { get; protected set; }
        public List<ITrader> Traders { get; set; } = new List<ITrader>();
        public List<Resource> Resources { get; set; } = new List<Resource>();

        public Planet(int g = 10)
        {
            Gravity = g;
        }
    }
}
