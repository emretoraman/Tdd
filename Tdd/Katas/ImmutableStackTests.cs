using System;
using Xunit;

namespace Tdd.Katas
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

    public interface IStack<T>
    {
        IStack<T> Push(T value);

        IStack<T> Pop();

        T Peek();

        int Count { get; }
    }

    public class ImmutableStack<T> : IStack<T>
    {
        private static readonly EmptyStack _empty = new();

        public static IStack<T> Empty => _empty;

        private readonly int _count;
        private readonly IStack<T> _tail;
        private readonly T _head;

        public ImmutableStack(IStack<T> tail, T head)
        {
            _count = tail.Count + 1;
            _tail = tail;
            _head = head;
        }

        public int Count => _count;

        public T Peek() => _head;

        public IStack<T> Pop() => _tail;

        public IStack<T> Push(T value) => new ImmutableStack<T>(this, value);

        private sealed class EmptyStack : IStack<T>
        {
            public int Count => 0;

            public T Peek() => throw new InvalidOperationException();

            public IStack<T> Pop() => throw new InvalidOperationException();

            public IStack<T> Push(T value) => new ImmutableStack<T>(this, value);
        }
    }
}
