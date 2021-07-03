using System;

namespace Tdd.Katas
{
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
