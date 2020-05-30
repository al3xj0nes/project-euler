﻿using System;

namespace project_euler.Solutions
{
    class Solution_12 : Solution
    {
        public override string ProblemDefinition =>
            "The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28.The first ten terms would be:\r\n" +
            "        1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...\r\n" +
            "Let us list the factors of the first seven triangle numbers:\r\n" +
            "        1: 1\r\n" +
            "        3: 1, 3\r\n" +
            "        6: 1, 2, 3, 6\r\n" +
            "       10: 1, 2, 5, 10\r\n" +
            "       15: 1, 3, 5, 15\r\n" +
            "       21: 1, 3, 7, 21\r\n" +
            "       28: 1, 2, 4, 7, 14, 28\r\n" +
            "We can see that 28 is the first triangle number to have over five divisors.\r\n" +
            "What is the value of the first triangle number to have over five hundred divisors ?\r\n ";

        public override string Answer =>
            $"Triangle {triangleCalc().index} = {triangleCalc().triangleCalc} has {triangleCalc().numberOfDivisors} divisors";

        public (int index, int triangleCalc, int numberOfDivisors) triangleCalc()
        {
            int triangleNumberMax = 1000000;

            for (int index = 1; index <= triangleNumberMax; index++)
            {
                // calculate the triangle number
                int triangleCalc = 0;
                for (int index_t = 1; index_t <= index; index_t++)
                {
                    triangleCalc += index_t;
                }

                // calculate the number of divisors
                int numberOfDivisors = 1; // start with 1 to include the triangle number itself as a divisor, this does not need to be calculated.
                for (int divisor = 1; divisor <= triangleCalc / 2; divisor++)
                {
                    if (triangleCalc % divisor == 0)
                    {
                        //addToOutput("Divisor = " + divisor);
                        numberOfDivisors++;
                    }
                }
                if (numberOfDivisors >= 500)
                {
                    return (index, triangleCalc, numberOfDivisors);
                }
            }
            throw new Exception("Problem not solved.");
        }
    }
}