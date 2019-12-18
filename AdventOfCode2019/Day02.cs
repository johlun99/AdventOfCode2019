using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public static class Day02
    {
        public static int[] Solution_01(int[] input)
        {
            int value1;
            int value2;
            int outputIndex;

            input[1] = 12;
            input[2] = 2;

            for (int i = 0; i < input.Length; i += 4)
            {
                if (input[i] == 1)
                {
                    value1 = input[i + 1];
                    value2 = input[i + 2];
                    outputIndex = input[i + 3];

                    input[outputIndex] = (input[value1] + input[value2]);
                }

                else if (input[i] == 2)
                {
                    value1 = input[i + 1];
                    value2 = input[i + 2];
                    outputIndex = input[i + 3];

                    input[outputIndex] = (input[value1] * input[value2]);
                }

                else if (input[i] == 99)
                {
                    return input;
                }
            }

            throw new Exception("Couldn't find exitcode 99");
        }

        public static string Solution_02(int[] rawInput)
        {
            int target = 19690720;

            for (int noun = 0; noun < 99; noun++)
            {
                for (int verb = 0; verb < 99; verb++)
                {
                    int[] input = (int[])rawInput.Clone();

                    input[1] = noun;
                    input[2] = verb;

                    int index = 0;

                    while (input[index] != 99)
                    {
                        int opCode = input[index];
                        int value1 = input[index + 1];
                        int value2 = input[index + 2];
                        int targetIndex = input[index + 3];

                        if (opCode == 1)
                        {
                            input[targetIndex] = input[value1] + input[value2];
                        }

                        else if (opCode == 2)
                        {
                            input[targetIndex] = input[value1] * input[value2];
                        }

                        index += 4;
                    }

                    if (input[0] == target)
                        return (100 * noun + verb).ToString();
                }
            }

            return null;
        }
    }
}
