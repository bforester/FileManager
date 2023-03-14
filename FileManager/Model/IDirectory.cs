namespace FileManager.Model
{
    interface IDirectory
    {
        string Name { get; set; }
        string Path { get; set; }
        bool Hidden { get; set; }

        void Copy(string path);
        void Delete();
        void Rename();
        void Create();
        void Settings();
        void Move(string path);
        void Sort();
        void DirectoryInitialize(string path);

    }
}
