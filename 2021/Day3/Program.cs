using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AdventOfCode;
using Day3.Support;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            new Day3Part1Solution().CalculateSolution();
            new Day3Part2Solution().CalculateSolution();
        }
    }

    public abstract class Day3SolutionBase : SolutionBase
    {
        /// <summary>
        /// Calculates the frequency of the digits in the given lines.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static Dictionary<int, Dictionary<char, int>> CalculateDigitFrequency(string[] lines)
        {
            var readouts = lines.Select(l => (BinaryString)l).ToArray();
            var frequencies = new Dictionary<int, Dictionary<char, int>>();
            foreach (var readout in readouts)
            {
                for (int i = 0; i < readout.Length; i++)
                {
                    if (!frequencies.ContainsKey(i))
                    {
                        frequencies.Add(i, new Dictionary<char, int> { { '0', 0 }, { '1', 0 } });
                    }

                    if (readout[i] == '0')
                    {
                        frequencies[i]['0']++;
                    }
                    else
                    {
                        frequencies[i]['1']++;
                    }
                }
            }

            return frequencies;
        }
    }

    [DisplayName("Day 3/Part 1 Solution")]
    class Day3Part1Solution : Day3SolutionBase
    {
        public override void CalculateSolution()
        {
            var frequencies = CalculateDigitFrequency(Lines);

            char[] gamma = new char[frequencies.Count],
                epsilon = new char[frequencies.Count];

            for (int i = 0; i < frequencies.Count; i++)
            {
                if (frequencies[i]['0'] > frequencies[i]['1'])
                {
                    gamma[i] = '0';
                    epsilon[i] = '1';
                }
                else
                {
                    epsilon[i] = '0';
                    gamma[i] = '1';
                }
            }

            int result = (BinaryString)gamma * (BinaryString)epsilon;

            RenderResult("Power consumption", result);
        }
    }

    [DisplayName("Day 3/Part 2 Solution")]
    class Day3Part2Solution : Day3SolutionBase
    {
        public override void CalculateSolution()
        {
            var oxygenRating = GetLinesByFrequency(Lines, 0, (hash, i) => hash[i]['0'] > hash[i]['1'] ? '0' : '1').FirstOrDefault();

            var co2ScrubberRating = GetLinesByFrequency(Lines, 0, (hash, i) => hash[i]['0'] > hash[i]['1'] ? '1' : '0').FirstOrDefault();

            int result = (BinaryString)oxygenRating * (BinaryString)co2ScrubberRating;

            RenderResult("Life support", result);
        }

        private string[] GetLinesByFrequency(string[] lines, int position, Func<Dictionary<int, Dictionary<char, int>>, int, char> predicate)
        {
            if (lines.Length <= 1)
            {
                return lines;
            }

            var frequencies = CalculateDigitFrequency(lines);
            var digit = predicate(frequencies, position);
            lines = lines.AsQueryable().Where(line => line.ToCharArray()[position] == digit).ToArray();

            return GetLinesByFrequency(lines, ++position, predicate);
        }
    }
}
