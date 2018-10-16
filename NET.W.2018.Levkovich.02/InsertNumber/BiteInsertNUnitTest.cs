using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static _1.BiteInsert;

namespace _1.NUnitTest
{
    using System.Collections;

    [TestFixture]
    public class BiteInsertNUnitTest
    {
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int InsertWithShift(int firstNumber, int secondNumber, int i, int j)
               => InsertNumber(firstNumber, secondNumber, i, j);

        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        public int InsertWithoutShift(int firstNumber, int secondNumber, int i, int j)
               => InsertNumber(firstNumber, secondNumber, i, j);

        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        public int InsertWithoutShiftAndWithDiffNumber(int firstNumber, int secondNumber, int i, int j)
               => InsertNumber(firstNumber, secondNumber, i, j);

        [TestCase(-16, 19, 2, 6, ExpectedResult = -4)]
        public int InsertWithNegativeNumber(int firstNumber, int secondNumber, int i, int j)
               => InsertNumber(firstNumber, secondNumber, i, j);

        [Test]
        public void InsertNumber_IndexMoreMaxLength_Exception()
            => Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumber(15, 15, 0, 80));

        [Test]
        public void InsertNumber_NegativeIndex_Exception()
            => Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumber(15, 15, -7, 33));

        [Test]
        public void InsertNumber_jLessThani_Exception()
            => Assert.Throws<ArgumentException>(() => InsertNumber(1, 1, 5, 0));
    }
}
