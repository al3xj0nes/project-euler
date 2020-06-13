using System;
using System.Threading;
using System.Threading.Tasks;
using project_euler.Helpers;

namespace project_euler.Solutions
{
    class Solution_03 : Solution
    {
        public override string ProblemDefinition =>
            "The prime factors of 13195 are 5, 7, 13 and 29.\r\n" +
            "What is the largest prime factor of the number 600851475143?";

        public override async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => largestPrime(token, progress));
            await task;
        }

        private void largestPrime(CancellationToken token, IProgress<int> progress = null)
        {
            Functions f = new Functions();

            long largestPrime = -1;
            long valToInspect = 600851475143;
            double upperLimit = Math.Sqrt(valToInspect);
            int previousPercent = 0;

            for (long index = 1; index < upperLimit; index++)
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
                    double percent = 100 * (double)index / upperLimit;
                    int nearestPercent = (int)Math.Floor(percent);
                    if(nearestPercent != previousPercent)
                    {
                        progress.Report(nearestPercent);
                    }
                    previousPercent = nearestPercent;
                }

                // Is this index a factor of the value to inspect?
                if (valToInspect % index == 0)
                {
                    // addToOutput(index + " is a factor");

                    // Is this index a prime number?
                    bool isPrime = f.math_isPrime(index);

                    if(isPrime && (index > largestPrime))
                    {
                        // addToOutput("... and is also a prime factor");
                        largestPrime = index;
                    }
                }
            }
            // Report progress complete
            if (progress != null)
            {
                progress.Report(100);
            }
            Answer = $"Largest prime of { valToInspect } = { largestPrime }";
        }
    }
}
