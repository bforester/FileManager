using FileManager.View;
using Console = Colorful.Console;

namespace FileManager
{
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
            string nameDirectory;
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
                //nameDirectory = dirs1[i].Name;
                if (dirs1[i].Name.Length < (Frame.vLineCoordX_2 - 2))
                    Console.WriteLine(dirs1[i].Name);
                else
                    Console.WriteLine(dirs1[i].Name.Substring(0, Frame.vLineCoordX_2 - 2));
            }
            for (int i = 0;i < fileInfo1.Length;i++)
            {
                Console.SetCursorPosition(2, i + dirs1.Length + 5);
                Console.WriteLine($"{fileInfo1[i]}", SettingsUI.HighlightColorForeground);
            }


            for (int i = 0;i < dirs2.Length;i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 + 2, i + 5);
                Console.WriteLine($"{dirs2[i]}");
            }
            for (int i = 0;i < fileInfo2.Length;i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 + 2, i + dirs2.Length + 5);
                Console.WriteLine($"{fileInfo2[i]}", SettingsUI.HighlightColorForeground);
            }

        }
        void FooterDisk(DriveInfo drive1, DriveInfo drive2)
        {
            Console.SetCursorPosition(2, Console.WindowHeight - 4);
            Console.Write($"{drive1.VolumeLabel} * " +
                          $"{drive1.DriveFormat} * " +
                          $"Free: {Math.Round(drive1.AvailableFreeSpace / 1024f / 1024f / 1024f, 2)}Gb * " +
                          $"Size: {Math.Round(drive1.TotalSize / 1024f / 1024f / 1024f, 2)}Gb * ");

            Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowHeight - 4);
            Console.Write($"{drive2.VolumeLabel} * " +
                          $"{drive2.DriveFormat} * " +
                          $"Free: {Math.Round(drive2.AvailableFreeSpace / 1024f / 1024f / 1024f, 2)}Gb * " +
                          $"Size: {Math.Round(drive2.TotalSize / 1024f / 1024f / 1024f, 2)}Gb * ", SettingsUI.WarningColorForeground);
        }

    }
}
