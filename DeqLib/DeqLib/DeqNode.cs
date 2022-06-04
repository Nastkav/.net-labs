using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeqLib
{
    class DeqNode<T>
    {
        public DeqNode(T val)
        {
            Value =  val;
        }
        public T Value { get; set; }
        public DeqNode<T> Next { get; set; }
        public DeqNode<T> Prev { get; set; }

    }
}