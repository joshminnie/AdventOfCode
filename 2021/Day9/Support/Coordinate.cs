using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day9.Support
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }
        public int Value { get; }

        public Coordinate(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }

        public List<Coordinate> FindAdjacents(int[][] values)
        {
            var adjacents = new List<Coordinate>
            {
                GetCoordinate(values, X - 1, Y), // top
                GetCoordinate(values, X + 1, Y), // bottom
                GetCoordinate(values, X, Y - 1), // left
                GetCoordinate(values, X, Y + 1) // right
            };

            adjacents.RemoveAll(x => x == null);

            return adjacents;
        }

        private Coordinate GetCoordinate(int[][] values, int x, int y)
        {
            if (x < 0 || x >= values.Length || y < 0 || y >= values[x].Length)
            {
                return null;
            }
            else
            {
                return new Coordinate(x, y, values[x][y]);
            }
        }
    }
}
