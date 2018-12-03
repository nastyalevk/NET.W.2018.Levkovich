using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Fibonacci;

namespace FibonacciTest
{
    [TestFixture]
    public class GeneratorTest
    {
        [Test]
        public void FibonacciTestTenNumbers()
        {

            Generator<int> sequence = new Generator<int>(1, 1, (x, y) => x + y);

            int[] expected = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            int[] actual = sequence.seq.ToArray();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FibonacciTestTwentyNumbers()
        {

            Generator<int> sequence = new Generator<int>(0, 1, 20, (x, y) => x + y);

            int[] expected = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181 };
            int[] actual = sequence.seq.ToArray();
            Assert.AreEqual(expected, actual);
        }
    }
}



