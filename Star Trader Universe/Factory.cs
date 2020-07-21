using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Factory : ITrader
    {
        public int Money { get; set; }
        public List<Item> Inventory { get; set; }
        public Dictionary<Item, int> Trades { get; set; }

        public Factory()
        {

        }
    }
}
