using System.Drawing;

namespace Day4.Support
{
    public class BingoSquare
    {
        public int Value
        {
            get;
            private set;
        }

        public Point Point
        {
            get;
            private set;
        }

        public bool Selected
        {
            get;
            private set;
        }

        public BingoSquare(int value, Point point, bool selected = false)
        {
            Value = value;
            Point = point;
            Selected = selected;
        }

        public void Select()
        {
            Selected = true;
        }
    }
}
