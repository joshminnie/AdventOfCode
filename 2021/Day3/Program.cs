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
            Console.WriteLine("Frequency digits result = {0}", CalculateFrequencyDigits());
            Console.WriteLine("Frequency entire number = {0}", CalculateFrequencyEntirety());
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

            var oxygenRating = (BinaryString)GetLinesByFrequency((string[])lines.Clone(), 0, (hash, i) => hash[i]['0'] > hash[i]['1'] ? '0' : '1').FirstOrDefault();

            var co2ScrubberRating = (BinaryString)GetLinesByFrequency((string[])lines.Clone(), 0, (hash, i) => hash[i]['0'] > hash[i]['1'] ? '1' : '0').FirstOrDefault();

            return (oxygenRating * co2ScrubberRating);
        }

        static string[] GetLinesByFrequency(string[] lines, int position, Func<Dictionary<int, Dictionary<char, int>>, int, char> predicate)
        {
            if (lines.Length <= 1)
            {
                return lines;
            }

            var frequencies = CalculateFrequencies(lines);
            var digit = predicate(frequencies, position);
            lines = lines.AsQueryable().Where(line => line.ToCharArray()[position] == digit).ToArray();

            return GetLinesByFrequency(lines, ++position, predicate);
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

            return (new BinaryString(gamma) * new BinaryString(epsilon));
        }
    }

    public readonly struct BinaryString
    {
        public string Value { get; }

        public BinaryString(string value)
        {
            Value = value;
        }

        public BinaryString(char[] value)
        {
            Value = string.Join("", value);
        }

        public int ToInt32()
        {
            return Convert.ToInt32(Value, 2);
        }

        public static implicit operator int(BinaryString value)
        {
            return value.ToInt32();
        }

        public static explicit operator BinaryString(string value)
        {
            return new BinaryString(value);
        }

        public static explicit operator BinaryString(char[] value)
        {
            return new BinaryString(value);
        }

        public static BinaryString operator *(BinaryString a, BinaryString b)
        {
            int product = a.ToInt32() * b.ToInt32();
            return new BinaryString(Convert.ToString(product, 2));
        }
    }
}
