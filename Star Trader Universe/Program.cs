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
        public static List<PlanetarySystem> Systems = new List<PlanetarySystem>();

        static void Main()
        {
            Setup();
            Player.MainSpaceship = new Spaceship("Bruhlia", new Point(0, 0));
            Systems.Add(new PlanetarySystem("Solar System", new List<Planet>()));
            Systems.Add(new PlanetarySystem("Andromeda", new List<Planet>()));
            Systems[0].AddPlanet(new Planet("Earth"));
            Systems[1].AddPlanet(new Planet("Nua"));
            Factory zaz = new Factory("ZAZ Factory");
            Systems[0][0].ActiveTraders.Add(zaz);
            for (int i = 0; i < 8; i++)
            {
                Item item = new Item(100 * i + 100, 10 * i * i + 50);
                zaz.Inventory.Add(item);
                ((ITrader)zaz).AddToTrades(item, i * 5000 + 50000);
            }
            c.SetCursorPosition(0, 0);
            while (true)
            {
                object pl = ShowPlanets();

                Planet pln = pl as Planet;
                bool cont = true;
                while (cont)
                {
                    object pv = pln.ShowTrades();
                    if (pv != null)
                    {
                        TraderItem ti = pv as TraderItem;
                        ti.Trader.Sell(Player, ti.Item, ti.Price);
                    }
                    else
                    {
                        cont = false;
                    }
                }
                g.Clear();
            }
            Systems[0][0].ShowTrades(false);
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
            g.Draw();
        }

        public static object ShowPlanets(bool giveControl = true)
        {
            Dictionary<string, PairValue> options = new Dictionary<string, PairValue>();
            foreach (PlanetarySystem ps in Systems)
            {
                for (int i = 0; i < ps.Planets.Count; i++)
                {
                    options.Add(string.Format("│{0,-15}│{1,-15}│{2,7} ly│", ps[i].Name, ps.Name, ((ILocatable)ps).GetDistanceFrom(Player.MainSpaceship.Location)),
                            new PairValue(ps[i]));
                }
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
