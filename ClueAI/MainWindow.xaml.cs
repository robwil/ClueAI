using System.Windows;
using System.Windows.Input;

namespace ClueAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Board board;

        public MainWindow()
        {
            InitializeComponent();
            board = new Board();
        }

        private void Draw()
        {
            // size and move controls into their dynamic positions
            boardCanvas.Width = Board.Width * Board.CellWidth;
            boardCanvas.Height = Board.Height * Board.CellHeight;

            board.Draw(boardCanvas);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Draw();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }
    }
}
