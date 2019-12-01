using System;
using System.IO;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = getInput("Data/day01.txt");

            int day01Res = Day01.Solution_01(input);

            input = getInput("Data/day01.txt");
            int day02Res = Day01.Solution_02(input);

            Console.WriteLine(day01Res);
            Console.WriteLine(day02Res);
        }

        private static int[] getInput(string path)
        {
            string[] rawInput = System.IO.File.ReadAllLines(@"../../../" + path);
            return Array.ConvertAll(rawInput, int.Parse);
        }
    }
}
