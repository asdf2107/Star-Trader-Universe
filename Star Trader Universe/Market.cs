using System.Collections.Generic;
using c = System.Console;

namespace Star_Trader_Universe
{
    public class Market
    {
        public List<ITrader> ActiveTraders { get; set; } = new List<ITrader>();

        public void ShowTrades()
        {
            foreach (ITrader t in ActiveTraders)
            {
                foreach (IPhysical s in t.Trades.Keys)
                {
                    c.WriteLine(string.Format("│{0,15}│{1,10}│{2,15}│{3,10} $│", t.Name, s.GetType().Name, s.GetSpecs(), t.Trades[s]));
                }
            }
        }

        public void AddToTraders(ITrader t)
        {
            ActiveTraders.Add(t);
        }

        public bool RemoveFromTraders(ITrader t)
        {
            if (ActiveTraders.Contains(t))
            {
                ActiveTraders.Remove(t);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
