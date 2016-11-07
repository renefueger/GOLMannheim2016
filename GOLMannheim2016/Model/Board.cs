namespace GOLMannheim2016.Model
{
    using System.Diagnostics;
    using System.Windows.Controls;

    public class Board
    {
        private readonly bool[][] _board;

        public Board(int givenWidth, int givenHeight)
        {
            Width = givenWidth;
            Height = givenHeight;
             _board = new bool[Height][];               

            for (var row = 0; row < Height; row++) {
                _board[row] = new bool[Width];
            }
        }

        override public string ToString()
        {
            var result = string.Empty;
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++) {
                    result += _board[row][column] ? "+" : "-";
                }
                if (row < Height - 1)
                    result += "\n";
            }
            return result;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public IRandomizer Randomizer { get; set; }

        public void CreateRandom()
        {
            for (var row = 0; row < Height; row++) {
                for (var column = 0; column < Width; column++) {
                    _board[row][column] = Randomizer.Randomize();
                }
            }
        }
    }
}