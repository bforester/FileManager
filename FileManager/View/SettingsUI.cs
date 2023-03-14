using System.Drawing;
using Console = Colorful.Console;

namespace FileManager.View
{
    static class SettingsUI
    {
        public static string Title { get; set; } = "FileManager";
        public static int WindowWidth { get; set; } = 120;
        public static int WindowHeight { get; set; } = 30;
        public static int BufferWidth { get; set; } = 120;
        public static int BufferHeight { get; set; } = 30;
        public static Color BackgroundColorDefault { get; set; } = Color.FromArgb(39, 40, 34);
        public static Color ForegroundColorDefault { get; set; } = Color.LightYellow;
        public static Color HighlightColorBackground { get; set; } = Color.GhostWhite;
        public static Color HighlightColorForeground { get; set; } = Color.LawnGreen;
        public static Color WarningColorForeground { get; set; } = Color.Black;


        static SettingsUI()
        {
            //Console.SetWindowSize(Width, Height);
        }

        public static void Update()
        {
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            //Console.SetBufferSize(Width, Height);
            //BufferWidth = Console.BufferWidth;
            //BufferHeight = Console.BufferHeight;
            if (WindowWidth > Console.BufferWidth || WindowHeight > Console.BufferHeight)
            {
                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            }

        }
        public static void FirstInit()
        {
            Console.Title = Title;
            Console.BackgroundColor = BackgroundColorDefault;
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.SetBufferSize(BufferWidth, BufferHeight);
            Console.CursorVisible = false;

            
        }
    }
}
