using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2019
{
    public class Day03
    {
        public static void Solution01(List<List<string>> rawInput)
        {
            List<Point> grid1 = ConvertCoordinatesToGrid(rawInput[0]);
            List<Point> grid2 = ConvertCoordinatesToGrid(rawInput[1]);

            List<Point> crossings = new List<Point>();

            foreach (Point p1 in grid1)
            {
                foreach (Point p2 in grid2)
                {
                    if (p1.Equals(p2) && !crossings.Contains(p1))
                        crossings.Add(p1);
                }
            }

            Point origin = new Point(0, 0);
            Point closestCrossing = crossings[1];
            int closestDistance = -1;
            int distance;

            foreach (var p in crossings)
            {
                Console.WriteLine($"X: {p.X}, Y: {p.Y}");

                if (closestDistance == -1)
                {
                    closestDistance = ManhattanDistance(origin, p);
                    continue;
                }

                distance = ManhattanDistance(origin, p);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }

            Console.WriteLine("Closest distance: " + closestDistance);
        }

        public static void Solution02(List<List<string>> rawInput)
        {
            List<Point> grid1 = ConvertCoordinatesToGrid(rawInput[0]);
            List<Point> grid2 = ConvertCoordinatesToGrid(rawInput[1]);

            List<Point> crossings = new List<Point>();

            foreach (Point p1 in grid1)
            {
                foreach (Point p2 in grid2)
                {
                    if (p1.Equals(p2))
                        crossings.Add(p1);
                }
            }

            List<int> steps = new List<int>();
            int wireCounter1;
            int wireCounter2;

            foreach (var crossing in crossings)
            {
                wireCounter1 = 0;
                wireCounter2 = 0;

                foreach (Point p1 in grid1)
                {
                    wireCounter1++;
                    if (crossing.Equals(p1))
                        break;
                }

                foreach (Point p2 in grid2)
                {
                    wireCounter2++;
                    if (crossing.Equals(p2))
                        break;
                }

                steps.Add(wireCounter1 + wireCounter2);
            }

            int result = steps.Min();
            Console.WriteLine(result);
        }

        /// <summary>
        /// Calculates the manhattan distance between 2 points
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>int distance</returns>
        private static int ManhattanDistance(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }

        private static List<Point> ConvertCoordinatesToGrid(List<string> coordinates)
        {
            List<Point> result = new List<Point>();
            Regex re = new Regex(@"([a-zA-Z])(\d+)");
            Match match;

            Point currentPoint = new Point(0, 0);

            foreach (string coordinate in coordinates)
            {
                match = re.Match(coordinate);

                string stringDirection = match.Groups[1].Value.ToLower();
                int steps = Int32.Parse(match.Groups[2].Value);

                for (int i = 0; i < steps; i++)
                {
                    switch (stringDirection)
                    {
                        case "r":
                            currentPoint.X += 1;
                            break;
                        case "l":
                            currentPoint.X -= 1;
                            break;
                        case "u":
                            currentPoint.Y += 1;
                            break;
                        case "d":
                            currentPoint.Y -= 1;
                            break;
                    }

                    result.Add(currentPoint);
                }
            }

            return result;
        }
    }
}
