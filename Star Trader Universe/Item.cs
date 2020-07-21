using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Item : ISellable
    {
        public int Hp { get; protected set; }
        public int MaxHp { get; protected set; }
        public bool IsBroken { get; protected set; } = false;
        public int Mass { get; set; }

        public Item(int mass, int maxHp)
        {
            Hp = maxHp;
            MaxHp = maxHp;
            Mass = mass;
        }

        public virtual bool AreSame(Item compItem)
        {
            if (Hp == compItem.Hp && MaxHp == compItem.MaxHp && IsBroken == compItem.IsBroken && Mass == compItem.Mass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Harm(int posAmount)
        {
            Hp -= posAmount;
            CheckIfBroken();
            return Hp;
        }

        public int Heal(int posAmount)
        {
            Hp += posAmount;
            CheckIfBroken();
            return Hp;
        }

        protected bool CheckIfBroken()
        {
            bool res = false;
            if (Hp <= 0)
            {
                res = true;
            }
            else if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
            IsBroken = res;
            return res;
        }
    }
}
