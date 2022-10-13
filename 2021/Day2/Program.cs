using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using AdventOfCode;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Day2Part1Solution().CalculateSolutionAsync();
            new Day2Part2Solution().CalculateSolutionAsync();
        }
    }

    [DisplayName("Day 2/Part 1 Solution")]
    class Day2Part1Solution : SolutionBase
    {
        public override void CalculateSolutionAsync()
        {
            var directions = Lines.Select(p => p.Split(" ")).ToArray();
            int depth = 0, distance = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i][0])
                {
                    case "forward":
                        distance += int.Parse(directions[i][1]);
                        break;
                    case "up":
                        depth -= int.Parse(directions[i][1]);
                        break;
                    case "down":
                        depth += int.Parse(directions[i][1]);
                        break;
                }
            }

            RenderResult("Static position", depth * distance);
        }
    }

    [DisplayName("Day 2/Part 2 Solution")]
    class Day2Part2Solution : SolutionBase
    {
        public override void CalculateSolutionAsync()
        {
            var directions = Lines.Select(p => p.Split(" ")).ToArray();
            int depth = 0, angle = 0, distance = 0, movement;
            for (int i = 0; i < directions.Length; i++)
            {
                movement = int.Parse(directions[i][1]);
                switch (directions[i][0])
                {
                    case "forward":
                        distance += movement;
                        depth += angle * movement;
                        break;
                    case "up":
                        angle -= movement;
                        break;
                    case "down":
                        angle += movement;
                        break;
                }
            }

            RenderResult("Angled position", depth * distance);
        }
    }
}
