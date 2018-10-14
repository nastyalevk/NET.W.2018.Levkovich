using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Solution.Search;

namespace SolutionTests
{
    [TestFixture]
    public class IntegerExtensionNUnitTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]

        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumberTest(int number)
        {
            return Solution.Search.FindNextBiggerNumber(number);
        }

        //[TestCase(8, 15, 9, 8)]
        //public void InsertNumberTest_ThrowArgumentException(int numberSource, int numberIn, int i, int j)
        //{
        //    Assert.Throws<ArgumentException>(() => IntegerExtension.InsertNumber(numberSource, numberIn, i, j));
        //}

        //[TestCase(8, 15, -3, 8)]
        //public void InsertNumberTest_ThrowArgumentOutOfRangeException(int numberSource, int numberIn, int i, int j)
        //{
        //    Assert.Throws<ArgumentOutOfRangeException>(() => IntegerExtension.InsertNumber(numberSource, numberIn, i, j));
        //}
    }
}
