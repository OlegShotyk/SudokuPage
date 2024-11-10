namespace SudokuPage.Components.Pages
{
    public class BoardElement
    {
        public enum CellColors
        {
            white,
            red
        }

        private CellColors _cellColor;

        public CellColors CellColor
        {
            get { return _cellColor; }
            set { _cellColor = value; }
        }


        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _value;


        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }


        private bool _isReadonly;

        public bool IsReadonly
        {
            get { return _isReadonly; }
            set { _isReadonly = value; }
        }


        private int _fontWeight;

        public int FontWeight
        {
            get { return _fontWeight; }
            set { _fontWeight = value; }
        }

    }
}
