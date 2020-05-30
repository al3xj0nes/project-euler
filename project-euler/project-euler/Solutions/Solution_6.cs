using System;

namespace project_euler.Solutions
{
    public class Solution_6
    {
        /* Problem Definition
         * The sum of the squares of the first ten natural numbers is,
         * 1^2 + 2^2 + ... + 10^2 = 385
         * The square of the sum of the first ten natural numbers is,
         * (1 + 2 + ... + 10)^2 = 55^2 = 3025
         * Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
         * Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum. */

        public double diffOfSqAndSum()
        {
            double sumOfSquares = 0;
            double squareOfSums_preCalc = 0;

            for (double index = 1; index <= 100; index++)
            {
                sumOfSquares += Math.Pow(index, 2);
                squareOfSums_preCalc += index;
            }

            double squareOfSums = Math.Pow(squareOfSums_preCalc, 2);

            return Math.Abs(sumOfSquares - squareOfSums);
        }
    }
}
