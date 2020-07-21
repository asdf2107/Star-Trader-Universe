using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public interface ITrader
    {
        public int Money { get; set; }
        public List<Item> Inventory { get; set; }
        public Dictionary<Item, int> Trades { get; set; } // item - min price

        public bool Trade(ITrader buyer, Item item, int proposedPrice)
        {
            if (Trades.ContainsKey(item))
            {
                if (Trades[item] <= proposedPrice && buyer.Money >= proposedPrice)
                {
                    buyer.Money -= proposedPrice;
                    Money += proposedPrice;
                    Trades.Remove(item);
                    buyer.Inventory.Add(item);
                    return true;
                }
            }
            return false;
        }

        public bool AddToTrades(Item item, int minPrice)
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
                Trades.Add(item, minPrice);
                return true;
            }
            return false;
        }

        public bool RemoveFromTrades(Item item)
        {
            if (Trades.ContainsKey(item))
            {
                Trades.Remove(item);
                Inventory.Add(item);
                return true;
            }
            return false;
        }
    }
}
