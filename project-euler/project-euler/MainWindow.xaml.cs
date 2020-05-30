using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace project_euler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker projectEulerBWorker = new BackgroundWorker();
        public struct ProgressReport
        {
            public int percentageComplete;
            public string stringToAdd;
        }


        public MainWindow()
        {
            InitializeComponent();
            projectEulerBWorker.WorkerReportsProgress = true;
            projectEulerBWorker.WorkerSupportsCancellation = true;
            projectEulerBWorker.DoWork += projectEulerBWorker_DoWork;
            projectEulerBWorker.ProgressChanged += projectEulerBWorker_ProgressChanged;
            projectEulerBWorker.RunWorkerCompleted += projectEulerBWorker_RunWorkerCompleted;

        }

        void projectEulerBWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ProgressReport newProgressReport;
            newProgressReport.percentageComplete = 100;
            newProgressReport.stringToAdd = "my new string";
            projectEulerBWorker.ReportProgress(newProgressReport.percentageComplete, newProgressReport);
        }
        void projectEulerBWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressReport report = (ProgressReport)e.UserState;
            pbProgress.Value = e.ProgressPercentage;
            addToOutput(report.stringToAdd);
        }
        void projectEulerBWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Value = 100;
            addToOutput("bgw-completed");
        }

        private void addToOutput(string msg)
        {
            txtOutputDisplay.AppendText(msg + "\r\n");
            txtOutputDisplay.ScrollToEnd();
        }
        private void btnRunSolution_Click(object sender, RoutedEventArgs e)
        {
            pbProgress.Value = 0;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // Increment selection made as combo box indexes from 0. Solutions index from 1.
            int selectionMade = comboSolutionSelection.SelectedIndex + 1;
            addToOutput("———————————————————————————————————————————————————————");
            if (comboSolutionSelection.SelectedIndex >= 0)
            {
                addToOutput("Loading solution for " + comboSolutionSelection.Text);
            }
            projectEulerBWorker.RunWorkerAsync(selectionMade);
            /*switch (selectionMade)
            {
                case 1:
                    projectEuler_Solution1();
                    break;
                case 2:
                    projectEuler_Solution2();
                    break;
                case 3:
                    projectEuler_Solution3();
                    break;
                case 4:
                    projectEuler_Solution4();
                    break;
                case 5:
                    projectEuler_Solution5();
                    break;
                case 6:
                    projectEuler_Solution6();
                    break;
                case 7:
                    projectEuler_Solution7();
                    break;
                case 8:
                    projectEuler_Solution8();
                    break;
                case 9:
                    projectEuler_Solution9();
                    break;
                case 10:
                    projectEuler_Solution10();
                    break;
                case 11:
                    projectEuler_Solution11();
                    break;
                case 12:
                    projectEuler_Solution12();
                    break;
                default:
                    addToOutput("No implementation has been written for this function yet");
                    break;
            }*/
            //watch.Stop();
            //addToOutput("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
        }

        private void projectEuler_Solution1()
        {
            /* If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
               The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000. */
            addToOutput("If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.\r\n" +
                        "The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000.\r\n");
            int totalSum = 0;
            for (int index = 0; index < 1000; index++)
            {
                if (index % 3 == 0 || index % 5 == 0)
                {
                    // This index value divides into 3 or 5 without a remainder, therefore is a mutliple of 3 or 5, add it to total.
                    totalSum += index;
                }
            }
            addToOutput("Total Sum = " + totalSum);
        }
        private void projectEuler_Solution2()
        {
            /* Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
                                                        1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
            By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms. */
            addToOutput("Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:\r\n" +
                        "                                1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\r\n" +
                        "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.\r\n");
            int val1 = 1;
            int val2 = 2;
            int fibTest = 0;
            int sumEvenFibVals = 2; // Initialize with 2 as val2 (2) need to be added on initially.
            bool fourMilReached = false;
            while (!fourMilReached)
            {
                fibTest = val1 + val2;
                if (fibTest > 4000000)
                {
                    fourMilReached = true;
                }
                else
                {
                    val1 = val2;
                    val2 = fibTest;
                    if (fibTest % 2 == 0)
                    {
                        sumEvenFibVals += fibTest;
                        //addToOutput("SubTotal Sum = " + sumEvenFibVals + " by adding on " + fibTest);
                    }
                    else
                    {
                        //addToOutput("Skipped adding on " + fibTest + " as it's not even");
                    }
                }
            }
            addToOutput("Total Sum = " + sumEvenFibVals);
        }
        private void projectEuler_Solution3()
        {
            /* The prime factors of 13195 are 5, 7, 13 and 29.
               What is the largest prime factor of the number 600851475143 ? */
            addToOutput("The prime factors of 13195 are 5, 7, 13 and 29.\r\n" +
                        "What is the largest prime factor of the number 600851475143 ?\r\n");
            long valToInspect = 600851475143;
            long largestPrime = -1;
            for (long index = 1; index < Math.Sqrt(valToInspect);  index++)
            {
                // Is this index a factor of the value to inspect?
                if (valToInspect % index == 0)
                {
                    // addToOutput(index + " is a factor");
                    // Is this index a prime number?
                    if (math_isPrime(index) && index > largestPrime)
                    {
                        // addToOutput("... and is also a prime factor");
                        largestPrime = index;
                    }
                }
            }
            addToOutput("Largest prime of " + valToInspect + " = " + largestPrime);
        }
        private void projectEuler_Solution4()
        {
            /* A palindromic number reads the same both ways. The largest palindrome made from the product of two 2 - digit numbers is 9009 = 91 × 99.
               Find the largest palindrome made from the product of two 3 - digit numbers. */
            addToOutput("A palindromic number reads the same both ways. The largest palindrome made from the product of two 2 - digit numbers is 9009 = 91 × 99.\r\n" +
                        "Find the largest palindrome made from the product of two 3 - digit numbers.\r\n");

            // The palindrome lives between 100*100=10,000 and 999*999=998001 but can only be made using two 2-digit numbers multiplied.
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
            addToOutput("Largest palindrome = " + largestPalindrome);
        }
        private void projectEuler_Solution5()
        {
            /* 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
               What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ? */
            addToOutput("2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\r\n" +
                        "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?\r\n");
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
                    addToOutput("The smallest value divisible by 1 through 10 = " + valueToInspect);
                }
            }
        }
        private void projectEuler_Solution6()
        {
            /* The sum of the squares of the first ten natural numbers is,
                        1^2 + 2^2 + ... + 10^2 = 385
               The square of the sum of the first ten natural numbers is,
                        (1 + 2 + ... + 10)^2 = 55^2 = 3025
               Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
               Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum. */
            addToOutput("The sum of the squares of the first ten natural numbers is,\r\n" +
                        "        1^2 + 2^2 + ... + 10^2 = 385\r\n" +
                        "The square of the sum of the first ten natural numbers is,\r\n" +
                        "        (1 + 2 + ... + 10)^2 = 55^2 = 3025\r\n" +
                        "Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.\r\n" +
                        "Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.\r\n");
            double sumOfSquares = 0;
            double squareOfSums_preCalc = 0;
            double squareOfSums = 0;
            for (double index = 1; index <= 100; index++)
            {
                sumOfSquares += Math.Pow(index, 2);
                squareOfSums_preCalc += index;
            }
            squareOfSums = Math.Pow(squareOfSums_preCalc, 2);
            addToOutput("Sum of Squares = " + sumOfSquares);
            addToOutput("Square of Sums = " + squareOfSums);
            addToOutput("Difference between = " + Math.Abs(sumOfSquares - squareOfSums));
        }
        private void projectEuler_Solution7()
        {
            /* By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
               What is the 10 001st prime number? */
            addToOutput("By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.\r\n" +
                        "What is the 10 001st prime number ?\r\n");
            bool primeCalcComplete = false;
            double primeCalcVal = 2;
            int primeCalcIndex = 0;
            while (!primeCalcComplete)
            {
                if (math_isPrime(primeCalcVal))
                {
                    //addToOutput(primeCalcVal + " is a prime");
                    primeCalcIndex++;
                }
                if (primeCalcIndex == 10001)
                {
                    primeCalcComplete = true;
                }
                else {
                    primeCalcVal++;
                }
            }
            addToOutput("The 10,001st prime number = " + primeCalcVal);
        }
        private void projectEuler_Solution8()
        {
            /* The four adjacent digits in the 1000 - digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
                73167176531330624919225119674426574742355349194934
                96983520312774506326239578318016984801869478851843
                85861560789112949495459501737958331952853208805511
                12540698747158523863050715693290963295227443043557
                66896648950445244523161731856403098711121722383113
                62229893423380308135336276614282806444486645238749
                30358907296290491560440772390713810515859307960866
                70172427121883998797908792274921901699720888093776
                65727333001053367881220235421809751254540594752243
                52584907711670556013604839586446706324415722155397
                53697817977846174064955149290862569321978468622482
                83972241375657056057490261407972968652414535100474
                82166370484403199890008895243450658541227588666881
                16427171479924442928230863465674813919123162824586
                17866458359124566529476545682848912883142607690042
                24219022671055626321111109370544217506941658960408
                07198403850962455444362981230987879927244284909188
                84580156166097919133875499200524063689912560717606
                05886116467109405077541002256983155200055935729725
                71636269561882670428252483600823257530420752963450
                Find the thirteen adjacent digits in the 1000 - digit number that have the greatest product. What is the value of this product ? */
            addToOutput("The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.\r\n" +
                        "		73167176531330624919225119674426574742355349194934\r\n" +
                        "		96983520312774506326239578318016984801869478851843\r\n" +
                        "		85861560789112949495459501737958331952853208805511\r\n" +
                        "		12540698747158523863050715693290963295227443043557\r\n" +
                        "		66896648950445244523161731856403098711121722383113\r\n" +
                        "		62229893423380308135336276614282806444486645238749\r\n" +
                        "		30358907296290491560440772390713810515859307960866\r\n" +
                        "		70172427121883998797908792274921901699720888093776\r\n" +
                        "		65727333001053367881220235421809751254540594752243\r\n" +
                        "		52584907711670556013604839586446706324415722155397\r\n" +
                        "		53697817977846174064955149290862569321978468622482\r\n" +
                        "		83972241375657056057490261407972968652414535100474\r\n" +
                        "		82166370484403199890008895243450658541227588666881\r\n" +
                        "		16427171479924442928230863465674813919123162824586\r\n" +
                        "		17866458359124566529476545682848912883142607690042\r\n" +
                        "		24219022671055626321111109370544217506941658960408\r\n" +
                        "		07198403850962455444362981230987879927244284909188\r\n" +
                        "		84580156166097919133875499200524063689912560717606\r\n" +
                        "		05886116467109405077541002256983155200055935729725\r\n" +
                        "		71636269561882670428252483600823257530420752963450\r\n" +
                        "Find the thirteen adjacent digits in the 1000 - digit number that have the greatest product.What is the value of this product ?\r\n");
            string inputList = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            int adjacentCount = 13;
            double largestProduct = -1;
            long testCalc = -1;
            string products = "";
            //addToOutput("String length = " + inputList.Length);
            for (int index = 0; index <= inputList.Length - adjacentCount; index++)
            {
                testCalc = 1;
                for (int sub_index = 0; sub_index < adjacentCount; sub_index++)
                {
                    // addToOutput(inputList.Substring(index, adjacentCount));
                    //addToOutput("[" + index + ":" + sub_index + "] = " + inputList[index + sub_index]);
                    testCalc *= Convert.ToInt64(inputList[index + sub_index].ToString());
                }
                if (testCalc > largestProduct)
                {
                    //addToOutput("New high found at index = " + index);
                    largestProduct = testCalc;
                    products = inputList.Substring(index, adjacentCount);
                }
            }
            addToOutput("Largest product = " + largestProduct + " from adjacent values " + products);

        }
        private void projectEuler_Solution9()
        {
            /* A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
                        a2 + b2 = c2
               For example, 32 + 42 = 9 + 16 = 25 = 52.
               There exists exactly one Pythagorean triplet for which a +b + c = 1000.
               Find the product abc. */
            addToOutput("A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,\r\n" +
                        "a^2 + b^2 = c2\r\n" +
                        "For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.\r\n" +
                        "There exists exactly one Pythagorean triplet for which a + b + c = 1000.\r\n" +
                        "Find the product abc.");
            for (int a = 1; a <= 500; a++)
            {
                for (int b = 1; b <= 500; b++)
                {
                    double c_sqrd = Math.Pow(a, 2) + Math.Pow(b, 2);
                    double c = Math.Sqrt(c_sqrd);
                    if (math_isSquare(c_sqrd) && a < b && b < c && (a + b + c == 1000))
                    {
                        addToOutput("a=" + a + ", b=" + b + ", c=" + c + ". a+b+c=" + (a + b + c));
                        addToOutput("Resulting in a product of a*b*c=" + (a * b * c));
                    }
                }
            }
        }
        private void projectEuler_Solution10()
        {
            /* The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
               Find the sum of all the primes below two million. */
            addToOutput("The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.\r\n" +
                        "Find the sum of all the primes below two million.\r\n");
            int maxPrime = 2000000;
            long sumOfPrimes = 0;
            for (int index = 1; index <= maxPrime; index++)
            {
                if (math_isPrime(index))
                {
                    //addToOutput(index.ToString());
                    sumOfPrimes += index;
                }
            }
            addToOutput("Sum of all primes under " + maxPrime + " = " + sumOfPrimes);
        }
        private void projectEuler_Solution11()
        {
            /* What is the greatest product of four adjacent numbers in the same direction(up, down, left, right, or diagonally) in the 20×20 grid ?
               (see https://projecteuler.net/problem=11) */
            addToOutput("What is the greatest product of four adjacent numbers in the same direction(up, down, left, right, or diagonally) in the 20×20 grid ?\r\n" +
                        "(see https://projecteuler.net/problem=11) \r\n");
            int[,] inputArray = new int[20, 20] { { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 },
                                                  { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 },
                                                  { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 },
                                                  { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 },
                                                  { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 },
                                                  { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 },
                                                  { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 },
                                                  { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 },
                                                  { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 },
                                                  { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 },
                                                  { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 },
                                                  { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 },
                                                  { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 },
                                                  { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 },
                                                  { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 },
                                                  { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 },
                                                  { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 },
                                                  { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 },
                                                  { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 },
                                                  { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 } };
            // index i goes down
            // index j goes accross.
            int tempCalc = -1;
            int largestProduct = -1;
            int[] largestProductNode = new int[2];
            string largestProductType = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j =0; j < 20; j++)
                {
                    // for each node: check up, down, left, right, diag NE, diag SE, diag SW, diag NW
                    // it may not always be possible to check each direction near the boundaries -- ignore these sub-cases
                    // there will be some overlap in checking e.g. [0,0] Right will return the same value as [0,3] Left.
                    //addToOutput("node[" + i + "][" + j + "]=" + inputArray[i, j]);

                    // LEFT
                    if (j >= 3) // j Must be >=3 to be far enough from left edge.
                    {
                        tempCalc = inputArray[i, j] * inputArray[i, j - 1] * inputArray[i, j - 2] * inputArray[i, j - 3];
                        if (tempCalc > largestProduct)
                        {
                            largestProductNode[0] = i;
                            largestProductNode[1] = j;
                            largestProductType = "LEFT";
                            largestProduct = tempCalc;
                        }
                    }
                    // RIGHT
                    if (j <= 16) // j Must be <= 16 to be far enough from left edge.
                    {
                        tempCalc = inputArray[i, j] * inputArray[i, j + 1] * inputArray[i, j + 2] * inputArray[i, j + 3];
                        if (tempCalc > largestProduct)
                        {
                            largestProductNode[0] = i;
                            largestProductNode[1] = j;
                            largestProductType = "RIGHT";
                            largestProduct = tempCalc;
                        }
                    }
                    // UP
                    if (i >= 3) // i Must be >=3 to be far enough from top edge.
                    {
                        tempCalc = inputArray[i, j] * inputArray[i - 1, j] * inputArray[i - 2, j] * inputArray[i - 3, j];
                        if (tempCalc > largestProduct)
                        {
                            largestProductNode[0] = i;
                            largestProductNode[1] = j;
                            largestProductType = "UP";
                            largestProduct = tempCalc;
                        }
                    }
                    // DOWN
                    if (i <= 16) // i Must be <= 16 to be far enough from bottom edge.
                    {
                        tempCalc = inputArray[i, j] * inputArray[i + 1, j] * inputArray[i + 2, j] * inputArray[i + 3, j];
                        if (tempCalc > largestProduct)
                        {
                            largestProductNode[0] = i;
                            largestProductNode[1] = j;
                            largestProductType = "DOWN";
                            largestProduct = tempCalc;
                        }
                    }
                    // NW Diag
                    if (i>=3 && j>=3) // i & j must be >=3 to be far enough from the NW corner.
                    {
                        tempCalc = inputArray[i, j] * inputArray[i - 1, j - 1] * inputArray[i - 2, j - 2] * inputArray[i - 3, j - 3];
                        if (tempCalc > largestProduct)
                        {
                            largestProductNode[0] = i;
                            largestProductNode[1] = j;
                            largestProductType = "NW Diag";
                            largestProduct = tempCalc;
                        }
                    }
                    // SW Diag
                    if (i <= 16 && j >= 3) // i & j must be <=16, >=3 respectively to be far enough from the SW corner.
                    {
                        tempCalc = inputArray[i, j] * inputArray[i + 1, j - 1] * inputArray[i + 2, j - 2] * inputArray[i + 3, j - 3];
                        if (tempCalc > largestProduct)
                        {
                            largestProductNode[0] = i;
                            largestProductNode[1] = j;
                            largestProductType = "SW Diag";
                            largestProduct = tempCalc;
                        }
                    }
                    // NE Diag
                    if (i >= 3 && j <= 16) // i & j must be >=3, <=16 respectively to be far enough from the NE corner.
                    {
                        tempCalc = inputArray[i, j] * inputArray[i - 1, j + 1] * inputArray[i - 2, j + 2] * inputArray[i - 3, j + 3];
                        if (tempCalc > largestProduct)
                        {
                            largestProductNode[0] = i;
                            largestProductNode[1] = j;
                            largestProductType = "NE Diag";
                            largestProduct = tempCalc;
                        }
                    }
                    // SE Diag
                    if (i <= 16 && j <= 16) // i & j must be <=16 to be far enough from the SE corner.
                    {
                        tempCalc = inputArray[i, j] * inputArray[i + 1, j + 1] * inputArray[i + 2, j + 2] * inputArray[i + 3, j + 3];
                        if (tempCalc > largestProduct)
                        {
                            largestProductNode[0] = i;
                            largestProductNode[1] = j;
                            largestProductType = "SE Diag";
                            largestProduct = tempCalc;
                        }
                    }
                }
            }
            addToOutput("Largest Product = " + largestProduct);
            addToOutput("Found at node: [" + largestProductNode[0] + ", " + largestProductNode[1] + "] with direction type = " + largestProductType);
        }
        private void projectEuler_Solution12()
        {
            /* The sequence of triangle numbers is generated by adding the natural numbers.
               So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28.
               The first ten terms would be: 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
               Let us list the factors of the first seven triangle numbers:
                        1: 1
                        3: 1,3 
                        6: 1,2,3,6
                       10: 1,2,5,10
                       15: 1,3,5,15
                       21: 1,3,7,21
                       28: 1,2,4,7,14,28
               We can see that 28 is the first triangle number to have over five divisors.
               What is the value of the first triangle number to have over five hundred divisors? */
            addToOutput("The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28.The first ten terms would be:\r\n" +
                        "        1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...\r\n" +
                        "Let us list the factors of the first seven triangle numbers:\r\n" +
                        "        1: 1\r\n" +
                        "        3: 1, 3\r\n" +
                        "        6: 1, 2, 3, 6\r\n" +
                        "       10: 1, 2, 5, 10\r\n" +
                        "       15: 1, 3, 5, 15\r\n" +
                        "       21: 1, 3, 7, 21\r\n" +
                        "       28: 1, 2, 4, 7, 14, 28\r\n" +
                        "We can see that 28 is the first triangle number to have over five divisors.\r\n" +
                        "What is the value of the first triangle number to have over five hundred divisors ?\r\n ");

            int triangleNumberMax = 1000000;
            for (int index = 1; index <= triangleNumberMax; index++)
            {
                // calculate the triangle number
                int triangleCalc = 0;
                for (int index_t = 1; index_t <= index; index_t++)
                {
                    triangleCalc += index_t;
                }

                // calculate the number of divisors
                int numberOfDivisors = 1; // start with 1 to include the triangle number itself as a divisor, this does not need to be calculated.
                for (int divisor = 1; divisor <= triangleCalc/2; divisor++)
                {
                    if (triangleCalc % divisor == 0)
                    {
                        //addToOutput("Divisor = " + divisor);
                        numberOfDivisors++;
                    }
                }
                if (numberOfDivisors >= 500)
                {
                    addToOutput("Triangle (" + index + ") = " + triangleCalc + " has " + numberOfDivisors + " divisors");
                }
            }
        }

        /* Library functions that should be moved to a seperate file eventually */
        private bool math_isPrime(double n)
        {
            /* Based on solution in https://stackoverflow.com/questions/1801391/what-is-the-best-algorithm-for-checking-if-a-number-is-prime */
            if (n == 2 || n == 3)
            {
                return true;
            }
            else if (n <= 1)
            {
                return false;
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
        private bool math_isSquare(double n)
        {
            if (Math.Sqrt(n) % 1 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            projectEulerBWorker.CancelAsync();
        }
    }
}