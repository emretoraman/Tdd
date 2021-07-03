using System;
using Tdd.Katas;
using Xunit;

namespace Tdd.Tests.Katas
{
    public class ImmutableStackTests
    {
        [Fact]
        public void Count_WhenEmpty_Returns0()
        {
            var stack = ImmutableStack<int>.Empty;

            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_WithValues_IncrementsCount()
        {
            var stack = ImmutableStack<int>.Empty;
            stack = stack.Push(1);
            stack = stack.Push(2);

            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Pop_WhenEmpty_ThrowsInvalidOperationException()
        {
            var stack = ImmutableStack<int>.Empty;

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_WhenNotEmpty_DecrementsCount()
        {
            var stack = ImmutableStack<int>.Empty;
            stack = stack.Push(1);
            stack = stack.Push(2);
            stack = stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Peek_WhenEmpty_ThrowsInvalidOperationException()
        {
            var stack = ImmutableStack<int>.Empty;

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Peek_WhenNotEmpty_PeeksCorrectly()
        {
            var stack = ImmutableStack<int>.Empty;
            stack = stack.Push(1);
            stack = stack.Push(2);
            stack = stack.Pop();

            Assert.Equal(1, stack.Peek());
        }
    }
}
