using System;
using System.Collections.Generic;

namespace Tdd.Katas
{
    public class MyStack<T>
    {
        private readonly List<T> _list = new();

        public int Count => _list.Count;

        public void Push(T value)
        {
            _list.Add(value);
        }

        public void Pop()
        {
            if (Count == 0) throw new InvalidOperationException();

            _list.RemoveAt(Count - 1);
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException();

            return _list[Count - 1];
        }
    }
}
