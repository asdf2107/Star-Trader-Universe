using System;
using System.Collections.Generic;
using System.Text;
using c = System.Console;

namespace Star_Trader_Universe
{
    public class Planet
    {
        public int Gravity { get; protected set; }
        public List<ITrader> ActiveTraders { get; set; } = new List<ITrader>();
        public List<Resource> Resources { get; set; } = new List<Resource>();
        public List<Factory> Factories { get; set; } = new List<Factory>();

        public Planet(int g = 10)
        {
            Gravity = g;
        }

        public void ShowTrades()
        {
            foreach (ITrader t in ActiveTraders)
            {
                foreach (IPhysical s in t.Trades.Keys)
                {
                    c.WriteLine(s + " (" + s.Mass + " t) : " + t.Trades[s]);
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

        public void BuildFactory(Factory f, bool addToTraders = false)
        {
            Factories.Add(f);
            if (addToTraders)
            {
                AddToTraders(f);
            }
        }

        public bool DestroyFactory(Factory f)
        {
            if (Factories.Contains(f))
            {
                Factories.Remove(f);
                if (ActiveTraders.Contains(f))
                {
                    ActiveTraders.Remove(f);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
