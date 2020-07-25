using System;
using c = System.Console;

namespace Star_Trader_Universe
{
    public static class Graphics
    {
        public static char[] Borders = new char[6] { '┌', '─', '┐', '│', '┘', '└' };
        public static char[] WideBorders = new char[6] { '╔', '═', '╗', '║', '╝', '╚' };
        public const ConsoleColor ForegroundColor = ConsoleColor.White;
        public const ConsoleColor BackgroundColor = ConsoleColor.Black;
        public static int Width = 120;
        public static int Height = 40;

        public static void Clear(ConsoleColor color = BackgroundColor)
        {
            c.BackgroundColor = color;
            c.Clear();
        }

        public static void Draw()
        {
            Clear();
            DrawPanel();
        }

        public static void DrawPanel()
        {
            int h = 8;
            DrawWindow(0, Height - h, Width - 1, h);
            DrawMoney();
        }

        static void DrawMoney()
        {
            c.SetCursorPosition(2, 38);
            c.WriteLine(Program.Player.Money + " $");
        }

        public class Popup
        {
            public enum DialogButtons
            {
                OK,
                YesNo,
            }

            public enum DialogResult
            {
                OK,
                Yes,
                No,
            }

            public string Text { get; set; }
            public DialogButtons ButtonsType { get; set; }
            int Chosen { get; set; } = 0;
            DialogResult[] ButtonsAvailable { get; set; }

            public Popup(string text, DialogButtons buttons = DialogButtons.OK)
            {
                Text = text;
                ButtonsType = buttons;
                if (ButtonsType == DialogButtons.OK)
                {
                    ButtonsAvailable = new DialogResult[] { DialogResult.OK };
                }
                else
                {
                    ButtonsAvailable = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                }
            }

            public void Draw()
            {
                int x = 40, y = 15, w = 40, h = 6;
                DrawWindow(x, y, w, h, Text, false, ConsoleColor.White, ConsoleColor.DarkYellow);
                for (int i = 0; i < ButtonsAvailable.Length; i++)
                {
                    DrawButton(x, y + h, ButtonsAvailable[i], i == Chosen ? true : false, i);
                }
            }

            public void DrawButton(int x0, int y0, DialogResult type, bool chosen = false, int pos = 1)
            {
                int w = 10, h = 3, marg = 2;
                int x = x0 + 1 + marg + (marg + w) * (2 - pos);
                int y = y0 - h - 1;
                DrawWindow(x, y, w, h, type.ToString(), chosen, ConsoleColor.White, chosen ? ConsoleColor.Gray : ConsoleColor.DarkYellow);
            }

            public DialogResult GiveControl()
            {
                this.Draw();
                ConsoleKeyInfo keyPressed = c.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.Enter || keyPressed.Key == ConsoleKey.Spacebar)
                {
                    return ButtonsAvailable[Chosen];
                }
                else if (keyPressed.Key == ConsoleKey.RightArrow || keyPressed.Key == ConsoleKey.LeftArrow || keyPressed.Key == ConsoleKey.Tab)
                {
                    ChooseNext();
                }
                return GiveControl();
            }

            public void ChooseNext()
            {
                if (ButtonsAvailable.Length > 1)
                {
                    if (++Chosen >= ButtonsAvailable.Length)
                    {
                        Chosen = 0;
                    }
                }
            }
        }

        public static void DrawWindow(int x, int y, int w, int h, string text = "", bool wide = false, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.DarkBlue)
        {
            c.ForegroundColor = fore;
            c.BackgroundColor = back;

            char[] borders = wide ? WideBorders : Borders;

            FillRect(x + 1, y + 1, w - 2, h - 2);
            DrawText(y + 1, text);

            c.SetCursorPosition(x, y);
            c.Write(borders[0]);
            DrawHorLine(c.CursorLeft, c.CursorTop, w - 2);
            c.Write(borders[2]);
            DrawVertLine(c.CursorLeft == 0 ? Width - 1 : c.CursorLeft - 1, c.CursorTop + 1, h - 2);
            c.CursorLeft--;
            c.CursorTop++;
            c.Write(borders[4]);
            DrawHorLine(x + 1, y + h - 1, w - 2);
            DrawVertLine(x, y + 1, h - 2);
            c.CursorLeft--;
            c.CursorTop++;
            c.Write(borders[5]);

            void DrawText(int y0, string txt, bool centered = false, int margin = 1)
            {
                if (centered)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    c.SetCursorPosition(x + 1 + margin, y0);
                    c.Write(txt);
                }
            }

            void DrawHorLine(int x0, int y0, int len)
            {
                c.SetCursorPosition(x0, y0);
                for (int i = 0; i < len; i++)
                    c.Write(borders[1]);
            }

            void DrawVertLine(int x0, int y0, int len)
            {
                for (int i = 0; i < len; i++)
                {
                    c.SetCursorPosition(x0, y0 + i);
                    c.Write(borders[3]);
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
