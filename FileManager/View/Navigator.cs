using System.Drawing;
using Console = Colorful.Console;
namespace FileManager.View
{
    class Navigator
    {
        static int xCursorPosition = 2;
        static int yCursorPosition = 5;
        static int selectionLength = 10;
        public void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    SetPosition(xCursorPosition, yCursorPosition+1);
                    break;
            }
        }

        void SetPosition(int newXPos, int newYPos)
        {

            for (int i = xCursorPosition; i < selectionLength; i++)
            {
                Console.SetCursorPosition(i, yCursorPosition);
                Console.BackgroundColor = ColorBase.DefaultBackground;
                Console.ForegroundColor = ColorBase.DefaultText;
            }

            for (int i = newXPos; i < selectionLength; i++)
            {
                Console.SetCursorPosition(i, newYPos);
                Console.BackgroundColor = Color.White;
                Console.ForegroundColor = Color.Black;
            }
            xCursorPosition = newXPos;
            yCursorPosition = newYPos;


        }
    }
}
