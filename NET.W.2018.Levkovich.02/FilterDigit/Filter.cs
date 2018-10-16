using System;

namespace _6
{
    public class Filter
    {
        public static void FilterDigit(ref int[] numeralList, int number)
        {
            if (numeralList == null)
            {
                throw new ArgumentNullException(nameof(numeralList));
            }
            for (int i = 0; i < numeralList.Length; i++)
            {
                if (!(FilterDigit(numeralList[i], number)))
                {
                    DelByIndex(ref numeralList, i);
                    i--;
                }
            }
        }
        public static bool FilterDigit(int numeral, int number)
        {
            int tmp = numeral;
            int n;
            Boolean flag = false;
            for (int j = CountOfDigits(tmp); j > -1; j--)
            {
                n = tmp % 10;
                if (n == number)
                {
                    flag = true;
                    return flag;
                }
                tmp = tmp / 10;
            }
            return flag;
        }
        public static int CountOfDigits(int number)
        {
            int counter = (int)Math.Log10(number) + 1;
            return counter;
        }
        public static void DelByIndex(ref int[] input, int index)
        {
            int[] tmp = new int[input.Length - 1];
            for (int i = 0; i < index; i++)
            {
                tmp[i] = input[i];
            }
            for (int i = index; i < tmp.Length; i++)
            {
                tmp[i] = input[i + 1];
            }
            input = tmp;

        }
    }
}
