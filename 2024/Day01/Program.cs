// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using AdventOfCode;
using Microsoft.VisualBasic.FileIO;

new Day1Part1Solution().CalculateSolution();
new Day1Part2Solution().CalculateSolution();

internal abstract class Day1Solution : SolutionBase
{
    protected List<int> Column1 { get; } = [];
    protected List<int> Column2 { get; } = [];

    public override void ReadFile()
    {
        this.Column1.Clear();
        this.Column2.Clear();

        using var parser = new TextFieldParser(Input);
        parser.SetDelimiters("  ");
        while (!parser.EndOfData)
        {
            var inputs = parser.ReadFields();
            if (inputs == null) break;
            this.Column1.Add(int.Parse(inputs[0]));
            this.Column2.Add(int.Parse(inputs[1]));
        }
        
        this.Column1.Sort();
        this.Column2.Sort();
    }
}

[DisplayName("Day 1/Part 1 Solution")]
internal class Day1Part1Solution : Day1Solution
{
    public override void CalculateSolution()
    {
        this.ReadFile();

        var results = new List<int>(); 
        for (var i = 0; i < this.Column1.Count; i++)
        {
            results.Add(int.Abs(this.Column1[i] - this.Column2[i]));
        }
        var sum = results.Sum();
        
        RenderResult(null, sum);
    }
}

[DisplayName("Day 1/Part 2 Solution")]
internal class Day1Part2Solution : Day1Solution
{
    public override void CalculateSolution()
    {
        this.ReadFile();

        var results = new List<int>();
        foreach (var t in this.Column1)
        {
            results.Add(t * this.Column2.Count(x => x == t));
        }
        var sum = results.Sum();

        RenderResult(null, sum);
    }
} 