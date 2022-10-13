using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            new Day5Part1Solution().CalculateSolutionAsync();
            new Day5Part2Solution().CalculateSolutionAsync();
        }
    }

    public abstract class Day5SolutionBase : SolutionBase
    {
        public int FindOverlaps(List<Point> points)
        {
            var overlaps = new Dictionary<Point, int>();
            foreach (Point point in points)
            {
                if (overlaps.ContainsKey(point))
                {
                    overlaps[point] += 1;
                }
                else
                {
                    overlaps.Add(point, 1);
                }
            }

            return overlaps.Count(v => v.Value > 1);
        }
    }

    [DisplayName("Day 5 / Part 1 Solution")]
    public class Day5Part1Solution : Day5SolutionBase
    {
        public override void CalculateSolutionAsync()
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

            var count = FindOverlaps(vents);

            RenderResult("Part 1", count);
        }
    }

    [DisplayName("Day 5 / Part 2 Solution")]
    public class Day5Part2Solution : Day5SolutionBase
    {
        public override void CalculateSolutionAsync()
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
                vents.AddRange(line.GetAllPoints(true));
            }

            var count = FindOverlaps(vents);

            RenderResult("Part 1", count);
        }
    }
}
