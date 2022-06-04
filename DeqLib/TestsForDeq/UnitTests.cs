using System;
using Xunit;
using DeqLib;

namespace TestsForDeq
{
    public class UnitTests
    {
        [Fact]
        public void TestEnqueueFirst()
        {
            var actualDeq = new Deque<int>();
            //var expected = new List<int>(new int[] { 3, 2, 1, 0 });

            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            Assert.Collection(actualDeq,
                        exp => Assert.Equal(3, exp),
                        exp => Assert.Equal(2, exp),
                        exp => Assert.Equal(1, exp),
                        exp => Assert.Equal(0, exp)
                    );
        }

        [Fact]
        public void TestEnqueueLast()
        {

            var actualDeq = new Deque<int>();

            actualDeq.EnqueueL(100);
            actualDeq.EnqueueL(99);
            actualDeq.EnqueueL(98);
            actualDeq.EnqueueL(97);

            Assert.Collection(actualDeq,
                        exp => Assert.Equal(100, exp),
                        exp => Assert.Equal(99, exp),
                        exp => Assert.Equal(98, exp),
                        exp => Assert.Equal(97, exp)
                    );
        }

        [Fact]
        public void TestDequeueFirst()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            actualDeq.DequeueF();
            actualDeq.DequeueF();

            Assert.Collection(actualDeq,
                        exp => Assert.Equal(1, exp),
                        exp => Assert.Equal(0, exp)
                    );

        }

        [Fact]
        public void TestDequeueLast()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            actualDeq.DequeueL();
            actualDeq.DequeueL();

            Assert.Collection(actualDeq,
                        exp => Assert.Equal(3, exp),
                        exp => Assert.Equal(2, exp)
                    );

        }

        [Fact]
        public void TestPeekFirst()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            int val = actualDeq.PeekF();

            Assert.Equal(3, val);
        }

        [Fact]
        public void TestPeekFirstFromZerroDeq()
        {
            var actualDeq = new Deque<int>();

            Assert.Throws<InvalidOperationException>(() => actualDeq.PeekF());
        }

        [Fact]
        public void TestPeekLastFromZerroDeq()
        {
            var actualDeq = new Deque<int>();

            Assert.Throws<InvalidOperationException>(() => actualDeq.PeekL());
        }

        [Fact]
        public void TestPeekLast()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            int val = actualDeq.PeekL();

            Assert.Equal(0, val);
        }

        [Fact]
        public void TestToArray()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            int[] actualArr = actualDeq.ToArray();
            int[] expected = new int[] { 3, 2, 1, 0 };

            Assert.Equal(expected, actualArr);
        }

        [Fact]
        public void TestToArrayFromZerroDeq()
        {
            var actualDeq = new Deque<int>();

            Assert.Throws<InvalidOperationException>(() => actualDeq.ToArray());
        }

        [Fact]
        public void TestTrimExcessCapacity()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);
            actualDeq.EnqueueF(4);
            Assert.Equal(5, actualDeq.Count);
            Assert.Equal(8, actualDeq.Capacity);

            actualDeq.TrimExcess();

            Assert.Equal(5, actualDeq.Count);
            Assert.Equal(5, actualDeq.Capacity);
        }

        [Fact]
        public void TestDequeContainsEl_ReturnedT()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            bool res = actualDeq.Contains(2);

            Assert.True(res);
        }

        [Fact]
        public void TestDequeContainsEl_ReturnedF()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            bool res = actualDeq.Contains(7);

            Assert.False(res);
        }

        [Fact]
        public void TestClearDeq()
        {
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueF(0);
            actualDeq.EnqueueF(1);
            actualDeq.EnqueueF(2);
            actualDeq.EnqueueF(3);

            actualDeq.Clear();

            Assert.Equal(0, actualDeq.Count);

        }

        [Fact]
        public void TestDeqCopyToArr()
        {
            int[] actualArr = new int[6];
            var actualDeq = new Deque<int>();
            actualDeq.EnqueueL(1);
            actualDeq.EnqueueL(2);
            actualDeq.EnqueueL(3);

            actualDeq.CopyTo(actualArr, 2);
            int[] expected = new int[] { 0, 0, 1, 2, 3, 0 };
            Assert.Equal(expected, actualArr);
        }
    }
}
