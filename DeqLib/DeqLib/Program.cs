using System;

namespace DeqLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deq = new Deque<int>();
            deq.EnqueueL(34);
            deq.EnqueueL(15);
            deq.Print();

            deq.EnqueueF(5);
            deq.EnqueueF(13);
            deq.Print();

            deq.DequeueF();
            deq.Print();

            deq.DequeueL();
            deq.Print();
        }
    }
}
