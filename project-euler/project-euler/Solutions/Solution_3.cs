using System;

namespace project_euler.Solutions
{
    class Solution_3 : Solution
    {
        public override string ProblemDefinition =>
            "The prime factors of 13195 are 5, 7, 13 and 29.\r\n" +
            "What is the largest prime factor of the number 600851475143?";

        public override string Answer =>
            $"Largest prime of { valToInspect } = { largestPrime(valToInspect) }";

        private long valToInspect = 600851475143;

        private long largestPrime(long valToInspect)
        {
            Functions f = new Functions();
            long largestPrime = -1;
            for (long index = 1; index < Math.Sqrt(valToInspect); index++)
            {
                // Is this index a factor of the value to inspect?
                if (valToInspect % index == 0)
                {
                    // addToOutput(index + " is a factor");
                    // Is this index a prime number?
                    if (f.math_isPrime(index) && index > largestPrime)
                    {
                        // addToOutput("... and is also a prime factor");
                        largestPrime = index;
                    }
                }
            }
            return largestPrime;
        }
    }
}
