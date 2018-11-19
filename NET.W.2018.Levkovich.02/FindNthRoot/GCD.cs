using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithDelegates
{
    public class GCD
    {
        #region Euclid
        Func<int, int, int> GCDE = GreatestCommonDivisorE;

        private static int GreatestCommonDivisorE(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            if (a == 0)
                return Math.Abs(b);
            return GreatestCommonDivisorE(b, a % b);

        }

        private int GreatestCommonDivisorE(int a, int b, int c) => GCDForThree(GCDE, a, b, c);
        private int GreatestCommonDivisorE(params int[] integers) => GCDForParams(GCDE, integers);

        #endregion

        #region Euclid Time

          public int GreatestCommonDivisorE(out long time, params int[] integers)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = GreatestCommonDivisorE(integers);
            watch.Stop();
            time = watch.ElapsedTicks;
            return resultNumber;
        }


        #endregion

        #region Stein

        Func<int, int, int> GCDS = GreatestCommonDivisorS;

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

        private int GreatestCommonDivisorS(int a, int b, int c) => GCDForThree(GCDS, a, b, c);

        private int GreatestCommonDivisorS(params int[] integers) => GCDForParams(GCDS, integers);


        #endregion

        #region Stein Time

           public int GreatestCommonDivisorS(out long time, params int[] integers)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = GreatestCommonDivisorS(integers);
            watch.Stop();
            time = watch.ElapsedTicks;
            return resultNumber;
        }


        #endregion

        #region Delegate

        
        private int GCDForThree(Func<int, int, int> GCD, int a, int b, int c)
        {
            if (GCD == null)
                throw new ArgumentNullException();
            int temp = GCD(a, b);
            return GCD(temp, c);
        }
        private int GCDForParams(Func<int, int, int> GCD, params int[] integers)
        {
            if (GCD == null)
                throw new ArgumentNullException();
            int length = integers.Length;
            int temp = GCD(integers[0], integers[1]);
            for (int i = 1; i < length; i++)
            {
                temp = GCD(temp, integers[i]);
            }

            return temp;
        }

        #endregion

    }
}
