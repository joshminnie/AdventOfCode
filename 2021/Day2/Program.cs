using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"input.txt");
            var directions = lines.Select(p => p.Split(" ")).ToArray();

            Console.WriteLine("{0} is the final position.", CalculatePosition(directions));

            Console.WriteLine("{0} is the angled position.", CalculateAngledPosition(directions));
        }

        static int CalculatePosition(string[][] directions)
        {
            int depth = 0, distance = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                switch(directions[i][0])
                {
                    case "forward":
                        distance += int.Parse(directions[i][1]);
                        break;
                    case "up":
                        depth -= int.Parse(directions[i][1]);
                        break;
                    case "down":
                        depth += int.Parse(directions[i][1]);
                        break;
                }
            }

            return depth * distance;
        }

        static int CalculateAngledPosition(string[][] directions)
        {
            int depth = 0, angle = 0, distance = 0, movement;
            for (int i = 0; i < directions.Length; i++)
            {
                movement = int.Parse(directions[i][1]);
                switch (directions[i][0])
                {
                    case "forward":
                        distance += movement;
                        depth += angle * movement;
                        break;
                    case "up":
                        angle -= movement;
                        break;
                    case "down":
                        angle += movement;
                        break;
                }
            }

            return depth * distance;
        }
    }
}
