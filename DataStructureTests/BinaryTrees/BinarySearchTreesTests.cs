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
            Assert.Equal(value, result.Value);
        }

        [Theory, AutoData]
        public void AddValue(int value)
        {
            var sut = new BinarySearchTree(value);

            sut.AddValue(value);

            Assert.Equal(value, sut.Value);
            Assert.Null(sut.Left);
            Assert.Null(sut.Right);
        }

        [Fact]
        public void AddLeftValue()
        {
            var rootValue = 5;
            var newValue = 3;
            var sut = new BinarySearchTree(rootValue);

            sut.AddValue(newValue);

            Assert.NotNull(sut.Left);
            Assert.Equal(newValue, sut.Left.Value);
            Assert.Null(sut.Right);
        }

        [Fact]
        public void AddRightValue()
        {
            var rootValue = 2;
            var newValue = 3;
            var sut = new BinarySearchTree(rootValue);

            sut.AddValue(newValue);

            Assert.NotNull(sut.Right);
            Assert.Equal(newValue, sut.Right.Value);
            Assert.Null(sut.Left);
        }

        [Theory, AutoData]
        public void Search(int value)
        {
            var sut = new BinarySearchTree(value);

            var result = sut.Search(value);

            Assert.NotNull(result);
            Assert.Same(sut, result);
        }

        [Fact]
        public void SearchLeftNull()
        {
            var rootValue = 5;
            var searchValue = 4;
            var sut = new BinarySearchTree(rootValue);

            var result = sut.Search(searchValue);

            Assert.Null(result);
        }

        [Fact]
        public void SearchRightNull()
        {
            var rootValue = 5;
            var searchValue = 6;
            var sut = new BinarySearchTree(rootValue);

            var result = sut.Search(searchValue);

            Assert.Null(result);
        }

    }
}
