using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LL
{
    public class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }

        public Node()
        {
            Next = null;
        }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public Node(Node node)
        {
            Next = node.Next;
            Value = node.Value;
        }
    } 
}
