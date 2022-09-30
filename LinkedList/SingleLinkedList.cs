using System;
using System.Text;

namespace DataStructure
{
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        private ListNode<T> _head;
        private int _count;

        public SingleLinkedList()
        {
            _head = null;
            _count = 0;
        }

        public int Count => _count;

        public T this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }

            set
            {
                GetNodeByIndex(index).Value = value;
            }
        }

        public ListNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException("index", "索引超出范围");

            ListNode<T> tempNode = _head;
            for (int i = 0; i < index; i++)
                tempNode = tempNode.Next;

            return tempNode;
        }

        public void Add(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);
            if (_head == null)
                _head = newNode;
            else
            {
                ListNode<T> preNode = GetNodeByIndex(_count - 1);
                preNode.Next = newNode;
            }

            _count++;
        }

        public void Insert(int index, T data)
        {
            ListNode<T> newNode = null;

            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            else if (index == 0)
            {
                newNode = new ListNode<T>(data);

                if (_head == null)
                    _head = newNode;
                else
                {
                    newNode.Next = _head;
                    _head = newNode;
                }
            }
            else
            {
                ListNode<T> preNode = GetNodeByIndex(index - 1);
                newNode = new ListNode<T>(data);
                newNode.Next = preNode.Next;
                preNode.Next = newNode;
            } 

            _count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException("index", "索引超出范围");

            if (index == 0)
                _head = _head.Next;
            else
            {
                ListNode<T> preNode = GetNodeByIndex(index - 1);
                ListNode<T> delNode = preNode.Next;
                preNode.Next = delNode.Next;
                delNode = null;
            }
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
            ListNode<T> tempNode = _head;

            for(int i = 0; i < _count - 1; i++)
            {
                stringBuilder.Append(tempNode.Value + " ");
                tempNode = tempNode.Next;
            }

            return stringBuilder.ToString();
        }
    }

    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public ListNode<T> Next { get; set; }
    }
}
