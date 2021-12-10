using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AdventOfCode;
using Day9.Support;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            new Day9Part1Solution().CalculateSolution();
            new Day9Part2Solution().CalculateSolution();
        }
    }

    public abstract class Day9SolutionBase : SolutionBase
    {
        public int[][] Values {
            get
            {
                return Lines.Select(p => p.ToCharArray().Select(v => int.Parse(v.ToString())).ToArray()).ToArray();
            }
        }
    }


    [DisplayName("Day 9 / Part 1 Solution")]
    public class Day9Part1Solution : Day9SolutionBase
    {
        public override void CalculateSolution()
        {
            var lowPoints = new List<Coordinate>();

            for (int x = 0; x < Values.Length; x++)
            {
                for (int y = 0; y < Values[x].Length; y++)
                {
                    if (Values[x][y] == 9)
                        continue;

                    var origin = new Coordinate(x, y, Values[x][y]);
                    var adjacents = origin.FindAdjacents(Values);

                    if (adjacents.All(a => a.Value > origin.Value))
                    {
                        lowPoints.Add(origin);
                    }
                }
            }

            RenderResult("Risk level", lowPoints.Sum(p => p.Value + 1));
        }
    }

    [DisplayName("Day 9 / Part 2 Solution")]
    public class Day9Part2Solution : Day9SolutionBase
    {
        public override void CalculateSolution()
        {
            var basins = new List<List<Coordinate>>();

            for (int x = 0; x < Values.Length; x++)
            {
                for (int y = 0; y < Values[x].Length; y++)
                {
                    if (Values[x][y] == 9)
                        continue;

                    var origin = new Coordinate(x, y, Values[x][y]);
                    var adjacents = origin.FindAdjacents(Values);
                }
            }
        }
    }
}
