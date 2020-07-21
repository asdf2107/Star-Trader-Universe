using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public interface ITrader
    {
        public int Money { get; set; }
        public List<ISellable> Inventory { get; set; }
        public Dictionary<ISellable, int> Trades { get; set; } // item - min price
        public Dictionary<ISellable, int> Wishes { get; set; } // item - max price

        public bool Sell(ITrader buyer, ISellable item, int proposedPrice)
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

        public bool Buy(ITrader seller, ISellable item, int proposedPrice)
        {
            ISellable sameItem = seller.GetSame(item);
            if (Wishes.ContainsKey(item) && sameItem != null)
            {
                if (Wishes[item] >= proposedPrice && Money >= proposedPrice)
                {
                    Money -= proposedPrice;
                    seller.Money += proposedPrice;
                    Wishes.Remove(item);
                    seller.Inventory.Remove(sameItem);
                    Inventory.Add(sameItem);
                    return true;
                }
            }
            return false;
        }

        ISellable GetSame(ISellable origItem)
        {
            foreach (ISellable i in Inventory)
            {
                if (origItem.AreSame(i))
                {
                    return i;
                }
            }
            return null;
        }

        public bool AddToTrades(ISellable item, int minPrice)
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
                Trades.Add(item, minPrice);
                return true;
            }
            return false;
        }

        public bool RemoveFromTrades(ISellable item)
        {
            if (Trades.ContainsKey(item))
            {
                Trades.Remove(item);
                Inventory.Add(item);
                return true;
            }
            return false;
        }

        public bool AddToWishes(ISellable item, int minPrice)
        {
            Wishes.Add(item, minPrice);
            return true;
        }

        public bool RemoveFromWishes(ISellable item)
        {
            if (Wishes.ContainsKey(item))
            {
                Wishes.Remove(item);
                return true;
            }
            return false;
        }
    }
}
