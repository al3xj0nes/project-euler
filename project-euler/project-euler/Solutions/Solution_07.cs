using project_euler.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace project_euler.Solutions
{
    class Solution_07 : Solution
    {
        public override string ProblemDefinition =>
            "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.\r\n" +
            "What is the 10 001st prime number?";

        public override async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => primeCalcVal(token, progress));
            await task;
        }

        private void primeCalcVal(CancellationToken token, IProgress<int> progress = null)
        {
            Functions functions = new Functions();

            bool primeCalcComplete = false;
            double primeCalcVal = 2;
            int primeCalcIndex = 0;
            int previousPercent = 0;

            while (!primeCalcComplete)
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
                    double percent = 100 * (double)primeCalcIndex / 10001;
                    int nearestPercent = (int)Math.Floor(percent);
                    if (nearestPercent != previousPercent)
                    {
                        progress.Report(nearestPercent);
                    }
                    previousPercent = nearestPercent;
                }

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

            // Report progress complete
            if (progress != null)
            {
                progress.Report(100);
            }
            Answer = $"The 10,001st prime number = {primeCalcVal}";
        }
    }
}