using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Item
    {
        public int Hp { get; protected set; }
        public bool IsBroken { get; protected set; } = false;
        public int Mass { get; protected set; }

        public Item(int hp, int mass)
        {
            Hp = hp;
            Mass = mass;
        }

        public int ChangeMass(int amount)
        {
            Mass += amount;
            return Mass;
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
            IsBroken = res;
            return res;
        }
    }
}
