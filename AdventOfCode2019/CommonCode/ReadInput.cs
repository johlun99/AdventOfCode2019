using System;
using System.Collections.Generic;

namespace AdventOfCode2019.CommonCode
{
    public static class ReadInput
    {
        /// <summary>
        /// Gets input from a file with one number on each line
        /// </summary>
        /// <param name="path">The file</param>
        /// <returns>int[]</returns>
        public static int[] getInput(string path)
        {
            string[] rawInput = System.IO.File.ReadAllLines(@"../../../Data/" + path);
            return Array.ConvertAll(rawInput, int.Parse);
        }

        /// <summary>
        /// Used on 2 lines of input converts those 2 csv to string[]
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string[,]</returns>
        public static List<List<string>> getStringCsvInput(string path)
        {
            string[] rawInput = System.IO.File.ReadAllLines(@"../../../Data/" + path);
            List<List<string>> result = new List<List<string>>();

            for (int i = 0; i < rawInput.Length; i++)
            {
                List<string> temp = new List<string>();

                foreach (string s in rawInput[i].Split(','))
                {
                    temp.Add(s);
                }

                result.Add(temp);
            }

            return result;
        }

        /// <summary>
        /// Converts a single line of csv to int[]
        /// </summary>
        /// <param name="file"></param>
        /// <returns>int[]</returns>
        public static int[] getCsvInput(string file)
        {
            string rawInput = System.IO.File.ReadAllText(@"../../../Data/" + file);
            List<int> nums = new List<int>();
            int number;

            foreach (string s in rawInput.Split(','))
            {
                number = 0;
                if (int.TryParse(s, out number))
                    nums.Add(number);

                else
                    break;
            }

            return nums.ToArray();
        }
    }
}
