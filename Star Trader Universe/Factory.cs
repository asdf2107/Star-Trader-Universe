using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Factory : ITrader, INameable
    {
        public string Name { get; set; }
        public int Money { get; set; } = 0;
        public List<IPhysical> Inventory { get; set; } = new List<IPhysical>();
        public Dictionary<IPhysical, int> Trades { get; set; } = new Dictionary<IPhysical, int>();
        public Dictionary<IPhysical, int> Wishes { get; set; } = new Dictionary<IPhysical, int>();

        public Factory(string name)
        {
            Name = name;
        }
    }
}
