using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.BinaryTrees
{
    public interface IBinaryTreeTraversal<T>
        where T: class, IBinaryTree
    {
        IEnumerable<int> PreOrderTraversal(T tree);
        IEnumerable<int> InOrderTraversal(T tree);
        IEnumerable<int> PostOrderTraversal(T tree);
        IEnumerable<int> BreadthFirstTraversal(T tree);
        IEnumerable<int> DepthFirstTraversal(T tree);
    }
}
