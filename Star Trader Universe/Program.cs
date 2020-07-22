using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using c = System.Console;

namespace Star_Trader_Universe
{
    class Program
    {
        static char[] Borders = new char[6] { '┌', '─', '┐', '│', '┘', '└' };
        static ConsoleColor ForegroundColor = ConsoleColor.White;
        static ConsoleColor BackgroundColor = ConsoleColor.Black;
        static int Width = 120;
        static int Height = 40;
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
            c.ForegroundColor = ForegroundColor;
            c.BackgroundColor = BackgroundColor;
            c.WindowWidth = Width;
            c.WindowHeight = Height;
            c.BufferWidth = c.WindowWidth;
            c.BufferHeight = c.WindowHeight;
            c.Title = "Star Trader Universe";
            Update();
        }

        static void Update()
        {
            c.Clear();
            DrawPanel();
        }

        static void DrawPanel()
        {
            DrawWindow(0, 0, 15, 5);
        }

        static void DrawWindow(int x, int y, int w, int h, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.DarkCyan)
        {
            c.ForegroundColor = fore;
            c.BackgroundColor = back;

            FillRect(x + 1, y + 1, w - 2, h - 2);
            c.SetCursorPosition(x, y);
            c.Write(Borders[0]);
            DrawHorLine(c.CursorLeft, c.CursorTop, w - 2);
            c.Write(Borders[2]);
            DrawVertLine(c.CursorLeft - 1, c.CursorTop + 1, h - 2);
            c.Write(Borders[4]);
            DrawHorLine(x + 1, y + h - 1, w - 2);
            DrawVertLine(x, y + 1, h - 2);
            c.Write(Borders[5]);

            void DrawHorLine(int x0, int y0, int len)
            {
                c.SetCursorPosition(x0, y0);
                for (int i = 0; i < len; i++)
                    c.Write(Borders[1]);
            }

            void DrawVertLine(int x0, int y0, int len)
            {
                c.SetCursorPosition(x0, y0);
                for (int i = 0; i < len; i++)
                {
                    c.Write(Borders[3]);
                    c.SetCursorPosition(c.CursorLeft - 1, c.CursorTop + 1);
                }
            }

            void FillRect(int x0, int y0, int w0, int h0)
            {
                for (int j = 0; j < h0; j++)
                {
                    c.SetCursorPosition(x0, y0 + j);
                    for (int i = 0; i < w0; i++)
                    {
                        c.Write(' ');
                    }
                }
            }
        }
    }
}
