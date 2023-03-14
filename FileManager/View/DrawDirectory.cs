using FileManager.Controller;
using System.Drawing;

namespace FileManager.View
{
    class DrawDirectory
    {
        
        public DrawDirectory() 
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            LeftFrameContent(drives[0]);

            if (drives.Length>1)
                RightFrameContent(drives[1]);
            else
                RightFrameContent(drives[0]);
        }



        public static void LeftFrameContent(DriveInfo drive)
        {
            BodyDirectory(@$"{drive.Name}", 2);
            DiskInfo(drive, Console.WindowWidth / 4);
        }
        public static void RightFrameContent(DriveInfo drive)
        {
            BodyDirectory(@$"{drive.Name}", Console.WindowWidth / 2 + 2);
            DiskInfo(drive, Console.WindowWidth / 4 + Console.WindowWidth / 2);
        }


        static void BodyDirectory(string directory, int startX)
        {
            DirectoryInfo directoryDrive = new DirectoryInfo(directory);
            string shortName;
            int upFirstElementCoord = 0;
            int leftFirstElementCoord = startX;
            //Title
            Writer.Text(startX, 2, (directory, SettingsUI.HighlightColorForeground));

            //Body
            //Drawing Folders
            for (int i = 0;i < directoryDrive.GetDirectories().Length;i++)
            {
                
                if (upFirstElementCoord + 4 > Console.WindowHeight - 6)
                {
                    leftFirstElementCoord = Frame.vLineCoordX_2 + leftFirstElementCoord;
                    upFirstElementCoord = 0;
                }

                if (directoryDrive.GetDirectories()[i].Name.Length < (Frame.vLineCoordX_2 - 2))
                    shortName = $"{directoryDrive.GetDirectories()[i].Name}";
                else
                    shortName = $"{directoryDrive.GetDirectories()[i].Name.Substring(0, Frame.vLineCoordX_2 - 4)}..";

                Writer.Text(leftFirstElementCoord, upFirstElementCoord + 4, (shortName, ColorBase.DefaultText));
                upFirstElementCoord++;
                
            }

            //Drawing Files
            /*
            for (int i = 0;i < directoryDrive.GetFiles().Length;i++)
            {
                if (directoryDrive.GetFiles()[i].Name.Length < (Frame.vLineCoordX_2 - 2))
                    shortName = $"{directoryDrive.GetFiles()[i].Name}";
                else
                    shortName = $"{directoryDrive.GetFiles()[i].Name.Substring(0, Frame.vLineCoordX_2 - 4)}..";

                Writer.Text(startX, i + directoryDrive.GetDirectories().Length + 5, (shortName, Color.IndianRed));
            }
            */

            ElementInfo(directoryDrive.GetDirectories()[1], startX);


        }

        static void ElementInfo(DirectoryInfo directory, int startX)
        {
            string info = $"{directory.Parent}{directory.Name}";
            Console.SetCursorPosition(startX, Console.WindowHeight - 4);
            Console.Write(info);
        }

        //DiskInfo
        static void DiskInfo(DriveInfo drive, int startX)
        {
            string info = $" {drive.Name} {drive.VolumeLabel} {drive.DriveFormat} {drive.TotalSize / 1024 / 1024 / 1024f} {drive.AvailableFreeSpace/1024/1024/1024f} ";
            Console.SetCursorPosition(startX -info.Length/2, Console.WindowHeight - 3);
            Console.Write(info);
        }
    }
}
