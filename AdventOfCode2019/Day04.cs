using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public static class Day04
    {
        public static void Solution01()
        {
            int start = 183564;
            int end = 657474;

            int counter = 0;

            for (int i = start; i <= end; i++)
            {
                int[] currentNum = GetIntArray(i);

                bool doubleNum = false;
                bool decreaseNum = false;

                for (int j = 0; j < currentNum.Length - 1; j++)
                {
                    if (currentNum[j] == currentNum[j + 1])
                        doubleNum = true;

                    if (currentNum[j] > currentNum[j + 1])
                        decreaseNum = true;
                }

                if (doubleNum == true && decreaseNum == false)
                    counter++;
            }

            Console.WriteLine($"Answer: {counter}");
        }

        public static void Solution02()
        {
            int start = 183564;
            int end = 657474;

            int counter = 0;

            for (int i = start; i <= end; i++)
            {
                int[] currentNum = GetIntArray(i);

                bool doubleNum = false;
                bool decreaseNum = false;

                for (int j = 0; j < currentNum.Length - 1; j++)
                {
                    if (j == 0)
                    {
                        if (currentNum[j] == currentNum[j + 1] && currentNum[j] != currentNum[j + 2])
                            doubleNum = true;
                    }

                    else if (j + 2 < currentNum.Length)
                    {
                        if (currentNum[j] == currentNum[j + 1] &&
                            currentNum[j] != currentNum[j - 1] &&
                            currentNum[j] != currentNum[j + 2])
                            doubleNum = true;
                    }

                    else if (j + 2 == currentNum.Length)
                    {
                        if (currentNum[j] == currentNum[j + 1] &&
                            currentNum[j] != currentNum[j - 1])
                            doubleNum = true;
                    }

                    else
                    {
                        Console.WriteLine("Something went wrong!");
                        break;
                    }

                    if (currentNum[j] > currentNum[j + 1])
                        decreaseNum = true;
                }

                if (doubleNum == true && decreaseNum == false)
                    counter++;
            }

            Console.WriteLine($"Answer: {counter}");
        }

        private static int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
    }
}
