using System;
using Tdd.Katas;
using Xunit;

namespace Tdd.Tests.Katas
{
    public class LinkedListTests
    {
        [Fact]
        public void Constructor_WithoutArguments_ConstructsCorrectly()
        {
            MyLinkedList<int> list = new();

            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
            Assert.Null(list.Tail);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1, 2)]
        public void AddFirst_WithValues_AddsCorrectly(params int[] values)
        {
            MyLinkedList<int> list = new();
            foreach (var value in values)
            {
                list.AddFirst(value);
            }

            Assert.Equal(values.Length, list.Count);
            Assert.Equal(values[^1], list.Head.Value);
            Assert.Equal(values[0], list.Tail.Value);

            var node = list.Head;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                Assert.Equal(values[i], node.Value);
                node = node.Next;
            }

            Assert.Null(node);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1, 2)]
        public void AddLast_WithValues_AddsCorrectly(params int[] values)
        {
            MyLinkedList<int> list = new();
            foreach (var value in values)
            {
                list.AddLast(value);
            }

            Assert.Equal(values.Length, list.Count);
            Assert.Equal(values[0], list.Head.Value);
            Assert.Equal(values[^1], list.Tail.Value);

            var node = list.Head;
            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(values[i], node.Value);
                node = node.Next;
            }

            Assert.Null(node);
        }

        [Fact]
        public void RemoveFirst_WhenEmpty_ThrowsInvalidOperationException()
        {
            MyLinkedList<int> list = new();
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Fact]
        public void RemoveLast_WhenEmpty_ThrowsInvalidOperationException()
        {
            MyLinkedList<int> list = new();
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Fact]
        public void RemoveFirst_WhenNotEmpty_RemovesCorrectly()
        {
            MyLinkedList<int> list = new();
            list.AddFirst(1);
            list.AddFirst(2);
            list.RemoveFirst();

            Assert.Equal(1, list.Count);
            Assert.Equal(1, list.Head.Value);
            Assert.Same(list.Head, list.Tail);
            Assert.Null(list.Head.Next);

            list.RemoveFirst();

            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
            Assert.Same(list.Head, list.Tail);
        }

        [Fact]
        public void RemoveLast_WhenNotEmpty_RemovesCorrectly()
        {
            MyLinkedList<int> list = new();
            list.AddFirst(1);
            list.AddFirst(2);
            list.RemoveLast();

            Assert.Equal(1, list.Count);
            Assert.Equal(2, list.Head.Value);
            Assert.Same(list.Head, list.Tail);
            Assert.Null(list.Head.Next);

            list.RemoveLast();

            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
            Assert.Same(list.Head, list.Tail);
        }
    }
}
