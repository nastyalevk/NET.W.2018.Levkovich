using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceToDelegate
{
    public static class Array
    {
        public static void BubbleSort(this int[][] jaggedArray, IComparer<int[]> howToSort)
        { 
            jaggedArray.DelegateSort(howToSort.Compare);
        }
        private static void DelegateSort(this int[][] jaggedArray, Comparison<int[]> howToSort)
        {
            for (int i = 0; i < jaggedArray.GetLength(0) - 1; i++)
            {
                for (int j = 1; j <= jaggedArray.GetLength(0) - 1; j++)
                {
                    if (howToSort(jaggedArray[i], jaggedArray[j]) == -1)
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
