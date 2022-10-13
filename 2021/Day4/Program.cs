using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AdventOfCode;
using Day4.Support;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            new Day4Part1Solution().CalculateSolutionAsync();
            new Day4Part2Solution().CalculateSolutionAsync();
        }
    }

    public abstract class Day4SolutionBase : SolutionBase
    {
        public List<int> Values
        {
            get;
            private set;
        }

        public List<BingoBoard> Boards
        {
            get;
            private set;
        }

        public Day4SolutionBase()
        {
            Values = Lines[0].Split(",").Select(int.Parse).ToList();
            Boards = new List<BingoBoard>();

            var linesForBoard = new List<string>();
            var boardLines = Lines.Skip(2).Select(s => s.Trim()).ToList();
            for (int i = 0; i < boardLines.Count(); i++)
            {
                if (!string.IsNullOrEmpty(boardLines[i]))
                {
                    linesForBoard.Add(boardLines[i]);
                }

                if (linesForBoard.Count() == 5)
                {
                    Boards.Add(new BingoBoard(linesForBoard.ToArray()));
                    linesForBoard = new List<string>();
                }
            }
        }
    }

    [DisplayName("Day 4/Part 1 Solution")]
    public class Day4Part1Solution : Day4SolutionBase
    {
        public override void CalculateSolutionAsync()
        {
            foreach (var value in Values)
            {
                foreach (var board in Boards)
                {
                    board.Mark(value);
                    if (board.CheckBingo())
                    {
                        RenderResult("First Winner (in loop)", board.Score(value));
                        return;
                    }
                }
            }
        }
    }

    [DisplayName("Day 4/Part 2 Solution")]
    public class Day4Part2Solution : Day4SolutionBase
    {
        public override void CalculateSolutionAsync()
        {
            var scores = new List<int>();

            foreach (var value in Values)
            {
                foreach (var board in Boards)
                {
                    if (board.CheckBingo())
                    {
                        continue;
                    }

                    board.Mark(value);
                    if (board.CheckBingo())
                    {
                        scores.Add(board.Score(value));
                    }
                }
            }

            RenderResult("Last Winner", scores.Last());
        }
    }
}
