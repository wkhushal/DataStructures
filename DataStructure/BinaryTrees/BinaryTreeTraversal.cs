using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.BinaryTrees
{
    public class BinaryTreeTraversal : IBinaryTreeTraversal<IBinaryTree>
    {
        public IEnumerable<int> InOrderTraversal(IBinaryTree tree)
        {
            if (tree is null)
            {
                throw new ArgumentNullException(nameof(tree));
            }

            return InOrderTraversal(tree.Root).ToList();
        }

        public IEnumerable<int> PostOrderTraversal(IBinaryTree tree)
        {
            if (tree is null)
            {
                throw new ArgumentNullException(nameof(tree));
            }

            return PostOrderTraversal(tree.Root).ToList();
        }

        public IEnumerable<int> PreOrderTraversal(IBinaryTree tree)
        {
            if (tree is null)
            {
                throw new ArgumentNullException(nameof(tree));
            }

            return PreOrderTraversal(tree.Root).ToList();
        }
        public IEnumerable<int> BreadthFirstTraversal(IBinaryTree tree)
        {
            int currentLevel = 0;
            List<int> result = new List<int> { tree.Root.Value };
            List<BinaryNode> currentLevelSiblings = new List<BinaryNode> { tree.Root.Left, tree.Root.Right };
            
            if(currentLevelSiblings is null)
            {
                return result;
            }
            while(currentLevelSiblings.Any() && currentLevelSiblings.Any(node => node != null))
            {
                foreach(var node in currentLevelSiblings.Where(node => node != null))
                {
                    result.Add(node.Value);
                }
                currentLevel++;
                currentLevelSiblings = currentLevelSiblings.Where(node => node != null).SelectMany(node =>
                {
                    var list = new List<BinaryNode>();
                    if(!(node.Left is null))
                    {
                        list.Add(node.Left);
                    }
                    if (!(node.Right is null))
                    {
                        list.Add(node.Right);
                    }
                    return list;
                }).ToList();
            }

            return result;
        }

        public IEnumerable<int> DepthFirstTraversal(IBinaryTree tree)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<int> InOrderTraversal(BinaryNode node)
        {
            if(node is null)
            {
                yield break;
            }

            foreach(var item in InOrderTraversal(node.Left).ToList())
            {
                yield return item;
            }
            
            Console.WriteLine(node.Value);
            yield return node.Value;

            foreach (var item in InOrderTraversal(node.Right).ToList())
            {
                yield return item;
            }
        }

        private IEnumerable<int> PostOrderTraversal(BinaryNode node)
        {
            if (node is null)
            {
                yield break;
            }

            foreach (var item in PostOrderTraversal(node.Left).ToList())
            {
                yield return item;
            }

            foreach (var item in PostOrderTraversal(node.Right).ToList())
            {
                yield return item;
            }

            Console.WriteLine(node.Value);
            yield return node.Value;
        }

        private IEnumerable<int> PreOrderTraversal(BinaryNode node)
        {
            if (node is null)
            {
                yield break;
            }
            
            Console.WriteLine(node.Value);
            yield return node.Value;

            foreach (var item in PreOrderTraversal(node.Left).ToList())
            {
                yield return item;
            }

            foreach (var item in PreOrderTraversal(node.Right).ToList())
            {
                yield return item;
            }
        }
    }
}
