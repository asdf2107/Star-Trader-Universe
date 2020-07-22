using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using c = System.Console;
using g = Star_Trader_Universe.Graphics;

namespace Star_Trader_Universe
{
    class Program
    {
        static Person Player = new Person("Player");

        static void Main(string[] args)
        {
            Setup();
            Planet Earth = new Planet(0, 0);
            Factory zaz = new Factory("ZAZ Factory");
            Earth.ActiveTraders.Add(zaz);
            for (int i = 0; i < 5; i++)
            {
                Item item = new Item(100, 10);
                zaz.Inventory.Add(item);
                ((ITrader)zaz).AddToTrades(item, 500);
            }
            c.SetCursorPosition(0, 0);
            Earth.ShowTrades();
            c.ReadKey(true);
            List<IPhysical> l = new List<IPhysical>(zaz.Trades.Keys);
            ((ITrader)zaz).Sell(Player, l[0], 550);
            c.WriteLine(Player.Money);
            Earth.ShowTrades();
            c.ReadKey(true);
        }

        static void Setup()
        {
            c.CursorVisible = false;
            c.ForegroundColor = g.ForegroundColor;
            c.BackgroundColor = g.BackgroundColor;
            c.WindowWidth = g.Width;
            c.WindowHeight = g.Height;
            c.BufferWidth = c.WindowWidth;
            c.BufferHeight = c.WindowHeight;
            c.Title = "Star Trader Universe";
            Update();
        }

        static void Update()
        {
            c.Clear();
            g.DrawPanel();
        }
    }
}
