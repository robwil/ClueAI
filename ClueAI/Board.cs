using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClueAI
{
    public class Board
    {
        public static readonly int CellWidth = 30;
        public static readonly int CellHeight = 30;

        public static readonly int Width = 6+2+8+2+6;
        public static readonly int Height = 6+2+7+3+6;

        private List<Room> rooms;
        private List<Point> cells;

        public Board()
        {
            rooms = new List<Room>();
            cells = new List<Point>();

            // construct cells
            AddCellsInXYRange(1, 6, 7, 8);
            AddCellsInXYRange(7, 8, 1, 8);
            AddCellsInXYRange(19, 24, 6, 7);
            AddCellsInXYRange(17, 18, 1, 13);
            AddCellsInXYRange(9, 16, 8, 9);
            AddCellsInXYRange(9, 10, 10, 15);
            AddCellsInXRange(13, 19, 24);
            AddCellsInXYRange(1, 9, 16, 18);
            AddCellsInYRange(10, 16, 17);
            AddCellsInXRange(17, 11, 15);
            AddCellsInYRange(16, 10, 13);
            AddCellsInXYRange(16,17, 14, 24);
            AddCellsInXYRange(8, 9, 19, 24);
            AddCellsInXYRange(18, 24, 19, 20);

            // construct rooms
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.AntiqueWhite,
                              ForegroundColor = Brushes.MediumSeaGreen,
                              Name = "Kitchen",
                              TopLeftCorner = new Point(1, 1),
                              Height = 6,
                              Width = 6
                          });
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.OldLace,
                              ForegroundColor = Brushes.DodgerBlue,
                              Name = "Ball Room",
                              TopLeftCorner = new Point(9, 1),
                              Height = 7,
                              Width = 8
                          });
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.MediumPurple,
                              ForegroundColor = Brushes.White,
                              Name = "Conservatory",
                              TopLeftCorner = new Point(19, 1),
                              Height = 5,
                              Width = 6
                          });
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.LightBlue,
                              ForegroundColor = Brushes.DarkBlue,
                              Name = "Dining Room",
                              TopLeftCorner = new Point(1, 9),
                              Height = 7,
                              Width = 8
                          });
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.ForestGreen,
                              ForegroundColor = Brushes.LightGreen,
                              Name = "Billiard Room",
                              TopLeftCorner = new Point(19, 8),
                              Height = 5,
                              Width = 6
                          });
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.DeepPink,
                              ForegroundColor = Brushes.Black,
                              Name = "Lounge",
                              TopLeftCorner = new Point(1, 19),
                              Height = 6,
                              Width = 7
                          });
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.DarkRed,
                              ForegroundColor = Brushes.IndianRed,
                              Name = "Library",
                              TopLeftCorner = new Point(18, 14),
                              Height = 5,
                              Width = 7
                          });
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.RoyalBlue,
                              ForegroundColor = Brushes.PaleVioletRed,
                              Name = "Hall",
                              TopLeftCorner = new Point(10, 18),
                              Height = 7,
                              Width = 6
                          });
            rooms.Add(new Room
                          {
                              BackgroundColor = Brushes.SaddleBrown,
                              ForegroundColor = Brushes.DarkOrange,
                              Name = "Study",
                              TopLeftCorner = new Point(18, 21),
                              Height = 4,
                              Width = 7
                          });
        }

        private void AddCellsInXYRange(int xLo, int xHi, int yLo, int yHi)
        {
            for (int x = xLo; x <= xHi; x++)
                for (int y = yLo; y <= yHi; y++)
                    cells.Add(new Point(x, y));
        }

        private void AddCellsInYRange(int x, int yLo, int yHi)
        {
            for (int y = yLo; y <= yHi; y++)
                cells.Add(new Point(x, y));
        }

        private void AddCellsInXRange(int y, int xLo, int xHi)
        {
            for (int x = xLo; x <= xHi; x++)
                cells.Add(new Point(x, y));
        }

        public void Draw(Canvas boardCanvas)
        {
            // Draw Cells
            foreach (Point cell in cells)
            {
                Rectangle r = new Rectangle { Stroke = Brushes.Black, Fill = Brushes.Gray, Height = CellHeight, Width = CellWidth };
                Canvas.SetLeft(r, (cell.X - 1) * CellWidth);
                Canvas.SetTop(r, (cell.Y - 1) * CellHeight);
                boardCanvas.Children.Add(r);
            }

            // Draw Rooms
            foreach (Room room in rooms)
            {
                Border b = new Border
                               {
                                   BorderBrush = room.ForegroundColor,
                                   Background = room.BackgroundColor,
                                   Height = room.Height * CellHeight,
                                   Width = room.Width * CellWidth
                               };

                Canvas.SetLeft(b, (room.TopLeftCorner.X - 1) * CellWidth);
                Canvas.SetTop(b, (room.TopLeftCorner.Y - 1) * CellHeight);
                TextBlock text = new TextBlock
                                     {
                                         Foreground = room.ForegroundColor,
                                         Text = room.Name,
                                         FontSize = Room.FontSize,
                                         HorizontalAlignment = HorizontalAlignment.Center,
                                         VerticalAlignment = VerticalAlignment.Center
                                     };
                b.Child = text;
                boardCanvas.Children.Add(b);
            }
        }
    }
}
