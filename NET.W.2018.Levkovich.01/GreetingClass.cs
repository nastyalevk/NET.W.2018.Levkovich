using System;

namespace Logic
{
    /// <summary>
    /// class consist quick and merge sorts
    /// </summary>
    public class GreetingClass
    {
        /// <summary>
        /// checks array and call sorting
        /// </summary>
        /// <param name="input"></param>
        public static void QuickSort(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            QuickSort(input, input.Length);
        }
        /// <summary>
        /// quick sort of array
        /// </summary>
        /// <param name="input"></param>
        /// <param name="size"></param>
        public static void QuickSort(int[] input, int size)
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
                QuickSort(input, j + 1);
            }
            if (i < size)
            {
                QuickSort(input, size - i);
            }
        }
     
        /// <summary>
        /// checks array and call sorting
        /// </summary>
        /// <param name="input"></param>
        public static void MergeSort(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            MergeSort(input, 0, input.Length - 1);
        }
        /// <summary>
        /// recursion
        /// </summary>
        /// <param name="input"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void MergeSort(int[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(input, low, middle);
                MergeSort(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
        }
        /// <summary>
        /// merge sort of array
        /// </summary>
        /// <param name="input"></param>
        /// <param name="low"></param>
        /// <param name="middle"></param>
        /// <param name="high"></param>
        private static void Merge(int[] input, int low, int middle, int high)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }

        }

    }
}
