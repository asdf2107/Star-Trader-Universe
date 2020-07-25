using System.Collections.Generic;
using c = System.Console;
using g = Star_Trader_Universe.Graphics;

namespace Star_Trader_Universe
{
    public class Market
    {
        public List<ITrader> ActiveTraders { get; set; } = new List<ITrader>();

        public object ShowTrades(bool giveControl = true)
        {
            Dictionary<string, PairValue> options = new Dictionary<string, PairValue>();
            bool empty = true;
            foreach (ITrader t in ActiveTraders)
            {
                foreach (IPhysical s in t.Trades.Keys)
                {
                    options.Add(string.Format("│{0,-15}│{1,-10}│{2,-15}│{3,10} $│", t.Name, s.GetType().Name, s.GetSpecs(), t.Trades[s]),
                        new PairValue(new TraderItem(t, s, t.Trades[s])));
                    empty = false;
                }
            }
            if (!empty)
            {
                OptionTable ot = new OptionTable(options, new System.Drawing.Point(0, 0), 100, 18);
                ot.Draw();
                if (giveControl)
                {
                    return ot.GiveControl();
                }
            }
            else
            {
                var popup = new g.Popup("No trades here!");
                popup.GiveControl();
            }
            return null;
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
