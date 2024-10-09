namespace SudokuPage.Models
{
    public class BoardRequest
    {
        private int[][] _board;

        public int[][] board
        {
            get { return _board; }
            set { _board = value; }
        }
    }
}
