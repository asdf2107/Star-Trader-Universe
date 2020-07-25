using System;
using System.Collections.Generic;
using System.Drawing;
using g = Star_Trader_Universe.Graphics;

namespace Star_Trader_Universe
{
    public class OptionTable
    {
        Dictionary<string, PairValue> Options = new Dictionary<string, PairValue>();
        public int Chosen { get; private set; } = -1;
        Point StartLoc { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int ElementHeight { get; set; } = 3;
        bool ConfirmExit { get; set; }


        public OptionTable(Dictionary<string, PairValue> options, Point startLoc, int w, int h, bool confirmExit = true)
        {
            Options = options;
            NumerateOptions();
            StartLoc = startLoc;
            Width = w;
            Height = h;
            ConfirmExit = confirmExit;
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
            int maxCount = Height / ElementHeight;
            int linesFromBittom = 3;
            int startPos = Chosen > maxCount - linesFromBittom ? Chosen + linesFromBittom - maxCount : 0;
            bool upperMore = startPos >= 1 ? true : false;
            bool lowerMore = (Options.Count - startPos + 1) * ElementHeight > Height ? true : false;

            int i = 0;
            foreach (var keyPair in Options)
            {
                int pos = i - startPos + (upperMore ? 1 : 0);

                if (i >= Options.Count)
                {
                    break;
                }
                else if (i == startPos - 1 && upperMore)
                {
                    DrawMore(0);
                }
                else if (i == startPos + maxCount - 1 && lowerMore)
                {
                    DrawMore((maxCount - 1) * ElementHeight);
                    break;
                }
                else if (pos >= 0)
                {
                    g.DrawWindow(StartLoc.X, StartLoc.Y + pos * ElementHeight, Width, ElementHeight, keyPair.Key, keyPair.Value.Num == Chosen ? true : false);
                }
                i++;
            }
        }

        void DrawMore(int dy)
        {
            g.DrawWindow(StartLoc.X, StartLoc.Y + dy, Width, ElementHeight, "...", false);
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

        public object GiveControl()
        {
            Chosen = Chosen == -1 ? 0 : Chosen;
            this.Draw();
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                if (!ConfirmExit || new g.Popup("Exit?", g.Popup.DialogButtons.YesNo).GiveControl() == g.Popup.DialogResult.Yes)
                {
                    Chosen = -1;
                    return null;
                }
            }
            else if (keyPressed.Key == ConsoleKey.Enter || keyPressed.Key == ConsoleKey.Spacebar)
            {
                return GetKeyValuePair(Chosen).Value.InfoObject;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                ChoosePrevious();
            }
            else if (keyPressed.Key == ConsoleKey.DownArrow || keyPressed.Key == ConsoleKey.Tab)
            {
                ChooseNext();
            }
            return GiveControl();
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
