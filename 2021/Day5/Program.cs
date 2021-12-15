using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode;
using Day5.Support;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            new Day5Part1Solution().CalculateSolution();
            new Day5Part2Solution().CalculateSolution();
        }
    }

    public class Day5Part1Solution : SolutionBase
    {
        public override void CalculateSolution()
        {
            var lines = Lines;
            var vents = new List<Point>();

            for (int i = 0; i < lines.Length; i++)
            {
                var points = lines[i].Trim().Split(" -> ").Select((string s) =>
                {
                    var points = Array.ConvertAll(s.Split(","), int.Parse);
                    return new Point(points[0], points[1]);
                }).ToList();

                var line = new Line(points[0], points[1]);
                vents.AddRange(line.GetAllPoints());
            }

            var overlaps = from x in vents
                           group x by x into g
                           let count = g.Count()
                           orderby count descending
                           where count > 1
                           select new { Value = g.Key, Count = count };

            RenderResult("Part 1", null);
        }
    }

    public class Day5Part2Solution : SolutionBase
    {
        public override void CalculateSolution()
        {
            RenderResult("Part 1", null);
        }
    }
}
