using System;

namespace Tdd.Katas
{
    public class MyLinkedList<T>
    {
        public ListNode<T> Head { get; private set; }

        public ListNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new ListNode<T>(value));
        }

        public void AddLast(T value)
        {
            AddLast(new ListNode<T>(value));
        }

        public void RemoveFirst()
        {
            if (Count == 0) throw new InvalidOperationException();

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (Count == 0) throw new InvalidOperationException();

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                var node = Head;
                for (; node.Next != Tail; node = node.Next) ;

                node.Next = null;
                Tail = node;
            }

            Count--;
        }

        private void AddFirst(ListNode<T> node)
        {
            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }

            Count++;
        }

        private void AddLast(ListNode<T> node)
        {
            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }
    }

    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public ListNode<T> Next { get; set; }
    }
}
