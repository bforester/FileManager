using System.Drawing;
using Console = Colorful.Console;

namespace FileManager.View
{
    struct ColorBase
    {
        public static Color DefaultBackground { get; set; } = Color.FromArgb(39, 40, 34);
        public static Color DefaultText { get; set; } = Color.LightYellow;
        public static Color HighlightBackground { get; set; } = Color.GhostWhite;
        public static Color HighlightText { get; set; } = Color.LawnGreen;
        public static Color WarningText { get; set; } = Color.Black;
        
    }
}
