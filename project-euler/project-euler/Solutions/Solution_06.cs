using System;
using System.Threading;
using System.Threading.Tasks;

namespace project_euler.Solutions
{
    public class Solution_06 : Solution
    {
        public override string ProblemDefinition =>
            "The sum of the squares of the first ten natural numbers is, 1^2 + 2^2 + ... + 10^2 = 385\r\n" +
            "The square of the sum of the first ten natural numbers is, (1 + 2 + ... + 10)^2 = 55^2 = 3025\r\n" +
            "Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.\r\n" +
            "Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";

        public override async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => diffOfSqAndSum(token, progress));
            await task;
        }

        private void diffOfSqAndSum(CancellationToken token, IProgress<int> progress = null)
        {
            double sumOfSquares = 0;
            double squareOfSums_preCalc = 0;
            int previousPercent = 0;

            for (int index = 1; index <= 100; index++)
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
                    double percent = 100 * (double)index / 100;
                    int nearestPercent = (int)Math.Floor(percent);
                    if (nearestPercent != previousPercent)
                    {
                        progress.Report(nearestPercent);
                    }
                    previousPercent = nearestPercent;
                }

                sumOfSquares += Math.Pow(index, 2);
                squareOfSums_preCalc += index;
            }

            double squareOfSums = Math.Pow(squareOfSums_preCalc, 2);

            // Report progress complete
            if (progress != null)
            {
                progress.Report(100);
            }
            Answer = $"Difference between = {Math.Abs(sumOfSquares - squareOfSums)}";
        }
    }
}
