using FileManager.View;
using System.Drawing;
using static FileManager.View.DrawUI;
using Console = Colorful.Console;

namespace FileManager.Controller
{
    class Writer
    {
        public static void Text(int x, int y, params (string value, Color color)[] values)
        {
            foreach (var value in values)
            {
                if (Console.WindowHeight != 0)
                    Console.SetCursorPosition(x, y);
                Console.Write(value.value, value.color);
                x++;
            }
        }
        public static void Text(int x, int y, params (Line value, Color color)[] values)
        {
            foreach (var value in values)
            {
                if (Console.WindowHeight != 0)
                    Console.SetCursorPosition(x, y);
                Console.Write((char)value.value, value.color);
                x++;
            }
        }
        public static void Text(params (Line value, Color color)[] values)
        {
            foreach (var value in values)
            {
                Console.Write((char)value.value, value.color);
            }
        }

        public static void ErrorHandler(string e)
        {
            if (Console.BufferHeight > 0 || Console.BufferWidth > 0)
            {
                Console.Clear();
                Console.WriteLine(e);
            }

        }

        public static void AlertWindow(string title)
        {
            
            for (int i = Console.WindowHeight / 2 - 5;i < Console.WindowHeight / 2 + 5;i++)
            {
                for (int j = Console.WindowWidth / 2 - 25;j < Console.WindowWidth / 2 + 25;j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ", Console.BackgroundColor = Color.BurlyWood);
                }
                Console.WriteLine();
            }

            Writer.Text(Console.WindowWidth/2-title.Length/2, Console.WindowHeight/2-5, (title, Color.Black));





            Console.BackgroundColor = SettingsUI.BackgroundColorDefault;
        }
    }
}
