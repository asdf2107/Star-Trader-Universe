using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public interface IPhysical
    {
        public int Mass { get; set; }

        public int ChangeMass(int amount)
        {
            Mass += amount;
            return Mass;
        }

        public string GetSpecs()
        {
            return $"Mass: {Mass}";
        }

        public bool AreSame(IPhysical compare)
        {
            if (Mass == compare.Mass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
