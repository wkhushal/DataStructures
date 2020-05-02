using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.BinaryTrees
{
    public interface IBinarySearchTree
    {
        Node Root { get;}
        bool Insert(int value);
        bool Insert(int value, ref Node node);
        Node Find(int value);
        bool Remove(int value);

    }
}
