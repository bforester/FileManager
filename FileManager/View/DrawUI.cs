using FileManager.Controller;

namespace FileManager.View
{
    class DrawUI
    {
        


        int windowWidth = 0;
        int windowHeight;

        public void DrawingInterface()
        {
            SettingsUI.FirstInit();
            
            while (true)
            {
                Thread.Sleep(500);
                if (Console.WindowHeight != windowHeight || Console.WindowWidth != windowWidth)
                {
                    ColorBase.SetDeafultColor();
                    try   
                    {
                        DrawFrame();
                        SettingsUI.Update();
                    }
                    catch (Exception e)
                    {
                        Writer.ErrorHandler(e.Message);
                        
                    }
                }       
                windowWidth = Console.WindowWidth;
                windowHeight = Console.WindowHeight;
                new Navigator().Move(Console.ReadKey().Key);
            }
        }
        void DrawFrame()
        {
            Console.Clear();
            Frame.DrawingFrame(0, Console.WindowHeight - 3);
            new DrawDirectory();
        }


    }
}
