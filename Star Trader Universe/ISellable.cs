﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public interface ISellable
    {
        public int Mass { get; set; }

        public int ChangeMass(int amount)
        {
            Mass += amount;
            return Mass;
        }

        public bool AreSame(ISellable compare)
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
