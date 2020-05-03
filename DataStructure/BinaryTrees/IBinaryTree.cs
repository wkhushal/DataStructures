using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.BinaryTrees
{
    public interface IBinaryTree
    {
        BinaryNode Root { get; }
        bool Insert(int value);
        bool Insert(int value, ref BinaryNode node, BinaryNode parent);
        BinaryNode Find(int value);
        bool Remove(int value);
    }
}
