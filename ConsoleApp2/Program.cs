using System.Drawing;

using Console = Colorful.Console;
namespace ConsoleGraphics
{
    enum Line
    {
        HorizontalStraightLine = '═',
        VerticalStraightLine = '║',
        Crossbar = '╬',
        CrossbarLeft = '╠',
        CrossbarRight = '╣',
        LeftUpLine = '╔',
        RightUpLine = '╗',
        LeftDownLine = '╚',
        RightDownLine = '╝',
        CenterUpLine = '╦',
        CenterDownLine = '╩',
    }


    class ConsoleMenu
    {
        static void Main()
        {
            new DrawMenu().DrawingInterface();
        }
    }

    class DrawMenu
    {
        Color textColor = Color.LightYellow;
        Color bacgroundColor = Color.FromArgb(39, 40, 34);

        int windowWidth;
        int windowHeight;

        public void DrawingInterface()
        {
            while (true)
            {
                Thread.Sleep(300);
                if ((Console.WindowHeight != windowHeight || Console.WindowWidth != windowWidth) && (Console.WindowWidth > 20 && Console.WindowHeight > 20))
                {
                    DrawFrame();
                }
                windowWidth = Console.WindowWidth;
                windowHeight = Console.WindowHeight;
            }
        }


        void DrawFrame()
        {
            Console.Title = "FileHandler";
            Console.BackgroundColor = bacgroundColor;
            Console.Clear();
            Console.CursorVisible = false;

            MenuItem();
            Header();
            Body();
            Footer();
            new Content().DrawContent();
        }
        void MenuItem()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("FILE_HANDLER_V_0.1", Color.DarkSeaGreen);
        }
        void Header()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write((char)Line.LeftUpLine, textColor);

            for (int i = 1;i < Console.WindowWidth - 1;i++)
            {
                Console.SetCursorPosition(i, 1);
                if (Console.WindowWidth / 2 == i)
                {
                    Console.Write((char)Line.CenterUpLine, textColor);
                    continue;
                }
                Console.Write((char)Line.HorizontalStraightLine, textColor);
            }
            Console.Write((char)Line.RightUpLine, textColor);

            Console.SetCursorPosition(0, 2);
            Console.Write((char)Line.VerticalStraightLine, textColor);
            Console.SetCursorPosition(Console.WindowWidth / 2, 2);
            Console.Write((char)Line.VerticalStraightLine, textColor);
            Console.SetCursorPosition(Console.WindowWidth - 1, 2);
            Console.Write((char)Line.VerticalStraightLine, textColor);

            Console.SetCursorPosition(0, 3);
            Console.Write((char)Line.CrossbarLeft, textColor);

            for (int i = 1;i < Console.WindowWidth - 1;i++)
            {
                Console.SetCursorPosition(i, 3);
                if (Console.WindowWidth / 2 == i)
                {
                    Console.Write((char)Line.Crossbar, textColor);
                    continue;
                }
                Console.Write((char)Line.HorizontalStraightLine, textColor);
            }

