using System;
using System.Threading;
using System.Threading.Tasks;

namespace project_euler.Solutions
{
    public class Solution_01 : Solution
    {
        public override string ProblemDefinition =>
            "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.\r\n" +
            "The sum of these multiples is 23.\r\n" +
            "Find the sum of all the multiples of 3 or 5 below 1000.";

        public override async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => totalSum(token, progress));
            await task;
        }

        private void totalSum(CancellationToken token, IProgress<int> progress = null)
        {
            int totalSum = 0;
            int upperLimit = 1000;
            int previousPercent = 0;

            for (int index = 0; index < upperLimit; index++)
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
                    if (nearestPercent != previousPercent)
                    {
                        progress.Report(nearestPercent);
                    }
                    previousPercent = nearestPercent;
                }

                // This index value divides into 3 or 5 without a remainder, therefore is a mutliple of 3 or 5, add it to total.
                if (index % 3 == 0 || index % 5 == 0)
                {
                    totalSum += index;
                }
            }

            // Report progress complete
            if (progress != null)
            {
                progress.Report(100);
            }
            Answer = $"Total Sum = { totalSum }";
        }
    }
}
