using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4.Support
{
    public class BingoBoard
    {
        private const int SIZE = 5;

        public List<BingoSquare> Squares { get; set; }

        public BingoBoard(string[] lines)
        {
            Squares = new List<BingoSquare>(25);

            for (int i = 0; i < lines.Length; i++)
            {
                var values = Array.ConvertAll(Regex.Split(lines[i].Trim(), @"\s+", RegexOptions.IgnoreCase), int.Parse);

                for (int j = 0; j < values.Length; j++)
                {
                    Squares.Add(new BingoSquare(values[j], new Point(i, j)));
                }
            }
        }

        public BingoSquare Mark(int value)
        {
            var square = Squares.Find((BingoSquare bs) => bs.Value == value);

            if (square != null)
            {
                square.Select();
            }

            return square;
        }

        public bool CheckBingo()
        {

            for (int i = 0; i < SIZE; i++)
            {
                if (SelectedInRow(i).Count == SIZE || SelectedInColumn(i).Count == SIZE)
                    return true;
            }

            return false;
        }

        public int Score(int lastCalled)
        {
            var unmarked = Squares.FindAll(s => !s.Selected).Sum(s => s.Value);
            return unmarked * lastCalled;
        }

        private List<BingoSquare> SelectedInRow(int row)
        {
            return Squares.FindAll(bs => bs.Point.X == row && bs.Selected);
        }

        private List<BingoSquare> SelectedInColumn(int column)
        {
            return Squares.FindAll(bs => bs.Point.Y == column && bs.Selected);
        }
    }
}
