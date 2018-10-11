using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Logic.GreetingClass;

namespace Logic.Test
{
    [TestClass]
    public class GreetingClassTests
    {
        [TestMethod]
        public void MergeSort_SortedArray_SortedArray()
        {
            // Arrange
            int [] array = new int[] { 2, 5, 6, 10, 12 };
            int [] expected = new int[] { 2, 5, 6, 10, 12 };

            // Act
            MergeSort(array);
            int[] actual = array;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort_NonSortedArray_SortedArray()
        {
            // Arrange
            int[] array = new int[] { 5, 2, 12, 6, 10 };
            int[] expected = new int[] { 2, 5, 6, 10, 12 };

            // Act
            MergeSort(array);
            int[] actual = array;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_InputWithNull_ThrowArgumentNullException()
                => MergeSort(null);

        [TestMethod]
        public void MergeSort_BigNonSortedArray_SortedArray()
        {
            // Arrange
            int[] array = new int[10000];
            Random randArray = new Random();
            for (int i = 0; i < array.Length; i++)
            { array[i] = randArray.Next(-1, +9); }
            int[] expected = array;
            MergeSort(expected);
            // Act
            MergeSort(array);
            int[] actual = array;
            Array.Sort(actual);
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void QuickSort_SortedArray_SortedArray()
        {
            // Arrange
            int[] array = new int[] { 2, 5, 6, 10, 12 };
            int[] expected = new int[] { 2, 5, 6, 10, 12 };

            // Act
            QuickSort(array);
            int[] actual = array;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort_NonSortedArray_SortedArray()
        {
            // Arrange
            int[] array = new int[] { 5, 2, 12, 6, 10 };
            int[] expected = new int[] { 2, 5, 6, 10, 12 };

            // Act
            QuickSort(array);
            int[] actual = array;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_InputWithNull_ThrowArgumentNullException()
                => QuickSort(null);

        [TestMethod]
        public void QuickSort_BigNonSortedArray_SortedArray()
        {
            // Arrange
            int[] array = new int[10000];
            Random randArray = new Random();
            for (int i = 0; i < array.Length; i++)
            { array[i] = randArray.Next(-1, +9); }
            int[] expected = array;
            QuickSort(expected);
            // Act
            MergeSort(array);
            int[] actual = array;
            Array.Sort(actual);
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
