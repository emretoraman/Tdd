using System;
using Tdd.Katas;
using Xunit;

namespace Tdd.Tests.Katas
{
    public class StackTests
    {
        [Fact]
        public void Constructor_WithoutArguments_ConstructsCorrectly()
        {
            MyStack<int> stack = new();

            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_WithValues_IncrementsCount()
        {
            MyStack<int> stack = new();
            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Pop_WhenEmpty_ThrowsInvalidOperationException()
        {
            MyStack<int> stack = new();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_WhenNotEmpty_DecrementsCounts()
        {
            MyStack<int> stack = new();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Peek_WhenEmpty_ThrowsInvalidOperationException()
        {
            MyStack<int> stack = new();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Peek_WhenNotEmpty_PeeksCorrectly()
        {
            MyStack<int> stack = new();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();

            Assert.Equal(1, stack.Peek());
        }
    }
}
