namespace project_euler.Solutions
{
    public class Solution_05 : Solution
    {
        public override string ProblemDefinition =>
            "2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\r\n" +
            "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?";

        public override string Answer =>
            $"The smallest value divisible by 1 through 20 = {valueToInspect()}";

        private int valueToInspect()
        {
            int valueToInspect = 1;
            bool smallestValueFound = false;
            while (!smallestValueFound)
            {
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
            return valueToInspect;
        }
    }
}
