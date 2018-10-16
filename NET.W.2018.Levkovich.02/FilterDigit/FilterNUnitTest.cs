using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static _6.Filter;

namespace ClassLibrary1
{
    public class FilterNUnitTest
    {
        [TestCase({7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17},7 , ExpectedResult = {7, 7, 70, 17})]
        public int InsertWithShift(ref int[] numeralList, int number)
               => numeralList;
    }
}
