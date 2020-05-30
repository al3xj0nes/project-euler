using System;

namespace project_euler.Solutions
{
    public class Solution_6 : Solution
    {
        public override string ProblemDefinition =>
            "The sum of the squares of the first ten natural numbers is,\r\n" +
            "        1^2 + 2^2 + ... + 10^2 = 385\r\n" +
            "The square of the sum of the first ten natural numbers is,\r\n" +
            "        (1 + 2 + ... + 10)^2 = 55^2 = 3025\r\n" +
            "Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.\r\n" +
            "Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";

        public override string Answer =>
            $"Difference between = {diffOfSqAndSum()}";

        private double diffOfSqAndSum()
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
