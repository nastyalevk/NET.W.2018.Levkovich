using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceToDelegate;
using NUnit.Framework;

namespace InterfaceToDelegateTest
{
    [TestFixture]
    public class JaggedArrayTest
    {
        [Test]
        public void BubbleToMore_Sum()
        {
            int[][] actual =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 } };
            ;

            int[][] expected =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 37, 41, 6, 94 }, new int[] { 112, 22, 77, 55 } };

            InterfaceToDelegate.Array.BubbleSort(actual, new ToMoreBySumm());

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleToMore_MaxEl()
        {
            int[][] actual =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 } };
            ;

            int[][] expected =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 37, 41, 6, 94 }, new int[] { 112, 22, 77, 55 } };

            InterfaceToDelegate.Array.BubbleSort(actual, new ToMoreByMaxEl());

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleToMore_MinEl()
        {
            int[][] actual =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 } };
            ;

            int[][] expected =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 37, 41, 6, 94 }, new int[] { 112, 22, 77, 55 } };

            InterfaceToDelegate.Array.BubbleSort(actual, new ToMoreByMinEl());

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleToLess_Sum()
        {
            int[][] actual =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 } };
            ;

            int[][] expected =
                { new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 }, new int[] { 1, 9, 50, 7, 9 } };

            InterfaceToDelegate.Array.BubbleSort(actual, new ToLessBySumm());

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleToLess_MaxEl()
        {
            int[][] actual =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 } };
            ;

            int[][] expected =
                { new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 }, new int[] { 1, 9, 50, 7, 9 } };

            InterfaceToDelegate.Array.BubbleSort(actual, new ToLessByMaxEl());

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleToLess_MinEl()
        {
            int[][] actual =
                { new int[] { 1, 9, 50, 7, 9 }, new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 } };
            ;

            int[][] expected =
                { new int[] { 112, 22, 77, 55 }, new int[] { 37, 41, 6, 94 }, new int[] { 1, 9, 50, 7, 9 } };

            InterfaceToDelegate.Array.BubbleSort(actual, new ToLessByMinEl());

            CollectionAssert.AreEqual(actual, expected);
        }
    }

    public class ToMoreBySumm : IComparer<int[]>
    {
        public int Compare(int[] left, int[] right)
        {
            if (SortingCriteria.Sum(left) > SortingCriteria.Sum(right))
                return -1;
            if (SortingCriteria.Sum(left) < SortingCriteria.Sum(right))
                return 1;
            return 0;
        }
    }
    public class ToMoreByMaxEl : IComparer<int[]>
    {
        public int Compare(int[] left, int[] right)
        {
            if (SortingCriteria.MaxEl(left) > SortingCriteria.MaxEl(right))
                return -1;
            if (SortingCriteria.MaxEl(left) < SortingCriteria.MaxEl(right))
                return 1;
            return 0;
        }
    }
    public class ToMoreByMinEl : IComparer<int[]>
    {
        public int Compare(int[] left, int[] right)
        {
            if (SortingCriteria.MinEl(left) > SortingCriteria.MinEl(right))
                return -1;
            if (SortingCriteria.MinEl(left) < SortingCriteria.MinEl(right))
                return 1;
            return 0;
        }
    }
    public class ToLessBySumm : IComparer<int[]>
    {
        public int Compare(int[] left, int[] right)
        {
            if (SortingCriteria.Sum(left) < SortingCriteria.Sum(right))
                return -1;
            if (SortingCriteria.Sum(left) > SortingCriteria.Sum(right))
                return 1;
            return 0;
        }
    }
    public class ToLessByMaxEl : IComparer<int[]>
    {
        public int Compare(int[] left, int[] right)
        {
            if (SortingCriteria.MaxEl(left) < SortingCriteria.MaxEl(right))
                return -1;
            if (SortingCriteria.MaxEl(left) > SortingCriteria.MaxEl(right))
                return 1;
            return 0;
        }
    }
    public class ToLessByMinEl : IComparer<int[]>
    {
        public int Compare(int[] left, int[] right)
        {
            if (SortingCriteria.MinEl(left) < SortingCriteria.MinEl(right))
                return -1;
            if (SortingCriteria.MinEl(left) > SortingCriteria.MinEl(right))
                return 1;
            return 0;
        }
    }

    public static class SortingCriteria
    {
        public static int Sum(int[] item)
        {

            int sum = 0;
            for (int i = 0; i < item.Length; i++)
            { sum += item[i]; }
            return sum;
        }
        public static int MaxEl(int[] item)
        {
            int max = item[0];
            for (int i = 1; i < item.Length; ++i)
            {
                if (item[i] > max)
                    max = item[i];
            }
            return max;
        }
        public static int MinEl(int[] item)
        {

            int min = item[0];
            for (int i = 1; i < item.Length; ++i)
            {
                if (item[i] < min)
                    min = item[i];
            }
            return min;
        }
    }
}
