using System;
using System.ComponentModel;
using System.IO;
using AdventOfCode;

namespace AoC2021
{
    class Program
    {
        static void Main(string[] args)
        {
            new Day1Part1Solution().CalculateSolution();
            new Day1Part2Solution().CalculateSolution();
        }
    }

    [DisplayName("Day 1/Part 1 Solution")]
    class Day1Part1Solution : SolutionBase
    {
        public override void CalculateSolution()
        {
            int[] numbers = Array.ConvertAll(Lines, int.Parse);
            int increases = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                var previous = numbers[i - 1];
                var current = numbers[i];

                if (current > previous)
                {
                    increases++;
                }
            }

            RenderResult("Increases", increases);
        }
    }

    [DisplayName("Day 1/Part 2 Solution")]
    class Day1Part2Solution : SolutionBase
    {
        public override void CalculateSolution()
        {
            int[] numbers = Array.ConvertAll(Lines, int.Parse);
            int increases = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (i + 2 >= numbers.Length)
                {
                    break;
                }

                var previous = numbers[i - 1] + numbers[i] + numbers[i + 1];
                var current = numbers[i] + numbers[i + 1] + numbers[i + 2];

                if (current > previous)
                {
                    increases++;
                }
            }

            RenderResult("Windowed increases", increases);
        }
    }
}
