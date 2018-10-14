using System;

namespace Solution
{/// <summary>
/// class for search next bigger number
/// </summary>
    public static class Search
    {
        
        private static void QuickSort(int[] input, int tailLength)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            int length = input.Length - tailLength;
            int[] temp = new int[length];
            for (int i = 0; i < length; i++)
            {
                temp[i] = input[tailLength + i];
            }

            QuickSorting(temp, temp.Length);
            for (int i = 0; i < length; i++)
            {
                input[tailLength + i] = temp[i];
            }
        }

        private static void QuickSorting(int[] input, int size)
        {
            int i = 0;
            int j = size - 1;
            int mid = input[size / 2];
            while (i <= j)
            {
                while (input[i] < mid)
                {
                    i++;
                }
                while (input[j] > mid)
                {
                    j--;
                }
                if (i <= j)
                {
                    int tmp = input[i];
                    input[i] = input[j];
                    input[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (j > 0)
            {
                QuickSorting(input, j + 1);
            }
            if (i < size)
            {
                QuickSorting(input, size - i);
            }
        }

        private static int[] NumberToArray(int number)
        {
            int temp = number;
            int[] array = new int[GetCountsOfDigits(number)];
            int i = 0;
            while (number > 0)
            {
                int n = number % 10;
                array[array.Length - 1 - i] = n;
                number = number / 10;
                i++;
            }
            return array;
        }

        private static int GetCountsOfDigits(int number)
        {
            int count = (number == 0) ? 1 : 0;
            while (number != 0)
            {
                count++;
                number /= 10;
            }
            return count;
        }

        private static int[] SwapNumbersInArray(int[] array, int frst, int scnd)
        {
            int temp = array[frst];
            array[frst] = array[scnd];
            array[scnd] = temp;
            return array;
        }

        private static int ArrayToNumber(int[] array)
        {
            int number = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int power = array.Length - 1 - i;
                number += array[i] * (int)Math.Pow(10, power);
            }
            return number;
        }
        /// <summary>
        /// method to find next bigger number
        /// </summary>
        /// <param name="number">start number</param>
        /// <returns> next bigger number </returns>
        public static int FindNextBiggerNumber(int number)
        {
            int[] arrayNumber = NumberToArray(number);
            int[] tmp = new int[arrayNumber.Length];
            for (int i = arrayNumber.Length - 1; i > 0; i--)
            {
                tmp = NumberToArray(number);
                tmp = SwapNumbersInArray(tmp, i, i - 1);
                if (ArrayToNumber(tmp) > number)
                {
                    QuickSort(tmp, i);
                    break;
                }
                else continue;
            }
            if (ArrayToNumber(tmp) <= number)
                return -1;
            return ArrayToNumber(tmp);
        }

    }
}
