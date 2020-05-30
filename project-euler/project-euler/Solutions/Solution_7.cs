namespace project_euler.Solutions
{
    class Solution_7 : Solution
    {
        public override string ProblemDefinition =>
            "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.\r\n" +
            "What is the 10 001st prime number ?";

        public override string Answer =>
            $"The 10,001st prime number = {primeCalcVal()}";

        private double primeCalcVal()
        {
            Functions functions = new Functions();

            bool primeCalcComplete = false;
            double primeCalcVal = 2;
            int primeCalcIndex = 0;

            while (!primeCalcComplete)
            {
                if (functions.math_isPrime(primeCalcVal))
                {
                    //addToOutput(primeCalcVal + " is a prime");
                    primeCalcIndex++;
                }
                if (primeCalcIndex == 10001)
                {
                    primeCalcComplete = true;
                }
                else
                {
                    primeCalcVal++;
                }
            }
            return primeCalcVal;
        }
    }
}
