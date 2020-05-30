using project_euler.Helper;

namespace project_euler.Solutions
{
    class Solution_10 : Solution
    {
        public override string ProblemDefinition =>
            "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.\r\n" +
            "Find the sum of all the primes below two million.\r\n";

        public override string Answer =>
            $"Sum of all primes under two million is {sumOfPrimes()}";

        private long sumOfPrimes()
        {
            Functions functions = new Functions();

            int maxPrime = 2000000;
            long sumOfPrimes = 0;

            for (int index = 1; index <= maxPrime; index++)
            {
                if (functions.math_isPrime(index))
                {
                    //addToOutput(index.ToString());
                    sumOfPrimes += index;
                }
            }

            return sumOfPrimes;
        }
    }
}
