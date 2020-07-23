using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using c = System.Console;
using g = Star_Trader_Universe.Graphics;

namespace Star_Trader_Universe
{
    class Program
    {
        public static Person Player = new Person("Player");

        static void Main()
        {
            Setup();
            Planet Earth = new Planet(0, 0);
            Factory zaz = new Factory("ZAZ Factory");
            Earth.ActiveTraders.Add(zaz);
            for (int i = 0; i < 5; i++)
            {
                Item item = new Item(100 * i + 200, 10 * i * i + 50);
                zaz.Inventory.Add(item);
                ((ITrader)zaz).AddToTrades(item, i * 5000 + 50000);
            }
            c.SetCursorPosition(0, 0);
            PairValue pv = Earth.ShowTrades();
            while (pv != null && pv.InfoObject != null)
            {
                TraderItem ti = pv.InfoObject as TraderItem;
                ti.Trader.Sell(Player, ti.Item, ti.Price);               
                pv = Earth.ShowTrades();
            }
            Earth.ShowTrades(false);
            c.WriteLine(Player.Money);
            foreach (IPhysical p in Player.Inventory)
            {
                c.WriteLine(p.GetSpecs());
            }
            var msg = new g.Popup("bruh", g.Popup.DialogButtons.YesNo);
            msg.GiveControl();
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
