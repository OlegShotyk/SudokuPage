namespace SudokuPage.Models
{
    public class BoardRow
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private List<BoardElement> _rowElements = new List<BoardElement>();

        public List<BoardElement> RowElements
        {
            get { return _rowElements; }
            set { _rowElements = value; }
        }
    }
}
