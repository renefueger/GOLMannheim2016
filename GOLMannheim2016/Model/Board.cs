namespace GOLMannheim2016.Model
{
    public class Board
    {
        public Board(int givenWidth, int givenHeight)
        {
            Width = givenWidth;
            Height = givenHeight;
        }

        override public string ToString()
        {
            var result = string.Empty;
            for (int row = 0; row < Height; row++) {
                for (int column = 0; column < Width; column++) {
                    result += "-";
                }
                if(row < Width-1)
                    result += "\n";
            }
            return result;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}