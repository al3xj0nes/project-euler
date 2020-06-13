using System;
using System.Threading;
using System.Threading.Tasks;

namespace project_euler.Solutions
{
    class Solution_04 : Solution
    {
        public override string ProblemDefinition =>
            "A palindromic number reads the same both ways.\r\n" +
            "The largest palindrome made from the product of two 2 - digit numbers is 9009 = 91 × 99.\r\n" +
            "Find the largest palindrome made from the product of two 3 - digit numbers.";

        public override async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => largestPalindrome(token, progress));
            await task;
        }

        // The palindrome lives between 100*100=10,000 and 999*999=998001 but can only be made using two 2-digit numbers multiplied.
        private void largestPalindrome(CancellationToken token, IProgress<int> progress = null)
        {
            string strIndex = "";
            bool palindromeFound = false;
            int largestPalindrome = -1;
            int previousPercent = 0;

            for (int index_i = 100; index_i <= 999; index_i++)
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
                    double percent = 100 * (double)index_i / (999 - 100);
                    int nearestPercent = (int)Math.Floor(percent);
                    if (nearestPercent != previousPercent)
                    {
                        progress.Report(nearestPercent);
                    }
                    previousPercent = nearestPercent;
                }

                for (int index_j = 100; index_j <= 999; index_j++)
                {
                    int result = index_i * index_j;
                    palindromeFound = true;
                    strIndex = result.ToString();

                    for (int index_chk = 0; index_chk <= (strIndex.Length / 2); index_chk++)
                    {
                        if (strIndex[index_chk] != strIndex[strIndex.Length - 1 - index_chk])
                        {
                            palindromeFound = false;
                        }
                    }
                    if (palindromeFound)
                    {
                        // addToOutput(result + " is a palindrome (" + index_i + "*" + index_j + ")");
                        if (result > largestPalindrome)
                        {
                            largestPalindrome = result;
                        }
                    }
                }
            }

            if (progress != null)
            {
                progress.Report(100);
            }
            Answer = $"Largest palindrome = {largestPalindrome}";
        }
    }
}