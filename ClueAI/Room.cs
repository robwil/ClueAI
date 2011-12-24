using System.Windows;
using System.Windows.Media;

namespace ClueAI
{
    public class Room
    {
        // constants
        public static readonly double FontSize = 24; 

        // properties
        public string Name { get; set; }
        public Brush ForegroundColor { get; set; }
        public Brush BackgroundColor { get; set; }
        public Point TopLeftCorner { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        public void Draw()
        {
            
        }
    }
}
