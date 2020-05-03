using AutoFixture;
using AutoFixture.Xunit2;
using DataStructure.BinaryTrees;
using System;
using System.Collections.Generic;
using Xunit;


namespace DataStructureTests.BinaryTrees
{
    public class BinarySearchTreesTests
    {
        [Fact]
        public void BinarySearchTrees()
        {
            var value = 5;
            var result = new BinarySearchTree(value);
            Assert.NotNull(result);
            Assert.Equal(value, result.Root.Value);
        }

        [Theory, AutoData]
        public void Insert(int value)
        {
            var sut = new BinarySearchTree(value);

            sut.Insert(value);

            Assert.Equal(value, sut.Root.Value);
            Assert.Null(sut.Root.Left);
            Assert.Null(sut.Root.Right);
        }

        [Fact]
        public void InsertLeft()
        {
            var rootValue = 5;
            var newValue = 3;
            var sut = new BinarySearchTree(rootValue);

            sut.Insert(newValue);

            Assert.NotNull(sut.Root.Left);
            Assert.Equal(newValue, sut.Root.Left.Value);
            Assert.Null(sut.Root.Right);
            Assert.Same(sut.Root, sut.Root.Left.Parent);
        }

        [Fact]
        public void InsertRight()
        {
            var rootValue = 2;
            var newValue = 3;
            var sut = new BinarySearchTree(rootValue);

            sut.Insert(newValue);

            Assert.NotNull(sut.Root.Right);
            Assert.Equal(newValue, sut.Root.Right.Value);
            Assert.Null(sut.Root.Left);
            Assert.Same(sut.Root, sut.Root.Right.Parent);
        }

        [Theory, AutoData]
        public void Find(int value)
        {
            var sut = new BinarySearchTree(value);

            var result = sut.Find(value);

            Assert.NotNull(result);
            Assert.Same(sut.Root, result);
        }

        [Fact]
        public void FindLeftNull()
        {
            var rootValue = 5;
            var searchValue = 4;
            var sut = new BinarySearchTree(rootValue);

            var result = sut.Find(searchValue);

            Assert.Null(result);
        }

        [Fact]
        public void FindRightNull()
        {
            var rootValue = 5;
            var searchValue = 6;
            var sut = new BinarySearchTree(rootValue);

            var result = sut.Find(searchValue);

            Assert.Null(result);
        }

        [Theory, AutoData]
        public void Remove(IFixture fixture, int value)
        {
            var sut = fixture.Create<BinarySearchTree>();
            var result = sut.Remove(value);
            Assert.False(result);
        }

        [Fact]
        public void RemoveRootWithSingleNode()
        {
            var sut = new BinarySearchTree(5);
            var result = sut.Remove(5);
            Assert.True(result);
            Assert.Null(sut.Root);
        }

        [Fact]
        public void RemoveRoot()
        {
            var sut = GenerateBinarySearchTreeInLoop();
            var result = sut.Remove(5);
            Assert.True(result);
            Assert.NotEqual(5, sut.Root.Value);
        }

        [Fact]
        public void RemoveTreeNode()
        {
            var sut = GenerateBinarySearchTree();
            for (var i = 1; i <= 10; ++i)
            {
                sut.Remove(i);
            }
        }

        private BinarySearchTree GenerateBinarySearchTreeInLoop()
        {
            var result = new BinarySearchTree(5);
            for (var i = 0; i < 10; ++i)
            {
                result.Insert(i);
            }
            return result;
        }

        private BinarySearchTree GenerateBinarySearchTree()
        {
            var intList = new List<int> { 6, 4, 5, 2, 3, 1, 8, 9, 10, 7 };
            var result = new BinarySearchTree();
            foreach (var item in intList)
            {
                result.Insert(item);
            }
            return result;
        }
    }
}
