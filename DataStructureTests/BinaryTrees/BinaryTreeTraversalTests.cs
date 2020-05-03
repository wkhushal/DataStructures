using AutoFixture;
using AutoFixture.Xunit2;
using DataStructure.BinaryTrees;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DataStructureTests.BinaryTrees
{
    public class BinaryTreeTraversalTests
    {
        private readonly ITestOutputHelper output;

        public BinaryTreeTraversalTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void InOrderTraversal()
        {
            var tree = GenerateBinarySearchTree();
            var sut = new BinaryTreeTraversal();
            var result = sut.InOrderTraversal(tree).ToList();
            this.output.WriteLine(string.Join(", ", result));
            Assert.NotNull(result);
        }
        
        [Fact]
        public void PostOrderTraversal()
        {
            var tree = GenerateBinarySearchTree();
            var sut = new BinaryTreeTraversal();
            var result = sut.PostOrderTraversal(tree).ToList();
            this.output.WriteLine(string.Join(", ", result));
            Assert.NotNull(result);
        }
        
        [Fact]
        public void PreOrderTraversal()
        {
            var tree = GenerateBinarySearchTree();
            var sut = new BinaryTreeTraversal();
            var result = sut.PreOrderTraversal(tree).ToList();
            this.output.WriteLine(string.Join(", ", result));
            Assert.NotNull(result);
        }

        [Fact]
        public void BreadthFirstTraversal()
        {
            var tree = GenerateBinarySearchTree();
            var sut = new BinaryTreeTraversal();
            var result = sut.BreadthFirstTraversal(tree).ToList();
            this.output.WriteLine(string.Join(", ", result));
            Assert.NotNull(result);
        }

        private BinarySearchTree GenerateBinarySearchTree()
        {
            var result = new BinarySearchTree(5);
            for (var i = 0; i < 10; ++i)
            {
                result.Insert(i);
            }
            return result;

        }
    }
}
