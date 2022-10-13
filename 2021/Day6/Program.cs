using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            new Day6Part1Solution().CalculateSolution();
            new Day6Part2Solution().CalculateSolution();
        }
    }

    public abstract class Day6Solution : SolutionBase
    {
        public List<int> Source { get; set; }

        public Day6Solution()
        {
            Source = new List<int>(Array.ConvertAll(Lines[0].Split(","), int.Parse));
        }
    }

    [DisplayName("Day 6/Part 1 Solution")]
    public class Day6Part1Solution : Day6Solution
    {
        public override void CalculateSolution()
        {
            var lifecycle = new Lifecycle(Source, 80);
            lifecycle.Run();
            RenderResult("Fishes after 80 days", lifecycle.Total);
        }
    }

    [DisplayName("Day 6/Part 2 Solution")]
    public class Day6Part2Solution : Day6Solution
    {
        public override void CalculateSolution()
        {
            //var groups = new Dictionary<int, long>
            //{
            //    { 0, 0 },
            //    { 1, 0 },
            //    { 2, 0 },
            //    { 3, 0 },
            //    { 4, 0 },
            //    { 5, 0 },
            //    { 6, 0 },
            //    { 7, 0 },
            //    { 8, 0 }
            //};

            var groups = Source.GroupBy(x => x).ToDictionary(x => x.Count());

            RenderResult("Fishes after 256 days", null);
        }

        private int RunChunk(List<int> chunk)
        {
            return Task.Factory.StartNew<int>(() =>
            {
                var lifecycle = new Lifecycle(chunk, 256);
                lifecycle.Run();
                return lifecycle.Source.Count;
            }).Result;
        }

        private List<List<int>> ChunkList(int chunks, List<int> source)
        {
            return source.Select((v, i) => new { Index = i, Value = v })
                .GroupBy(g => g.Index / chunks)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }


    public class Lifecycle
    {
        public List<int> Source {
            get;
            private set;
        }

        public int Days
        {
            get;
            private set;
        }

        public long Total => Source.LongCount();

        public Lifecycle(List<int> source, int days)
        {
            Source = source;
            Days = days;
        }

        public void Run()
        {
            for (int i = 0; i < Days; i++)
            {
                // Add these fish for tomorrow's iteration
                var newFish = Enumerable.Repeat(8, Source.Count(f => f == 0)).ToList();

                Source = Source.AsParallel().Select(f => f == 0 ? 6 : f - 1).ToList();
                Source.AddRange(newFish);
            }
        }
    }
}
