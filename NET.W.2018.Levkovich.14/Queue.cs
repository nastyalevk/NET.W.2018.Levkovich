using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEx
{
    public class Queue<T> : IEnumerable<T>
    {
        public T[] array { get; private set; }
        public int head;
        public int size;
        public Queue()
        {
            array = new T[0];
        }
        public Queue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            array = new T[capacity];
            head = 0;
            size = 0;
        }
        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException();
            T tmp = this.array[head];
            T[] tmpArray = new T[this.array.Length - 1];
            tmpArray = this.array.Skip(1).ToArray();
            this.array = new T[this.array.Length - 1];
            this.array = tmpArray;
            --size;
            return tmp;
        }
        public void Enqueue(T item)
        {
            T[] tmpArray = new T[this.array.Length + 1];
            tmpArray[this.array.Length] = item;
            Array.Copy(this.array, tmpArray, this.array.Length);
            this.array = new T[this.array.Length + 1];
            this.array = tmpArray;
            ++size;
        }
        public T Peek()
        {
            if (this.size == 0)
                throw new InvalidOperationException();
            return this.array[this.head];
        }

        public T[] ToArray()
        {
            T[] objArray = new T[this.size];
            if (this.size == 0)
                return objArray;
            if (this.head < this.array.Length - 1)
            {
                Array.Copy((Array)this.array, this.head, (Array)objArray, 0, this.size);
            }
            else
            {
                Array.Copy((Array)this.array, this.head, (Array)objArray, 0, this.array.Length - this.head);
                Array.Copy((Array)this.array, 0, (Array)objArray, this.array.Length - this.head, this.array.Length - 1);
            }
            return objArray;
        }
        public T GetElement(int i)
        {
            return this.array[(this.head + i) % this.array.Length];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }


        public struct Enumerator : IEnumerator<T>
        {
            private Queue<T> q;
            private int index;
            private T currentElement;
            public T Current
            {
                get
                {
                    if (this.index < 0)
                    {
                        if (this.index == -1)
                            throw new InvalidOperationException();
                        else
                            throw new InvalidOperationException();
                    }

                    return this.currentElement;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (this.index < 0)
                    {
                        if (this.index == -1)
                            throw new InvalidOperationException();
                        else
                            throw new InvalidOperationException();
                    }
                    return (object)this.currentElement;
                }
            }
            public Enumerator(Queue<T> q)
            {
                this.q = q;
                this.index = -1;
                this.currentElement = default(T);
            }


            public void Dispose()
            {
                this.index = -2;
                this.currentElement = default(T);
            }

            public bool MoveNext()
            {
                if (this.index == -2)
                    return false;
                ++this.index;
                if (index == q.size)
                {
                    this.index = -2;
                    this.currentElement = default(T);
                    return false;
                }
                this.currentElement = this.q.GetElement(this.index);
                return true;
            }

            public void Reset()
            {
                this.index = -1;
                this.currentElement = default(T);
            }
        }
    }
}
