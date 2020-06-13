using System;
using System.Threading;
using System.Threading.Tasks;
using project_euler.Helpers;

namespace project_euler.Solutions
{
    public class Solution_09 : Solution
    {
        public override string ProblemDefinition =>
            "A Pythagorean triplet is a set of three natural numbers, a < b<c, for which, a^2 + b^2 = c2\r\n" +
            "For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.\r\n" +
            "There exists exactly one Pythagorean triplet for which a + b + c = 1000.\r\n" +
            "Find the product abc.";

        public override async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => pythagoreanTriplet(token, progress));
            await task;
        }

        private void pythagoreanTriplet(CancellationToken token, IProgress<int> progress = null)
        {
            Functions functions = new Functions();
            int previousPercent = 0;

            for (int a = 1; a <= 500; a++)
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
                    double percent = 100 * (double)a / 500;
                    int nearestPercent = (int)Math.Floor(percent);
                    if (nearestPercent != previousPercent)
                    {
                        progress.Report(nearestPercent);
                    }
                    previousPercent = nearestPercent;
                }

                for (int b = 1; b <= 500; b++)
                {
                    double c_sqrd = Math.Pow(a, 2) + Math.Pow(b, 2);
                    double c = Math.Sqrt(c_sqrd);

                    if (functions.math_isSquare(c_sqrd) && a < b && b < c && (a + b + c == 1000))
                    {
                        // Report progress complete
                        if (progress != null)
                        {
                            progress.Report(100);
                        }
                        Answer = $"a = {a}, b = {b}, c = {c}. a + b + c =  = {a + b + c}\r\n" +
                            $"Resulting in a product of a * b * c = {a * b * c}";
                        return;
                    }
                }
            }

            // Report progress complete
            if (progress != null)
            {
                progress.Report(100);
            }
            Answer = "Pythagorean triplet not found.";
        }
    }
}