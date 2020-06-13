using System;
using System.Threading;
using System.Threading.Tasks;

namespace project_euler.Solutions
{
    public class Solution_05 : Solution
    {
        public override string ProblemDefinition =>
            "2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\r\n" +
            "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?";

        public override async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => valueToInspect(token, progress));
            await task;
        }

        private void valueToInspect(CancellationToken token, IProgress<int> progress = null)
        {
            int valueToInspect = 1;
            bool smallestValueFound = false;
            long factorial20 = 2432902008176640000;
            int previousPercent = 0;

            while (!smallestValueFound)
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
                    double percent = 100 * (double)valueToInspect / factorial20;
                    int nearestPercent = (int)Math.Floor(percent);
                    if (nearestPercent != previousPercent)
                    {
                        progress.Report(nearestPercent);
                    }
                    previousPercent = nearestPercent;
                }

                bool thisValueDivisible = true;

                for (int index = 1; index <= 20; index++)
                {
                    if (valueToInspect % index != 0)
                    {
                        thisValueDivisible = false;
                        break;
                    }
                }
                if (!thisValueDivisible)
                {
                    valueToInspect++;
                }
                else
                {
                    smallestValueFound = true;
                }
            }

            // Report progress complete
            if (progress != null)
            {
                progress.Report(100);
            }
            Answer = $"The smallest value divisible by 1 through 20 = {valueToInspect}";
        }
    }
}
