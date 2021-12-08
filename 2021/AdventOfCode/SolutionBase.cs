using System;

namespace AdventOfCode
{
    public abstract class SolutionBase
    {
        /// <summary>
        /// Gets the input for the given Advent of Code problem.
        /// </summary>
        public virtual string Input
        {
            get
            {
                return @"input.txt";
            }
        }

        /// <summary>
        /// Gets the input as an array of strings.
        /// </summary>
        public string[] Lines
        {
            get
            {
                return System.IO.File.ReadAllLines(Input);
            }
        }

        /// <summary>
        /// Gets the human readable display name for the class. If a <see cref="DisplayNameAttribute"/> is provided, returns the name; otherwise,
        /// the raw class name.
        /// </summary>
        public string DisplayName
        {
            get
            {
                DisplayNameAttribute attribute = (DisplayNameAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(DisplayNameAttribute), true);

                if (attribute == null)
                {
                    return this.GetType().Name;
                }
                else
                {
                    return attribute.Name;
                }
            }
        }

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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{this.DisplayName} Result: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);

            Console.ResetColor();
        }
    }
}
