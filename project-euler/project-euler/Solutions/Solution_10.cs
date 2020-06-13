using project_euler.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace project_euler.Solutions
{
    class Solution_10 : Solution
    {
        public override string ProblemDefinition =>
            "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.\r\n" +
            "Find the sum of all the primes below two million.";

        public override async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => sumOfPrimes(token, progress));
            await task;
        }

        private void sumOfPrimes(CancellationToken token, IProgress<int> progress = null)
        {
            Functions functions = new Functions();

            int maxPrime = 2000000;
            long sumOfPrimes = 0;
            int previousPercent = 0;

            for (int index = 1; index <= maxPrime; index++)
            {
                // Stop if cancelled
                if (token.IsCancellationRequested)
                {
                    Answer = "\r\nProblem cancelled";
                    return;
                }

                // Report progress if appropriate
                if (progress != null)
                {
                    double percent = 100 * (double)index / maxPrime;
                    int nearestPercent = (int)Math.Floor(percent);
                    if (nearestPercent != previousPercent)
                    {
                        progress.Report(nearestPercent);
                    }
                    previousPercent = nearestPercent;
                }

                if (functions.math_isPrime(index))
                {
                    sumOfPrimes += index;
                }
            }

            // Report progress complete
            if (progress != null)
            {
                progress.Report(100);
            }
            Answer = $"Sum of all primes under two million is {sumOfPrimes}";
        }
    }
}
