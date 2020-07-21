using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    interface IDamageable
    {
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public bool IsFunctioning { get; set; }

        public int Harm(int posAmount)
        {
            Hp -= posAmount;
            CheckIfFunctioning();
            return Hp;
        }

        public int Heal(int posAmount)
        {
            Hp += posAmount;
            CheckIfFunctioning();
            return Hp;
        }

        protected bool CheckIfFunctioning()
        {
            bool res = true;
            if (Hp <= 0)
            {
                res = false;
            }
            else if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
            IsFunctioning = res;
            return res;
        }
    }
}
