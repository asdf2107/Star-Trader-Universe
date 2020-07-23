using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using c = System.Console;

namespace Star_Trader_Universe
{
    public class Planet : Market
    {
        public int Gravity { get; protected set; }
        public Point Location { get; set; }
        public List<Resource> Resources { get; set; } = new List<Resource>();
        public List<Factory> Factories { get; set; } = new List<Factory>();
        public List<Person> People { get; set; } = new List<Person>();
        public List<Spaceship> Spaceships { get; set; } = new List<Spaceship>();

        public Planet(int x, int y, int g = 10)
        {
            Location = new Point(x, y);
            Gravity = g;
        }

        public void Enter(Spaceship s)
        {
            People.Concat(s.LeaveAll());
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
