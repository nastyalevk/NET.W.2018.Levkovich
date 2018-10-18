using System;
using System.Diagnostics;

namespace GreatestCommonDivisorSteinEuclid
{
    /// <summary>
    /// class for finding the greatest common divisor by two methods
    /// </summary>
    public class GreatestCommonDivisor
    {
        #region Euclidean algorithm Private

        private static int GreatestCommonDivisorE(int a, int b)
        {
            Stopwatch watch = Stopwatch.StartNew();
            if (b == 0)
                return Math.Abs(a);
            if (a == 0)
                return Math.Abs(b);
            return GreatestCommonDivisorE(b, a % b);

        }

        private static int GreatestCommonDivisorE(int a, int b, int c)
        {
            return GreatestCommonDivisorE(GreatestCommonDivisorE(a, b), c);
        }

        private static int GreatestCommonDivisorE(params int[] integers)
        {
            int length = integers.Length;
            int temp = GreatestCommonDivisorE(integers[0], integers[1]);
            for (int i = 1; i < length; i++)
            {
                temp = GreatestCommonDivisorE(temp, integers[i]);
            }

            return temp;
        }

        #endregion

        #region Euclidean algorithm Public

        /// <summary>
        /// Greatest Common Divisor Euclidean algorithm for 2 numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="time"> time parameter </param>
        /// <returns>Greatest Common Divisor</returns>
        public static (int,  long) GreatestCommonDivisorE( out long time, int a, int b)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = GreatestCommonDivisorE(a, b);
            watch.Stop();
            time = watch.ElapsedTicks;
            return (resultNumber, time);
        }

        /// <summary>
        /// Greatest Common Divisor Euclidean algorithm for 3 numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <param name="time"> time parameter </param>
        /// <returns>Greatest Common Divisor</returns>
        public static (int, long) GreatestCommonDivisorE( out long time, int a, int b, int c)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = GreatestCommonDivisorE(a, b, c);
            watch.Stop();
            time = watch.ElapsedTicks;
            return (resultNumber, time);
        }

        /// <summary>
        /// Greatest Common Divisor Euclidean algorithm for more than 3 numbers
        /// </summary>
        /// <param name="integers">given numbers</param>
        /// <param name="time"> time parameter </param>
        /// <returns>Greatest Common Divisor</returns>
        public static (int, long) GreatestCommonDivisorE( out long time, params int[] integers)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = GreatestCommonDivisorE(integers);
            watch.Stop();
            time = watch.ElapsedTicks;
            return (resultNumber, time);
        }

        #endregion

        #region Stein's algorithm Private

        private static bool IsEven(int a)
        {
            return (a % 2) == 0;
        }

        private static int GreatestCommonDivisorS(int a, int b)
        {
            if (a == 0)
                return Math.Abs(b);
            if (b == 0)
                return Math.Abs(a);
            if (a == 1)
                return 1;
            if (b == 1)
                return 1;
            if (IsEven(a) && IsEven(b))
                return (2 * GreatestCommonDivisorS(a / 2, b / 2));
            if (IsEven(a) && !IsEven(b))
                return GreatestCommonDivisorS(a / 2, b);
            if (!IsEven(a) && IsEven(b))
                return GreatestCommonDivisorS(a, b / 2);
            if (a > b)
                return GreatestCommonDivisorS((a - b) / 2, b);
            else
                return GreatestCommonDivisorS((b - a) / 2, a);
        }

        private static int GreatestCommonDivisorS(int a, int b, int c)
        {
            return GreatestCommonDivisorS(GreatestCommonDivisorS(a, b), c);
        }

        private static int GreatestCommonDivisorS(params int[] integers)
        {
            int length = integers.Length;
            int temp = GreatestCommonDivisorS(integers[0], integers[1]);
            for (int i = 1; i < length; i++)
            {
                temp = GreatestCommonDivisorS(temp, integers[i]);
            }

            return temp;
        }

        #endregion

        #region Stein's algorithm Public

        /// <summary>
        /// Greatest Common Divisor Stein`s algorithm for 2 numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>Greatest Common Divisor</returns>
        public static (int, long) GreatestCommonDivisorS(out long time, int a, int b)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = GreatestCommonDivisorS(a, b);
            watch.Stop();
            time = watch.ElapsedTicks;
            return (resultNumber, time);
        }

        /// <summary>
        /// Greatest Common Divisor Stein`s algorithm for 3 numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <returns>Greatest Common Divisor</returns>
        public static (int, long) GreatestCommonDivisorS(out long time, int a, int b, int c)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = GreatestCommonDivisorS(a, b, c);
            watch.Stop();
            time = watch.ElapsedTicks;
            return (resultNumber, time);
        }

        /// <summary>
        /// Greatest Common Divisor Stein`s algorithm for more than 3 numbers
        /// </summary>
        /// <param name="integers">given numbers</param>
        /// <returns>Greatest Common Divisor</returns>
        public static (int, long) GreatestCommonDivisorS(out long time, params int[] integers)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = GreatestCommonDivisorS(integers);
            watch.Stop();
            time = watch.ElapsedTicks;
            return (resultNumber, time);
        }

        #endregion
    }
}

