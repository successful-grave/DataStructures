using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DoubleLL
{
    public class DNode
    {
        public int Value { get; set; }
        public DNode Previous { get; set; }
        public DNode Next { get; set; }
        public DNode(int value)
        {
            Value = value;
            Previous = null;
            Next = null;
        }
}
}
