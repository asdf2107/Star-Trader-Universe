using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Factory : ITrader
    {
        public int Money { get; set; } = 0;
        public List<ISellable> Inventory { get; set; } = new List<ISellable>();
        public Dictionary<ISellable, int> Trades { get; set; } = new Dictionary<ISellable, int>();
        public Dictionary<ISellable, int> Wishes { get; set; } = new Dictionary<ISellable, int>();

        public Factory()
        {

        }
    }
}
