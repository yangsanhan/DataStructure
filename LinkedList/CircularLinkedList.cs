using System;
using System.Text;

namespace DataStructure
{
    public class CircularLinkedList<T>
    {
        private CirNode<T> _tail;
        private int _count;

        public CircularLinkedList()
        {
            _tail = null;
            _count = 0;
        }

        public int Count => _count;

        public void Add(T value)
        {
            CirNode<T> newNode = new CirNode<T>(value);
            if (_tail == null)
            {
                _tail = newNode;
                _tail.Next = _tail;
            }
            else
            {
                newNode.Next = _tail.Next;
                _tail.Next = newNode;
                _tail = newNode;
            }

            _count++;
        }

        public CirNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException("index", "索引超出范围");

            CirNode<T> tempNode = _tail.Next;
            for (int i = 0; i < index; i++)
                tempNode = tempNode.Next;

            return tempNode;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException("index", "索引超出范围");

            if (index == 0)
            {
                CirNode<T> newNode = new CirNode<T>(data);
                newNode.Next = _tail.Next;
                _tail.Next = newNode;
                _count++;
            }
            else if (index == _count)
                Add(data);
            else
            {
                CirNode<T> newNode = new CirNode<T>(data);
                CirNode<T> preNode = GetNodeByIndex(index - 1);
                newNode.Next = preNode.Next;
                preNode.Next = newNode;
                _count++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > _count - 1)
                throw new ArgumentOutOfRangeException("index", "索引超出范围");

            CirNode<T> preNode = GetNodeByIndex(index - 1);
            CirNode<T> delNode = preNode.Next;
            preNode.Next = delNode.Next;

            if (delNode == _tail) _tail = preNode;

            _count--;
        }

        public void Clear()
        {
            _tail = null;
            _count = 0;
        }

        public override string ToString()
        {
            if (_tail == null)
                return "";

            StringBuilder stringBuilder = new StringBuilder();
            CirNode<T> tempNode = _tail.Next;

            for (int i = 0; i < _count; i++)
            {
                stringBuilder.Append(tempNode.Value + " ");
                tempNode = tempNode.Next;
            }

            return stringBuilder.ToString();
        }
    }

    public class CirNode<T>
    {
        public CirNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public CirNode<T> Next { get; set; }
    }
}
