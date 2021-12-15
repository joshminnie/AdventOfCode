using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day5.Support
{
    public class Line
    {
        public Point StartingPoint
        {
            get;
            private set;
        }

        public Point EndingPoint
        {
            get;
            private set;
        }

        public bool IsHorizontal
        {
            get
            {
                return StartingPoint.X == EndingPoint.X;
            }
        }

        public bool IsVertical
        {
            get
            {
                return StartingPoint.Y == EndingPoint.Y;
            }
        }

        public Line(Point p1, Point p2)
        {
            var points = new List<Point> { p1, p2 };
            points.Sort(new PointComparer());

            StartingPoint = points.First();
            EndingPoint = points.Last();
        }

        public List<Point> GetAllPoints()
        {
            var points = new List<Point> { StartingPoint, EndingPoint };

            if (IsHorizontal)
            {
                for (int i = StartingPoint.Y + 1; i < EndingPoint.Y; i++)
                {
                    points.Add(new Point(StartingPoint.X, i));
                }
            }
            else if (IsVertical)
            {
                for (int i = StartingPoint.X + 1; i < EndingPoint.X; i++)
                {
                    points.Add(new Point(i, StartingPoint.Y));
                }
            }

            return points;
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            if (a.X.CompareTo(b.X) != 0)
            {
                return a.X.CompareTo(b.X);
            }
            else if (a.Y.CompareTo(b.Y) != 0)
            {
                return a.Y.CompareTo(b.Y);
            }
            else
            {
                return 0;
            }
        }
    }
}
