using System;
using System.Collections.Generic;
using System.Drawing;
using g = Star_Trader_Universe.Graphics;

namespace Star_Trader_Universe
{
    public class OptionTable
    {
        Dictionary<string, PairValue> Options = new Dictionary<string, PairValue>();
        int Chosen = -1;
        Point StartLoc;
        int Width;
        int Height;
        int ElementHeight = 3;

        public OptionTable(Dictionary<string, PairValue> options, Point startLoc, int w, int h)
        {
            Options = options;
            NumerateOptions();
            StartLoc = startLoc;
            Width = w;
            Height = h;
        }

        void NumerateOptions()
        {
            int i = 0;
            foreach (var keyPair in Options)
            {
                keyPair.Value.Num = i++;
            }
        }

        public void Draw()
        {
            foreach (var keyPair in Options)
            {
                g.DrawWindow(StartLoc.X, StartLoc.Y + keyPair.Value.Num * ElementHeight, Width, ElementHeight, keyPair.Key, keyPair.Value.Num == Chosen ? true : false);
            }
        }

        public KeyValuePair<string, PairValue> GetKeyValuePair(int num)
        {
            foreach (var keyPair in Options)
            {
                if (keyPair.Value.Num == num)
                {
                    return keyPair;
                }
            }
            throw new ArgumentException($"KeyPair for num {num} not found!");
        }

        public PairValue GiveControl()
        {
            Chosen = Chosen == -1 ? 0 : Chosen;
            Draw();
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                Chosen = -1;
                return GetKeyValuePair(Chosen).Value;
            }
            else if (keyPressed.Key == ConsoleKey.Enter || keyPressed.Key == ConsoleKey.Spacebar)
            {
                return GetKeyValuePair(Chosen).Value;
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
