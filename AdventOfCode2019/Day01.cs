using System;
namespace AdventOfCode2019
{
    public static class Day01
    {
        public static int Solution_01(int[] input)
        {
            int totalResult = 0;

            foreach (int row in input)
            {
                double rowResult = Math.Floor((double)row / 3);
                rowResult -= 2;

                totalResult += (int)rowResult;
            }

            return totalResult;
        }

        public static int Solution_02(int[] input)
        {
            int result = 0;

            foreach (int row in input)
            {
                double rowResult = row;

                while (rowResult > 0)
                {
                    rowResult = Math.Floor((double)rowResult / 3);
                    rowResult -= 2;

                    if (rowResult > 0)
                        result += (int)rowResult;
                }
            }

            return result;
        }
    }
}
