using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionEx;

namespace CollectionExTests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void EnqueueTest()
        {
            CollectionEx.Queue<int> actual = new CollectionEx.Queue<int>();

            actual.Enqueue(3);
            actual.Enqueue(5);
            actual.Enqueue(8);

            int[] expected = new int[] {3, 5, 8 };
            Assert.AreEqual(expected, actual.ToArray());
        }
        [Test]
        public void DequeueTest()
        {
            CollectionEx.Queue<int> actual = new CollectionEx.Queue<int>();

            actual.Enqueue(3);
            actual.Enqueue(5);
            actual.Enqueue(8);
            actual.Dequeue();
            int[] expected = new int[] { 5, 8 };
            Assert.AreEqual(expected, actual.ToArray());
        }
        [Test]
        public void PeekTest()
        {
            CollectionEx.Queue<int> actual = new CollectionEx.Queue<int>();

            actual.Enqueue(3);
            actual.Enqueue(5);
            actual.Enqueue(8);
            actual.Peek();
            int[] expected = new int[] {3, 5, 8 };
            Assert.AreEqual(expected, actual.ToArray());
        }
        [Test]
        public void DequeueNumberTest()
        {
            CollectionEx.Queue<int> numbers = new CollectionEx.Queue<int>();

            numbers.Enqueue(3);
            numbers.Enqueue(5);
            numbers.Enqueue(8);
            var actual= numbers.Dequeue();
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PeekNumberTest()
        {
            CollectionEx.Queue<int> numbers = new CollectionEx.Queue<int>();

            numbers.Enqueue(3);
            numbers.Enqueue(5);
            numbers.Enqueue(8);
            var actual = numbers.Peek();
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }
    }
}