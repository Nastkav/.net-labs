using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeqLib
{
    public class Deque<T> : IEnumerable<T>, ICollection
    {
        int number;


        DeqNode<T> Head { get; set; }
        DeqNode<T> Tail { get; set; }
        public int Count { get { return number; } }
        public int Capacity { get; set; }

        public delegate void ClearHandler();

        public event ClearHandler Cleared;

        public bool Full()
        {
            if (Count == Capacity)
                return true;
            else
                return false;
        }
        public void ForCapacity()
        {
            if (Full())
            {
                Capacity = (Capacity == 0) ? 1 : Capacity * 2;
            }
        }

        public void EnqueueL(T data)
        {
            DeqNode<T> node = new DeqNode<T>(data);

            if (Head == null)
            {
                Head = node;
                Capacity++;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }
            Tail = node;
            ForCapacity();
            number++;

        }

        public void EnqueueF(T data)
        {
            DeqNode<T> node = new DeqNode<T>(data);
            DeqNode<T> tmp = new DeqNode<T>(data);

            if (Head == null)
            {
                Head = node;
                Tail = Head;
                Capacity++;
            }
            else
            {
                tmp = Head;
                Head = node;
                Head.Next = tmp;
                tmp.Prev = node;
            }
            ForCapacity();
            number++;

        }
        public T DequeueF()
        {
            if (Count == 0)
                throw new InvalidOperationException("The deque is empty");
            T res = Head.Value;
            if (Count==1)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            number--;
            return res;
        }
        public T DequeueL()
        {
            if (Count == 0)
                throw new InvalidOperationException("The deque is empty");
            T res = Tail.Value;
            if (Count == 1)
            {
                Tail = Head = null;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }
            number--;
            return res;
        }

        public T PeekF()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The deque is empty.");
            }

            return Head.Value;
        }

        public T PeekL()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The deque is empty.");
            }

            return Tail.Value;
        }

        public T[] ToArray()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The deque is empty");
            }
            T[] res = new T[Count];
            DeqNode<T> node = Head;
            using IEnumerator<T> En = GetEnumerator();

            int i = 0;
            while (En.MoveNext())
            {
                res[i] = node.Value;
                node = node.Next;
                i++;
            }
            return res;
        }

        public void TrimExcess()
        {
            if (Count/Capacity <= 0.9)
            {
                Capacity = Count;
            }
        }

        public bool Contains(T data)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The deque is empty");
            }
            else
            {
                DeqNode<T> node;
                node = Head;
                for (int i = 0; i < Count; i++)
                {
                    if (node.Value.Equals(data))
                        return true;
                    else
                        node = node.Next;
                }
                return false;
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Capacity = 0;
            number = 0;

            if (Cleared != null)
            {
                Cleared.Invoke();
            }
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (index < 0 || index >= array.Length)
                throw new ArgumentOutOfRangeException();


            if (array.Length - index < Count)
                throw new ArgumentException();

            using IEnumerator<T> En = GetEnumerator();

            while (index < array.Length && En.MoveNext())
            {
                ((IList)array)[index] = En.Current;
                index++;
            }
        }

        public bool IsSynchronized { get { return false; } }

        public object SyncRoot { get { return this; } }

        public void Print()
        {
            foreach (T element in this)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DeqEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct DeqEnumerator : IEnumerator<T>
        {
            public T Current { get; set; }

            private readonly Deque<T> list;
            private int ind;
            private DeqNode<T>? node;

            object IEnumerator.Current
            {
                get { return (object)Current; }
            }

            public DeqEnumerator(Deque<T> lst)
            {
                list = lst;
                ind = -1;
                node = lst.Head;
                Current = (list.Head != null) ? list.Head.Value : default;
            }

            public bool MoveNext()
            {
                if (node != null)
                {
                    ++ind;
                    Current = node.Value;
                    node = node.Next;
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public void Reset()
            {
                ind = 0;
                node = list.Head;
                Current = default;
            }

            public void Dispose() { }
        }


    }
}
