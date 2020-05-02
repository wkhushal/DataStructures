using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.BinaryTrees
{
    public class BinarySearchTree : IBinarySearchTree
    {
        public BinarySearchTree(int value)
        {
            Root = new Node
            {
                Value = value
            };
        }

        public Node Root { get; private set; }

        public bool Insert(int value)
        {
            if(Root is null)
            {
                Root = new Node
                {
                    Value = value
                };
                return true;
            }

            if(value == Root.Value)
            {
                return false;
            }

            return value < Root.Value ?
                Insert(value, ref Root.Left) :
                Insert(value, ref Root.Right);
        }

        public bool Insert(int value, ref Node node)
        {
            if (node is null)
            {
                node = new Node()
                {
                    Value = value
                };
                return true;
            }
            if (value == node.Value) return false;
            if (value < node.Value) {
                return Insert(value, ref node.Left);
            }
            return Insert(value, ref node.Right);

        }

        public bool Remove(int value)
        {
            throw new NotImplementedException();
        }

        public Node Find(int value)
        {
            return Find(Root, value);
        }

        private Node Find(Node node, int value)
        {
            if (node is null)
            {
                return null;
            }
            if(node.Value == value)
            {
                return node;
            }
            return node.Value > value ? Find(node.Left, value) : Find(node.Right, value);
        }
    }
}
