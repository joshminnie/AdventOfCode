using System.ComponentModel;

namespace AdventOfCode;

public abstract class SolutionBase
{
    /// <summary>
    /// Gets the input for the given Advent of Code problem.
    /// </summary>
    protected static string Input => @"input.txt";

    /// <summary>
    /// Gets the human-readable display name for the class. If a <see cref="DisplayNameAttribute"/> is provided, returns the name; otherwise,
    /// the raw class name.
    /// </summary>
    private string DisplayName
    {
        get
        {
            var attribute = (DisplayNameAttribute?)Attribute.GetCustomAttribute(this.GetType(), typeof(DisplayNameAttribute), true);

            return attribute == null ? GetType().Name : attribute.DisplayName;
        }
    }

    /// <summary>
    /// Reads the file contents into the appropriate data storage object.
    /// </summary>
    public abstract void ReadFile();

    /// <summary>
    /// Calculates the solution for the given Advent of Code problem.
    /// </summary>
    public abstract void CalculateSolution();

    /// <summary>
    /// Renders the solution to the <see cref="Console"/>.
    /// </summary>
    /// <param name="result"></param>
    public virtual void RenderResult(object result)
    {
        RenderResult(null, result);
    }

    protected virtual void RenderResult(string? message, object result)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(string.IsNullOrEmpty(message) ? $"{this.DisplayName}: " : $"{this.DisplayName} | {message}: ");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);

        Console.ResetColor();
    }
}