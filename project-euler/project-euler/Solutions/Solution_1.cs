namespace project_euler.Solutions
{
    public class Solution_1
    {
        /* Problem Definition
         * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
         * The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000. */

        public int totalSum()
        {
            int totalSum = 0;
            for (int index = 0; index < 1000; index++)
            {
                if (index % 3 == 0 || index % 5 == 0)
                {
                    // This index value divides into 3 or 5 without a remainder, therefore is a mutliple of 3 or 5, add it to total.
                    totalSum += index;
                }
            }
            return totalSum;
        }
    }
}
