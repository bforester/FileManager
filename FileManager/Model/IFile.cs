namespace FileManager.Model
{
    interface IFIle
    {
        string Name { get; set; }
        string Path { get; set; }
        bool Hidden { get; set; }

        void Copy();
        void Delete();
        void Rename();
        void Create();
        void Settings();
        void Move();
    }
}
