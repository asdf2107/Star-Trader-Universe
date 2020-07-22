using System;
using System.Collections.Generic;
using System.Drawing;
using g = Star_Trader_Universe.Graphics;

namespace Star_Trader_Universe
{
    public class OptionTable
    {
        List<string> Options { get; set; } = new List<string>();
        int Chosen = -1;
        Point StartLoc;
        int Width;
        int Height;
        int ElementHeight = 3;

        public OptionTable(List<string> options, Point startLoc, int w, int h)
        {
            Options = options;
            StartLoc = startLoc;
            Width = w;
            Height = h;
        }

        public void Draw()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                g.DrawWindow(StartLoc.X, StartLoc.Y + i * ElementHeight, Width, ElementHeight, Options[i], i == Chosen ? true : false);
            }
        }

        public int GiveControl()
        {
            Chosen = Chosen == -1 ? 0 : Chosen;
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                Chosen = -1;
                return Chosen;
            }
            else if (keyPressed.Key == ConsoleKey.Enter || keyPressed.Key == ConsoleKey.Spacebar)
            {
                return Chosen;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                ChoosePrevious();
            }
            else if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                ChooseNext();
            }
            return GiveControl();
        }

        public void Choose(int pos)
        {
            if (pos >= 0 && pos < Options.Count)
            {
                Chosen = pos;
            }
            else
            {
                throw new ArgumentException($"pos vas invalid (${pos}; Options.Count was {Options.Count})");
            }
        }

        public void ChooseNext()
        {
            if (Options.Count > 0)
            {
                if (++Chosen >= Options.Count)
                {
                    Chosen = 0;
                }
            }
        }

        public void ChoosePrevious()
        {
            if (Options.Count > 0)
            {
                if (--Chosen < 0)
                {
                    Chosen = Options.Count - 1;
                }
            }  
        }
    }
}
