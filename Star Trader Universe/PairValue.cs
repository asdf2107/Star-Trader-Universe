using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class PairValue
    {
        public object InfoObject;
        public int Num;

        public PairValue(object info)
        {
            InfoObject = info;
        }
    }

    public class TraderItem
    {
        public ITrader Trader;
        public IPhysical Item;
        public int Price;

        public TraderItem(ITrader trader, IPhysical item, int price)
        {
            Trader = trader;
            Item = item;
            Price = price;
        }
    }
}
