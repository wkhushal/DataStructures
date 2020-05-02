using AutoFixture;
using AutoFixture.Xunit2;
using DataStructure.BinaryTrees;
using System;
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

    }
}
