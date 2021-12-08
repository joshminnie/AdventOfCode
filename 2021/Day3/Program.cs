using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "jack", "tom", "henry", "sally" };
            var result = input.AsQueryable().Where(name => name.Length > 4).ToArray();

            Console.WriteLine("Frequency digits result = {0}", CalculateFrequencyDigits());
            Console.WriteLine("Frequency entire number = {0}", CalculateFrequencyEntirety());
        }

        static char[][] ParseInput() {
            var lines = File.ReadAllLines(@"input.txt");
            return lines.Select(l => l.ToCharArray()).ToArray();
        }

        static Dictionary<int, Dictionary<char, int>> CalculateFrequencies(string[] lines)
        {
            var readouts = lines.Select(l => l.ToCharArray()).ToArray();
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
                    else if (readout[i] == '1')
                    {
                        frequencies[i]['1']++;
                    }
                    else
                    {
                        throw new Exception("readout did not resolve to value value");
                    }
                }
            }

            return frequencies;
        }

        static int CalculateFrequencyEntirety()
        {
            var lines = File.ReadAllLines(@"input.txt");
            var readouts = (string[])lines.Clone();
            var position = 0;
            while (readouts.Length > 1)
            {
                readouts = GetLinesByFrequency(readouts, position, (hash, i) => hash[i]['0'] > hash[i]['1'] ? '0' : '1');
                position++;
            }

            var oxygenRating = readouts.FirstOrDefault();

            readouts = (string[])lines.Clone();
            position = 0;
            while (readouts.Length > 1)
            {
                readouts = GetLinesByFrequency(readouts, position, (hash, i) => hash[i]['0'] > hash[i]['1'] ? '1' : '0');
                position++;
            }

            var co2ScrubberRating = readouts.FirstOrDefault();

            return MultiplyCharArrays(oxygenRating.ToCharArray(), co2ScrubberRating.ToCharArray());
        }

        static string[] GetLinesByFrequency(string[] lines, int position, Func<Dictionary<int, Dictionary<char, int>>, int, char> predicate)
        {
            var frequencies = CalculateFrequencies(lines);
            var digit = predicate(frequencies, position);
            return lines.AsQueryable().Where(line => line.ToCharArray()[position] == digit).ToArray();
        }

        static int MultiplyCharArrays(char[] left, char[] right)
        {
            return Convert.ToInt32(string.Join("", left), 2) * Convert.ToInt32(string.Join("", right), 2);
        }



        static char GetCharByFrequency()
        {
            return '0';
        }

        static int CalculateFrequencyDigits()
        {
            var lines = File.ReadAllLines(@"input.txt");
            var frequencies = CalculateFrequencies(lines);

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

            return MultiplyCharArrays(gamma, epsilon);
        }
    }
}
