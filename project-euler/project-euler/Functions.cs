using System;

namespace project_euler
{
    public class Functions
    {
        public bool math_isPrime(double n)
        {
            /* Based on solution in https://stackoverflow.com/questions/1801391/what-is-the-best-algorithm-for-checking-if-a-number-is-prime */
            if (n == 2 || n == 3)
            {
                return true;
            }
            else if (n % 2 == 0)
            {
                return false;
            }
            else if (n % 3 == 0)
            {
                return false;
            }
            else
            {
                int i = 5;
                int w = 2;
                while (Math.Pow(i, 2) <= n)
                {
                    if (n % i == 0)
                    {
                        return false;
                    }
                    i += w;
                    w = 6 - w;
                }
                return true;
            }
        }

    }
}
