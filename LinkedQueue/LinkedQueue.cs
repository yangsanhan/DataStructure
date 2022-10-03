using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedQueue<T>
    {
        private QueueNode<T> _head;
        private QueueNode<T> _tail;
        private int _count;

        public LinkedQueue()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count => _count;

        public void EnQueue(T data)
        {
            QueueNode<T> newNode = new QueueNode<T>(data);
            if(IsEmpty())
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            _count++;
        }

        public T DeQueue()
        {
            if (IsEmpty())
                return default(T);
            else
            {
                T deQueueValue = _head.Value;
                _head = _head.Next;
                _count--;

                return deQueueValue;
            }
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }

    public class QueueNode<T>
    {
        public QueueNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public QueueNode<T> Next { get; set; }
    }
}
