using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Person : IPhysical, ITrader
    {
        public string Name { get; set; }
        public int Hp { get; set; } = 10;
        public int Mass { get; set; } = 1;
        public int Money { get; set; } = 200000;
        public List<IPhysical> Inventory { get; set; } = new List<IPhysical>();
        public Dictionary<IPhysical, int> Trades { get; set; } = new Dictionary<IPhysical, int>();
        public Dictionary<IPhysical, int> Wishes { get; set; } = new Dictionary<IPhysical, int>();
        public Spaceship MainSpaceship { get; set; } = null;

        public Person(string name)
        {
            Name = name;
        }
    }
}
