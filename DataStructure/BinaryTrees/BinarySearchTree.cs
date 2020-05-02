using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.BinaryTrees
{
    public class BinarySearchTree
    {
        public BinarySearchTree(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }
        public BinarySearchTree Left { get; private set; }
        public BinarySearchTree Right { get; private set; }

        public void AddValue(int value)
        {
            if(value == Value)
            {
                return;
            }

            if (value < Value)
            {
                AddLeftValue(value);
            }
            else
            {
                AddRightValue(value);
            }
        }

        public BinarySearchTree Search(int value)
        {
            if (value == Value)
            {
                return this;
            }
            
            if (value < Value)
            {
                return Left?.Search(value);
            }

            return Right?.Search(value);
        }

        private void AddLeftValue(int value)
        {
            if (Left is null)
            {
                Left = new BinarySearchTree(value);
            }
            else
            {
                Left.AddValue(value);
            }
        }

        private void AddRightValue(int value)
        {
            if (Right is null)
            {
                Right = new BinarySearchTree(value);
            }
            else
            {
                Right.AddValue(value);
            }
        }
    }
}
