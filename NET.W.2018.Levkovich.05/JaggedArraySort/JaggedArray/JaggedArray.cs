using System;

namespace Logic
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Class with sorting methods
    /// </summary>
    public interface ICompare
    {
        int Compare(int[] left, int[] right);
    }
    public static class Array
    {
        public static void BubbleSort(this int[][] jaggedArray, ICompare howToSort)
        {
            for (int i = 0; i < jaggedArray.GetLength(0) - 1; i++)
            {
                for (int j = 1; j <= jaggedArray.GetLength(0) - 1; j++)
                {
                    if (howToSort.Compare(jaggedArray[i], jaggedArray[j]) == -1)
                        Swap(ref jaggedArray[i], ref jaggedArray[j]);
                }
            }
        }

        private static void Swap(ref int[] left, ref int[] rigth)
        {
            int[] tmp = left;
            left = rigth;
            rigth = tmp;
        }
    }


}
