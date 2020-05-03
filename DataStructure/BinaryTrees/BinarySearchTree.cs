using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.BinaryTrees
{
    public class BinarySearchTree : IBinaryTree
    {
        private BinaryNode _root;
        public BinarySearchTree()
        {
            Root = null;
        }

        public BinarySearchTree(int value)
        {
            Root = new BinaryNode
            {
                Value = value
            };
        }

        public BinaryNode Root { 
            get => _root;
            private set {
                _root = value;
            } 
        }

        public bool Insert(int value)
        {
            if (Root is null)
            {
                Root = new BinaryNode
                {
                    Value = value
                };
                return true;
            }

            if (value == Root.Value)
            {
                return false;
            }

            return value < Root.Value ?
                Insert(value, ref Root.Left, this.Root) :
                Insert(value, ref Root.Right, this.Root);
        }

        public bool Insert(int value, ref BinaryNode node, BinaryNode parent)
        {
            if (node is null)
            {
                node = new BinaryNode()
                {
                    Value = value,
                    Parent = parent,
                };
                return true;
            }
            if (value == node.Value) return false;
            return (value < node.Value) ?
                Insert(value, ref node.Left, node) :
                Insert(value, ref node.Right, node);
        }

        public bool Remove(int value)
        {
            return Remove(ref _root, value);
        }

        public BinaryNode Find(int value)
        {
            return Find(Root, value);
        }

        private BinaryNode Find(BinaryNode node, int value)
        {
            if (node is null)
            {
                return null;
            }
            if (node.Value == value)
            {
                return node;
            }
            return node.Value > value ? Find(node.Left, value) : Find(node.Right, value);
        }

        private bool Remove(ref BinaryNode node, int value)
        {
            if (node is null)
            {
                return false;
            }

            if (node.Value == value)
            {
                // only if left and right children are also null
                if (node.Left is null && node.Right is null)
                {
                    node = null;
                    return true;
                }
                else
                {
                    if (!(node.Right is null))
                    {
                        // find the right tree's min value
                        var rightTreeMinNode = FindMin(node.Right);
                        if (!(rightTreeMinNode is null))
                        {
                            node.Value = rightTreeMinNode.Value;
                            // remove the min node from right
                            Remove(ref node.Right, rightTreeMinNode.Value);
                            return true;
                        }
                    }
                    if(!(node.Left is null)) 
                    { 
                        // if we dont have right tree then we take the max from left tree
                        var leftTreeMaxNode = FindMax(node.Left);
                        if (!(leftTreeMaxNode is null))
                        {
                            node.Value = leftTreeMaxNode.Value;
                            // remove the min node from right
                            Remove(ref node.Left, leftTreeMaxNode.Value);
                            return true;
                        }
                    }
                }
            }
            return node.Value > value ? Remove(ref node.Left, value) : Remove(ref node.Right, value);
        }

        private BinaryNode FindMin(BinaryNode node)
        {
            if (node is null)
            {
                return null;
            }

            if (node.Left is null)
            {
                return node;
            }
            return FindMin(node.Left);
        }

        private BinaryNode FindMax(BinaryNode node)
        {
            if (node is null)
            {
                return null;
            }

            if (node.Right is null)
            {
                return node;
            }
            return FindMax(node.Right);
        }
    }
}
