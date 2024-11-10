using SudokuPage.Components.Pages;

namespace SudokuPage.Models
{
    public class BoardGenerator
    {
        private const int boardSize = 9;
        private const int squareSize = 3;

        private List<BoardRow> _board;

		public List<BoardRow> Board
        {
			get { return _board; }
			set { _board = value; }
		}

        public List<BoardRow> NewGame(int hiddenValuesCount)
        {
            GenerateBoard();
            Random random = new Random();
            for (int shuffleQuantity = 0; shuffleQuantity < 1; shuffleQuantity++)
            {
                ShuffleMap(random.Next(0, 5));
            }
            HideValues(hiddenValuesCount);
            return Board;
        }

        private void HideValues( int hiddenValuesCount)
        {
            Random random = new Random();
            for(int rowIndex = 0; rowIndex < boardSize; rowIndex++)
            {
                for(int columnIndex = 0; columnIndex < boardSize; columnIndex++)
                {
                    int randomValue = random.Next(0, hiddenValuesCount);
                    if (randomValue <= 4)
                    {
                        _board[rowIndex].RowElements[columnIndex].Value = "";
                    }
                }
            }
        }

        private void GenerateBoard()
        {
            foreach (BoardRow row in _board)
            {
                int elementIndex = 0;
                foreach (BoardElement element in row.RowElements)
                {
                    int elementValue = (row.Id * squareSize + row.Id / squareSize + elementIndex) % (boardSize) + 1;
                    element.Value = elementValue.ToString();
                    elementIndex++;
                }
            }
        }

        private void ShuffleMap(int random)
        {
            switch (random)
            {
                case 0:
                    BoardTransposition();
                    break;
                case 1:
                    SwapRowsInSquare();
                    break;
                case 2:
                    SwapColumnsInSquare();
                    break;
                case 3:
                    SwapSquaresInRow();
                    break;
                case 4:
                    SwapSquaresInColumn();
                    break;
                default:
                    BoardTransposition();
                    break;
            }
        }

        private void BoardTransposition()
        {
            int[,] temporaryBoard = new int[boardSize, boardSize];
            foreach (BoardRow row in _board)
            {
                int elementIndex = 0;
                foreach (BoardElement element in row.RowElements)
                {
                    temporaryBoard[elementIndex, row.Id] = int.Parse(element.Value);
                    elementIndex++;
                }
            }

            foreach (BoardRow row in _board)
            {
                int elementIndex = 0;
                foreach (BoardElement element in row.RowElements)
                {
                    element.Value = temporaryBoard[row.Id, elementIndex].ToString();
                    elementIndex++;
                }
            }
        }

        private void SwapRowsInSquare()
        {
            Random random = new Random();
            int square = random.Next(0, squareSize);
            int row1 = random.Next(0, squareSize);
            int line1 = square * squareSize + row1;
            int row2 = random.Next(0, squareSize);
            while (row1 == row2)
                row2 = random.Next(0, squareSize);
            int line2 = square * squareSize + row2;
            for (int elementIndex = 0; elementIndex < boardSize; elementIndex++)
            {
                int temporaryValue = int.Parse(_board[line1].RowElements[elementIndex].Value);
                _board[line1].RowElements[elementIndex].Value = _board[line2].RowElements[elementIndex].Value;
                _board[line2].RowElements[elementIndex].Value = temporaryValue.ToString();
            }
        }

        private void SwapColumnsInSquare()
        {
            Random random = new Random();
            int square = random.Next(0, squareSize);
            int row1 = random.Next(0, squareSize);
            int line1 = square * squareSize + row1;
            int row2 = random.Next(0, squareSize);
            while (row1 == row2)
                row2 = random.Next(0, squareSize);
            int line2 = square * squareSize + row2;
            for (int elementIndex = 0; elementIndex < boardSize; elementIndex++)
            {
                int temporaryValue = int.Parse(_board[elementIndex].RowElements[line1].Value);
                _board[elementIndex].RowElements[line1].Value = _board[elementIndex].RowElements[line2].Value;
                _board[elementIndex].RowElements[line2].Value = temporaryValue.ToString();
            }
        }

        private void SwapSquaresInRow()
        {
            Random random = new Random();
            int square1 = random.Next(0, squareSize);
            int square2 = random.Next(0, squareSize);
            while (square1 == square2)
                square2 = random.Next(0, squareSize);
            square1 *= squareSize;
            square2 *= squareSize;
            for (int columnIndex = 0; columnIndex < boardSize; columnIndex++)
            {
                int squareIndex = square2;
                for (int rowIndex = square1; rowIndex < square1 + squareSize; rowIndex++)
                {
                    int temporaryValue = int.Parse(_board[rowIndex].RowElements[columnIndex].Value);
                    _board[rowIndex].RowElements[columnIndex].Value = _board[squareIndex].RowElements[columnIndex].Value;
                    _board[squareIndex].RowElements[columnIndex].Value = temporaryValue.ToString();
                    temporaryValue++;
                }
            }
        }

        private void SwapSquaresInColumn()
        {
            Random random = new Random();
            int square1 = random.Next(0, squareSize);
            int square2 = random.Next(0, squareSize);
            while (square1 == square2)
                square2 = random.Next(0, squareSize);
            square1 *= squareSize;
            square2 *= squareSize;
            for (int columnIndex = 0; columnIndex < boardSize; columnIndex++)
            {
                int squareIndex = square2;
                for (int rowIndex = square1; rowIndex < square1 + squareSize; rowIndex++)
                {
                    int temporaryValue = int.Parse(_board[columnIndex].RowElements[rowIndex].Value);
                    _board[columnIndex].RowElements[rowIndex].Value = _board[columnIndex].RowElements[squareIndex].Value;
                    _board[columnIndex].RowElements[squareIndex].Value = temporaryValue.ToString();
                    temporaryValue++;
                }
            }
        }
    }
}