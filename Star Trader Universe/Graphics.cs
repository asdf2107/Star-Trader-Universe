using System;
using c = System.Console;

namespace Star_Trader_Universe
{
    public static class Graphics
    {
        public static char[] Borders = new char[6] { '┌', '─', '┐', '│', '┘', '└' };
        public static char[] WideBorders = new char[6] { '╔', '═', '╗', '║', '╝', '╚' };
        public static ConsoleColor ForegroundColor = ConsoleColor.White;
        public static ConsoleColor BackgroundColor = ConsoleColor.Black;
        public static int Width = 120;
        public static int Height = 40;

        public static void DrawPanel()
        {
            DrawWindow(20, 20, 15, 5);
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
            DrawVertLine(c.CursorLeft - 1, c.CursorTop + 1, h - 2);
            c.Write(borders[4]);
            DrawHorLine(x + 1, y + h - 1, w - 2);
            DrawVertLine(x, y + 1, h - 2);
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
                    c.Write(text);
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
                c.SetCursorPosition(x0, y0);
                for (int i = 0; i < len; i++)
                {
                    c.Write(borders[3]);
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
