namespace DailyWheel.Model
{
    public class BoardSpace
    {
        public bool NeverUsed { get; set; }
        public bool InPlay => Letter != null;
        public bool IsGiven { get; set; }
        public char? Letter { get; set; }

        public static BoardSpace[,] CreateEmptyBoard()
        {
            var board = new BoardSpace[BoardDimensions.Rows, BoardDimensions.Columns];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = new BoardSpace { NeverUsed = SpaceNeverUsed(row, col) };
                }
            }
            return board;

            static bool SpaceNeverUsed(int row, int col)
            {
                return
                    (row == 0 && (col == 0 || col == 13)) ||
                    (row == 3 && (col == 0 || col == 13));
            }
        }
    }

    public static class BoardDimensions
    {
        public const int Rows = 4;
        public const int Columns = 14;
    }
}
