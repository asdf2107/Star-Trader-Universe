using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using c = System.Console;
using g = Star_Trader_Universe.Graphics;

namespace Star_Trader_Universe
{
    class Program
    {
        public static Person Player = new Person("Player");
        public static List<Planet> Planets = new List<Planet>();

        static void Main()
        {
            Setup();
            Planets.Add(new Planet("Earth", 0, 0));
            Factory zaz = new Factory("ZAZ Factory");
            Planets[0].ActiveTraders.Add(zaz);
            for (int i = 0; i < 8; i++)
            {
                Item item = new Item(100 * i + 100, 10 * i * i + 50);
                zaz.Inventory.Add(item);
                ((ITrader)zaz).AddToTrades(item, i * 5000 + 50000);
            }
            c.SetCursorPosition(0, 0);
            object pv = Planets[0].ShowTrades();
            while (pv != null)
            {
                TraderItem ti = pv as TraderItem;
                ti.Trader.Sell(Player, ti.Item, ti.Price);               
                pv = Planets[0].ShowTrades();
            }
            Planets[0].ShowTrades(false);
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

        public static int GetDistance(Point p1, Point p2)
        {
            return (int)Math.Floor(Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y)));
        }

        public object ShowPlanets(bool giveControl = true)
        {
            Dictionary<string, PairValue> options = new Dictionary<string, PairValue>();
            foreach (Planet p in Planets)
            {
                options.Add(string.Format("│{0,-15}│{1,-10}│", p.Name, GetDistance(Player.MainSpaceship.Location, p.Location)),
                        new PairValue(p));
            }
            OptionTable ot = new OptionTable(options, new Point(0, 0), 100, 40);
            ot.Draw();
            if (giveControl)
            {
                return ot.GiveControl();
            }
            return null;
        }
    }
}
