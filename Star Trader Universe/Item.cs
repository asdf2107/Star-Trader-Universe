﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Item : IPhysical, IDamageable
    {
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public bool IsFunctioning { get; set; } = false;
        public int Mass { get; set; }

        public Item(int mass, int maxHp)
        {
            Hp = maxHp;
            MaxHp = maxHp;
            Mass = mass;
        }

        public virtual bool AreSame(Item compItem)
        {
            if (Hp == compItem.Hp && MaxHp == compItem.MaxHp && IsFunctioning == compItem.IsFunctioning && Mass == compItem.Mass)
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