            Console.SetCursorPosition(Console.WindowWidth - 1, 3);
            Console.Write((char)Line.CrossbarRight, textColor);
        }
        void Body()
        {
            for (int i = 4;i < Console.WindowHeight - 3;i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write((char)Line.VerticalStraightLine, textColor);
                Console.SetCursorPosition(Console.WindowWidth / 2, i);
                Console.Write((char)Line.VerticalStraightLine, textColor);
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write((char)Line.VerticalStraightLine, textColor);
            }
        }
        void Footer()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.Write((char)Line.CrossbarLeft, textColor);

            for (int i = 1;i < Console.WindowWidth - 1;i++)
            {
                Console.SetCursorPosition(i, Console.WindowHeight - 3);
                if (Console.WindowWidth / 2 == i)
                {
                    Console.Write((char)Line.Crossbar, textColor);
                    continue;
                }
                Console.Write((char)Line.HorizontalStraightLine, textColor);
            }
            Console.Write((char)Line.CrossbarRight, textColor);

            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write((char)Line.VerticalStraightLine, textColor);
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight - 2);
            Console.Write((char)Line.VerticalStraightLine, textColor);
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 2);
            Console.Write((char)Line.VerticalStraightLine, textColor);

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write((char)Line.LeftDownLine, textColor);

            for (int i = 1;i < Console.WindowWidth - 1;i++)
            {
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                if (Console.WindowWidth / 2 == i)
                {
                    Console.Write((char)Line.CenterDownLine, textColor);
                    continue;
                }
                Console.Write((char)Line.HorizontalStraightLine, textColor);
            }

            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
            Console.Write((char)Line.RightDownLine, textColor);
        }

        void Clear(int StartCoordinateX, int StartCoordinateY, int EndCoordinateX, int EndCoordinateY)
        {
            for (int i = StartCoordinateY;i <= EndCoordinateY;i++)
            {
                for (int j = StartCoordinateX;j <= EndCoordinateX;j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");

                }
            }
        }

        class Content
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            public bool isReadyDisk = false;

            public Content()
            {
                DriveInfo[] allDrivesInit = DriveInfo.GetDrives();
                InitializeDrives(allDrivesInit);
            }



            void InitializeDrives(DriveInfo[] allDrives)
            {
                int countDrives = 0;
                //string pathDriveDirectory;
                //DirectoryInfo[] directoryDrives = new DirectoryInfo[allDrives.Length];

                for (int i = 0;i < allDrives.Length;i++)
                {
                    if (allDrives[i].IsReady)
                    {
                        this.allDrives[countDrives] = allDrives[i];
                        //pathDriveDirectory = $"{this.allDrives[countDrives]}";
                        //directoryDrives[countDrives] = new DirectoryInfo(pathDriveDirectory);
                        countDrives++;
                    }
                    if (countDrives < 2)
                    {
                        this.allDrives[countDrives] = allDrives[0];
                    }
                }
            }


            public void DrawContent()
            {
                HeaderDisk(allDrives[0], allDrives[1]);
                Directory(allDrives[0], allDrives[1]);
                FooterDisk(allDrives[0], allDrives[1]);
            }


            void HeaderDisk(DriveInfo drive1, DriveInfo drive2)
            {

                Console.SetCursorPosition(2, 2);
                Console.Write($"{drive1}");
                Console.SetCursorPosition(Console.WindowWidth / 2 + 2, 2);
                Console.Write($"{drive2}");
                isReadyDisk = true;

            }

            void Directory(DriveInfo drive1, DriveInfo drive2)
            {
                string pathFirstDriveDirectory = $"{drive1}";
                string pathSecondDriveDirectory = $"{drive2}";
                DirectoryInfo directoryDrive1 = new DirectoryInfo(pathFirstDriveDirectory);
                DirectoryInfo directoryDrive2 = new DirectoryInfo(pathSecondDriveDirectory);
                DirectoryInfo[] dirs1 = directoryDrive1.GetDirectories();
                DirectoryInfo[] dirs2 = directoryDrive2.GetDirectories();
                FileInfo[] fileInfo1 = directoryDrive1.GetFiles();
                FileInfo[] fileInfo2 = directoryDrive2.GetFiles();

                for (int i = 0;i < dirs1.Length;i++)
                {
                    Console.SetCursorPosition(2, i + 5);
                    Console.WriteLine($"{dirs1[i]}");
                }


                for (int i = 0;i < dirs2.Length;i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 2, i + 5);
                    Console.WriteLine($"{dirs2[i]}");
                }

            }
            void FooterDisk(DriveInfo drive1, DriveInfo drive2)
            {
                Console.SetCursorPosition(2, Console.WindowHeight - 2);
                Console.Write($"{drive1.VolumeLabel} * " +
                              $"{drive1.DriveFormat} * " +
                              $"Free: {Math.Round(drive1.AvailableFreeSpace / 1024f / 1024f / 1024f, 2)}Gb * " +
                              $"Size: {Math.Round(drive1.TotalSize / 1024f / 1024f / 1024f, 2)}Gb * ");

                Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowHeight - 2);
                Console.Write($"{drive2.VolumeLabel} * " +
                              $"{drive2.DriveFormat} * " +
                              $"Free: {Math.Round(drive2.AvailableFreeSpace / 1024f / 1024f / 1024f, 2)}Gb * " +
                              $"Size: {Math.Round(drive2.TotalSize / 1024f / 1024f / 1024f, 2)}Gb * ");
            }

        }
    }

}

