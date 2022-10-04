using System;

namespace DataStructure
{
    public class SeqStack<T> : IStack<T>
    {
        private T[] _data;
        private int _top;

        public SeqStack(int capacity = 10)
        {
            _data = new T[capacity];
            _top = -1;
        }

        public int Count => _top + 1;

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("栈为空");

            return _data[_top];
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("栈为空");

            if (Count == _data.Length / 4)
                ResizeCapacity(_data.Length / 2);

            return _data[_top--];
        }

        public void Push(T item)
        {
            if (Count == _data.Length)
                ResizeCapacity(_data.Length * 2);

            _data[++_top] = item;
        }

        public void Clear()
        {
            _data = null;
            _top = -1;
        }

        private void ResizeCapacity(int newCapacity)
        {
            T[] newData = new T[newCapacity];
            for (int i = 0; i < Count; i++)
                newData[i] = _data[i];

            _data = newData;
        }
    }
}
