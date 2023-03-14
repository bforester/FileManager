using FileManager.Controller;
using System.Drawing;
using Console = Colorful.Console;

namespace FileManager.View
{
    class DrawUI
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


        int windowWidth = 0;
        int windowHeight;

        public void DrawingInterface()
        {
            SettingsUI.FirstInit();
            
            while (true)
            {
                Thread.Sleep(300);
                if (Console.WindowHeight != windowHeight || Console.WindowWidth != windowWidth)
                {
                    try   
                    {
                        DrawFrame();
                        SettingsUI.Update();
                    }
                    catch (Exception e)
                    {
                        //Writer.ErrorHandler(e.Message);
                        Writer.AlertWindow(e.Message);
                    }
                    
                }
                windowWidth = Console.WindowWidth;
                windowHeight = Console.WindowHeight;
            }
        }
        void DrawFrame()
        {
            Console.Clear();
            Frame.DrawingFrame(0, Console.WindowHeight - 3);
            new DrawDirectory();
        }

        void ReSizeWindow()
        {
            int targetWindowWidth = 0;
            int targetWindowHeight = 0;
            int targetBufferWidth = Console.BufferWidth;
            int targetBufferHeight = Console.BufferHeight;


            if (targetWindowWidth != Console.WindowWidth || targetWindowHeight != Console.WindowHeight)
            {
                targetWindowWidth = Console.WindowWidth;
                targetWindowHeight = Console.WindowHeight;


                if (targetWindowWidth > Console.BufferWidth || targetWindowHeight > Console.BufferHeight)
                {
                    Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                }


                if (Console.WindowHeight != 0)
                    Console.SetCursorPosition(0, 0);

            }
        }

    }
}
