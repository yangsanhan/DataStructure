using System;
using System.Text;

namespace DataStructure
{
    public class DoubleLinkedList<T>
    {
        public DoubleNode<T> _head;
        public int _count;

        public DoubleLinkedList()
        {
            _head = null;
            _count = 0;
        }

        public int Count => _count;

        public DoubleNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index > _count - 1)
                throw new ArgumentOutOfRangeException("inedx", "索引超出范围");

            DoubleNode<T> tempNode = _head;
            for (int i = 0; i < index; i++)
                tempNode = tempNode.Next;

            return tempNode;
        }

        public void Add(T value)
        {
            AddAfter(value);
        }

        public void AddBefore(T value)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(value);
            if (_head == null)
                _head = newNode;
            else
            {
                DoubleNode<T> lastNode = GetNodeByIndex(_count - 1);
                DoubleNode<T> preNode = lastNode.Pre;
                preNode.Next = newNode;
                newNode.Pre = preNode;
                lastNode.Pre = newNode;
                newNode.Next = lastNode;                
            }

            _count++;
        }


        public void AddAfter(T value)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(value);
            if (_head == null)
                _head = newNode;
            else
            {
                DoubleNode<T> lastNode = GetNodeByIndex(_count - 1);
                lastNode.Next = newNode;
                newNode.Pre = lastNode;
            }

            _count++;
        }

        public void InsertBefore(int index, T value)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(value);
            if (index == 0)
            {
                if (_head == null)
                    _head = newNode;
                else
                {
                    _head.Pre = newNode;
                    newNode.Next = _head;
                    _head = newNode;
                }
            }
            else
            {
                DoubleNode<T> preNode = GetNodeByIndex(index - 1);
                DoubleNode<T> nextNode = preNode.Next;
                preNode.Next = newNode;
                newNode.Pre = preNode;
                newNode.Next = nextNode;
                if(nextNode != null) nextNode.Pre = newNode;                
            }

            _count++;
        }

        public void InsertAfter(int index, T value)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(value);
            if (index == 0)
            {
                if (_head == null)
                    _head = newNode;
                else
                {
                    newNode.Pre = _head;
                    newNode.Next = _head.Next;
                    _head.Next = newNode;
                    if (_head.Next != null) _head.Next.Pre = newNode;
                }
            }
            else
            {
                DoubleNode<T> preNode = GetNodeByIndex(index);
                DoubleNode<T> nextNode = preNode.Next;
                preNode.Next = newNode;
                newNode.Pre = preNode;
                newNode.Next = nextNode;
                if (nextNode != null) nextNode.Pre = newNode;
            }

            _count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > _count - 1)
                throw new ArgumentOutOfRangeException("inedx", "索引超出范围");

            if (index == 0)
                _head = _head.Next;
            else
            {
                DoubleNode<T> delNode = GetNodeByIndex(index);
                DoubleNode<T> preNode = delNode.Pre;
                DoubleNode<T> nextNode = delNode.Next;
                preNode.Next = nextNode;
                if (nextNode != null) nextNode.Pre = preNode;

                delNode = null;
            }

            _count--;
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public override string ToString()
        {
            if (_head == null)
                return "";

            StringBuilder stringBuilder = new StringBuilder();
            DoubleNode<T> tempNode = _head;

            for (int i = 0; i < _count; i++)
            {
                stringBuilder.Append(tempNode.Value + " ");
                tempNode = tempNode.Next;
            }

            return stringBuilder.ToString();
        }
    }

    public class DoubleNode<T>
    {
        public DoubleNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public DoubleNode<T> Pre { get; set; }
        public DoubleNode<T> Next { get; set; }
    }
}
