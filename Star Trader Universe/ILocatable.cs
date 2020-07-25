using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Star_Trader_Universe
{
    public interface ILocatable
    {
        Point Location { get; set; }
        public int GetDistanceFrom(Point p)
        {
            return (int)Math.Floor(Math.Sqrt((p.X - Location.X) * (p.X - Location.X) + (p.Y - Location.Y) * (p.Y - Location.Y)));
        }
    }
}
