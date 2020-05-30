namespace project_euler.Solutions
{
    class Solution_4 : Solution
    {
        public override string ProblemDefinition =>
            "A palindromic number reads the same both ways. The largest palindrome made from the product of two 2 - digit numbers is 9009 = 91 × 99.\r\n" +
            "Find the largest palindrome made from the product of two 3 - digit numbers.";

        public override string Answer =>
            $"Largest palindrome = {largestPalindrome()}";

        // The palindrome lives between 100*100=10,000 and 999*999=998001 but can only be made using two 2-digit numbers multiplied.

        private int largestPalindrome()
        {
            string strIndex = "";
            bool palindromeFound = false;
            int largestPalindrome = -1;

            for (int index_i = 100; index_i <= 999; index_i++)
            {
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
            return largestPalindrome;
        }
    }
}
