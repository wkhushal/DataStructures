using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.BinaryTrees
{
    public class BinaryNode
    {
        public int Value { get; set; }
        public BinaryNode Left;
        public BinaryNode Right;
        public BinaryNode Parent = null;
    }
}
