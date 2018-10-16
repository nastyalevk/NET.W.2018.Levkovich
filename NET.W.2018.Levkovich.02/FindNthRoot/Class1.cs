using System;

namespace FindNthRoot
{
    public class Class1
    {
        /// <summary>
        /// find n-th root of number
        /// </summary>
        /// <param name="A">number whose root is sought</param>
        /// <param name="n">degree</param>
        /// <param name="eps">accuracy</param>
        /// <returns>root of number</returns>
        public static double FindNthRoot(double A, int n, double eps)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (eps <= 0 || eps >= 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (A < 0 && n % 2 == 0)
            {
                throw new ArgumentException();
            }

            if (n == 1)
            {
                return A;
            }


            double x0 = A / n;
            double x1 = ((n - 1) * x0 + A / Math.Pow(x0, (int)n - 1)) / n;

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = ((n - 1) * x0 + A / Math.Pow(x0, (int)n - 1)) / n;

            }

            return x1;
        }

    }
}
