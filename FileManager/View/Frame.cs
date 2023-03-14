using FileManager.Controller;
using System.Drawing;
using static FileManager.View.DrawUI;

namespace FileManager.View
{
    public enum Line
    {
        HorizontalStraightLine = '─',
        VerticalStraightLine = '│',
        VerticalSlimLine = '│',
        Crossbar = '┼',
        CrossbarLeft = '├',
        CrossbarRight = '┤',
        LeftUpLine = '┌',
        RightUpLine = '┐',
        LeftDownLine = '└',
        RightDownLine = '┘',
        CenterUpLine = '┬',
        CenterDownLine = '┴',
    }
    static class Frame
    {
        public static int upLineFrame, downLineFrame;
        public static int vLineCoordX_1, vLineCoordX_2, vLineCoordX_3, vLineCoordX_4, vLineCoordX_5, vLineCoordX_6, vLineCoordX_7;


        public static void DrawingFrame(int upLineFrame, int downLineFrame)
        {
            Frame.upLineFrame = upLineFrame;
            Frame.downLineFrame = downLineFrame;
            vLineCoordX_1 = 0;
            vLineCoordX_7 = Console.WindowWidth - 1;
            vLineCoordX_4 = Console.WindowWidth / 2;
            vLineCoordX_2 = Console.WindowWidth / 6;
            vLineCoordX_3 = Console.WindowWidth / 3;
            vLineCoordX_5 = (Console.WindowWidth / 6) + (Console.WindowWidth / 2);
            vLineCoordX_6 = (Console.WindowWidth / 3) + (Console.WindowWidth / 2);

            MenuItem();
            Header();
            Body();
            Footer();
        }
        static void MenuItem()
        {
            Writer.Text(2, upLineFrame, ("L", Color.IndianRed), ("eft", ColorBase.DefaultText));
            Writer.Text(8, upLineFrame, ("F", Color.IndianRed), ("ile", ColorBase.DefaultText));
            Writer.Text(14, upLineFrame, ("C", Color.IndianRed), ("ommand", ColorBase.DefaultText));
            Writer.Text(23, upLineFrame, ("O", Color.IndianRed), ("ptions", ColorBase.DefaultText));
            Writer.Text(32, upLineFrame, ("R", Color.IndianRed), ("ight", ColorBase.DefaultText));
        }
        static void Header()
        {
            Writer.Text(0, upLineFrame + 1, (Line.LeftUpLine, ColorBase.DefaultText));

            for (int i = 1;i < Console.WindowWidth - 1;i++)
            {
                if (Console.WindowHeight != 0)
                    Console.SetCursorPosition(i, upLineFrame + 1);
                if (Console.WindowWidth / 2 == i)
                {
                    Writer.Text((Line.CenterUpLine, ColorBase.DefaultText));
                    continue;
                }
                Writer.Text((Line.HorizontalStraightLine, SettingsUI.ForegroundColorDefault));
            }
            Writer.Text((Line.RightUpLine, SettingsUI.ForegroundColorDefault));
            Writer.Text(0, upLineFrame + 2, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
            Writer.Text(Console.WindowWidth / 2, upLineFrame + 2, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
            Writer.Text(Console.WindowWidth - 1, upLineFrame + 2, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
            Writer.Text(0, upLineFrame + 3, (Line.CrossbarLeft, SettingsUI.ForegroundColorDefault));


            for (int i = 1;i < Console.WindowWidth - 1;i++)
            {
                Console.SetCursorPosition(i, upLineFrame + 3);
                if (Console.WindowWidth / 2 == i)
                {
                    Writer.Text((Line.Crossbar, SettingsUI.ForegroundColorDefault));
                    continue;
                }
                Writer.Text((Line.HorizontalStraightLine, SettingsUI.ForegroundColorDefault));
            }
            Writer.Text(Console.WindowWidth - 1, upLineFrame + 3, (Line.CrossbarRight, SettingsUI.ForegroundColorDefault));
        }
        static void Body()
        {
            for (int i = upLineFrame + 4;i < downLineFrame;i++)
            {
                Writer.Text(vLineCoordX_1, i, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
                Writer.Text(vLineCoordX_4, i, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
                Writer.Text(vLineCoordX_7, i, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
            }
            for (int i = upLineFrame + 4;i < downLineFrame - 1;i++)
            {
                Writer.Text(vLineCoordX_1, i, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
                Writer.Text(vLineCoordX_2, i, (Line.VerticalSlimLine, SettingsUI.ForegroundColorDefault));
                Writer.Text(vLineCoordX_3, i, (Line.VerticalSlimLine, SettingsUI.ForegroundColorDefault));
                Writer.Text(vLineCoordX_5, i, (Line.VerticalSlimLine, SettingsUI.ForegroundColorDefault));
                Writer.Text(vLineCoordX_6, i, (Line.VerticalSlimLine, SettingsUI.ForegroundColorDefault));
            }
        }
        static void Footer()
        {
            Writer.Text(0, downLineFrame, (Line.CrossbarLeft, SettingsUI.ForegroundColorDefault));

            for (int i = 1;i < Console.WindowWidth - 1;i++)
            {
                Console.SetCursorPosition(i, downLineFrame - 2);
                if (Console.WindowWidth / 2 == i)
                {
                    Writer.Text((Line.Crossbar, SettingsUI.ForegroundColorDefault));
                    continue;
                }
                Writer.Text((Line.HorizontalStraightLine, SettingsUI.ForegroundColorDefault));
            }
            Writer.Text((Line.CrossbarRight, SettingsUI.ForegroundColorDefault));

            Writer.Text(0, downLineFrame - 1, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
            Writer.Text(Console.WindowWidth / 2, downLineFrame - 1, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
            Writer.Text(Console.WindowWidth - 1, downLineFrame - 1, (Line.VerticalStraightLine, SettingsUI.ForegroundColorDefault));
            Writer.Text(0, downLineFrame, (Line.LeftDownLine, SettingsUI.ForegroundColorDefault));

            for (int i = 1;i < Console.WindowWidth - 1;i++)
            {
                Console.SetCursorPosition(i, downLineFrame);
                if (Console.WindowWidth / 2 == i)
                {
                    Writer.Text((Line.CenterDownLine, SettingsUI.ForegroundColorDefault));
                    continue;
                }
                Writer.Text((Line.HorizontalStraightLine, SettingsUI.ForegroundColorDefault));
            }

            Writer.Text(Console.WindowWidth - 1, downLineFrame, (Line.RightDownLine, SettingsUI.ForegroundColorDefault));
        }
    }
}
