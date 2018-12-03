using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateToInterface
{
    public static class Array
    {  
        /// <summary>
        /// Method that creates comparator on delegate
        /// </summary>
        /// <param name="jaggedArray">Given array</param>
        /// <param name="howToSort">delegare</param>
        /// 
        public static void BubbleSort(this int[][] jaggedArray, Comparison<int[]> howToSort)
        {
            jaggedArray.InterfaceSort(Comparer<int[]>.Create(howToSort));
        }

        private static void InterfaceSort(this int[][] jaggedArray, IComparer<int[]> howToSort)
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
