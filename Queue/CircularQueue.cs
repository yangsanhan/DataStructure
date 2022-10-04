using System;

namespace DataStructure
{
    public class CircularQueue<T> : IQueue<T>
    {
        private T[] _data;
        private int _front;
        private int _rear;

        public CircularQueue(int capacity = 4)
        {
            _data = new T[capacity + 1];
            _front = _rear = 0;
        }

        public int Count => (_rear - _front + _data.Length) % _data.Length;

        public void EnQueue(T item)
        {
            if (IsFull())
                throw new Exception("队列已满");

            _data[_rear] = item;
            _rear = (_rear + 1) % _data.Length;
        }

        public T DeQueue()
        {
            if (IsEmpty())
                throw new Exception("队列为空");

            T deQueueValue = _data[_front];
            _front = (_front + 1) % _data.Length;

            return deQueueValue;
        }

        public bool IsEmpty()
        {
            return _front == _rear;
        }

        public void Clear()
        {
            _data = null;
            _front = _rear = 0;
        }

        private bool IsFull()
        {
            return (_rear + 1) % _data.Length == _front;
        }
    }
}
