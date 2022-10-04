using System;

namespace DataStructure
{
    public class LinkedStack<T> : IStack<T>
    {
        private StackNode<T> _top;
        private int _count;

        public int Count => _count;

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public void Push(T item)
        {
            StackNode<T> newNode = new StackNode<T>(item);
            if (IsEmpty())
                _top = newNode;
            else
            {
                newNode.Next = _top;
                _top = newNode;
            }

            _count++;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("栈为空");

            return _top.Value;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("栈为空");

            T popValue = _top.Value;
            _top = _top.Next;
            _count--;

            return popValue;
        }

        public void Clear()
        {
            _top = null;
            _count = 0;
        }
    }

    public class StackNode<T>
    {
        public StackNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public StackNode<T> Next { get; set; }
    }
}
