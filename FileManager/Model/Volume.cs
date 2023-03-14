namespace FileManager.Model
{
    class Volume : VolumeHandler
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        List<DriveInfo> volumes = new List<DriveInfo>();
        public Volume()
        {
            foreach (var drive in allDrives)
            {
                if (drive.IsReady)
                    volumes.Add(drive);
            }

        }
        void ResizeArrayVolume()
        {

        }


        public override void RenameVolume()
        {

        }
    }
}
