using System;
using project_euler.Helper;

namespace project_euler.Solutions
{
    public class Solution_09 : Solution
    {
        public override string ProblemDefinition =>
            "A Pythagorean triplet is a set of three natural numbers, a < b<c, for which,\r\n" +
            "a^2 + b^2 = c2\r\n" +
            "For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.\r\n" +
            "There exists exactly one Pythagorean triplet for which a + b + c = 1000.\r\n" +
            "Find the product abc.";

        public override string Answer =>
            $"a = {pythagoreanTriplet().a}, b = {pythagoreanTriplet().b}, c = {pythagoreanTriplet().c}. a + b + c =  = {pythagoreanTriplet().a + pythagoreanTriplet().b + pythagoreanTriplet().c}\r\n" +
            $"Resulting in a product of a * b * c = {pythagoreanTriplet().a * pythagoreanTriplet().b * pythagoreanTriplet().c}";

        private (int a, int b, double c) pythagoreanTriplet()
        {
            Functions functions = new Functions();

            for (int a = 1; a <= 500; a++)
            {
                for (int b = 1; b <= 500; b++)
                {
                    double c_sqrd = Math.Pow(a, 2) + Math.Pow(b, 2);
                    double c = Math.Sqrt(c_sqrd);

                    if (functions.math_isSquare(c_sqrd) && a < b && b < c && (a + b + c == 1000))
                    {
                        return (a, b, c);
                    }
                }
            }
            throw new Exception("Pythagorean triplet not found.");
        }
    }
}