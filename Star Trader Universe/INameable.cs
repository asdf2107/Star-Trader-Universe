using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public interface INameable
    {
        public string Name { get; set; }
        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
