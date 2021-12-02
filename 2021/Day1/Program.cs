using System;
using System.IO;

namespace AoC2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"input.txt");
            int[] numbers = Array.ConvertAll<string, int>(lines, int.Parse);

            Console.WriteLine("{0} single step increase found.", SingleStepIncreases(lines));

            Console.WriteLine("{0} windowed increases found.", WindowedIncreases(numbers));
        }

        static int SingleStepIncreases(string[] lines)
        {
            int increases = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                var previous = Convert.ToInt64(lines[i - 1]);
                var current = Convert.ToInt64(lines[i]);

                if (current > previous)
                {
                    increases++;
                }
            }

            return increases;
        }

        static int WindowedIncreases(int[] numbers)
        {
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

            return increases;
        }
    }
}
