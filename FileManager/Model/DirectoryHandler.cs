using FileManager.Controller;

namespace FileManager.Model
{
    class DirectoryHandler : IDirectory
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool Hidden { get; set; }

        DirectoryInfo directory;
        public DirectoryHandler(string path)
        {
            DirectoryInitialize(path);
        }

        public void Delete()
        {
            try { directory.Delete(true); }
            catch (Exception e) { Writer.ErrorHandler(e.Message); }
        }
        public void Move(string path)
        {

        }
        public void Copy(string path)
        {

        }

        public void Create()
        {

        }
        public void Rename()
        {

        }
        public void Settings()
        {

        }
        public void Sort()
        {

        }


        public void DirectoryInitialize(string path)
        {
            try
            {
                directory = new DirectoryInfo(path);
            }
            catch (Exception e) { Writer.ErrorHandler(e.Message); }
            Path = path;
        }
    }
}
