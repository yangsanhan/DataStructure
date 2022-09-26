using System;
using System.Text;

namespace DataStructure
{
    class SingleLinkedList<T> where T : IComparable<T>
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
                return GetEle(index).Value;
            }

            set
            {
                GetEle(index).Value = value;
            }
        }

        public void Add(T value)
        {
            ListNode<T> newNode = new ListNode<T>(value);
            if (_head == null)
                _head = newNode;
            else
            {
                ListNode<T> preNode = GetEle(_count - 1);
                preNode.Next = newNode;
            }

            _count++;
        }

        public void Insert(int index, T value)
        {
            ListNode<T> newNode = new ListNode<T>(value);
            if (index == 0)
            {
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
                ListNode<T> preNode = GetEle(index - 1);
                newNode.Next = preNode.Next;
                preNode.Next = newNode;
            }

            _count++;
        }

        public ListNode<T> GetEle(int index)
        {
            if (index < 0 || index > _count)
                throw new IndexOutOfRangeException("索引不合法");

            ListNode<T> tempNode = _head;
            for (int i = 0; i < index; i++)
                tempNode = tempNode.Next;

            return tempNode;
        }

        public int GetIndexOf(T value)
        {
            int findIndex = -1;
            ListNode<T> tempNode = _head;           
            for (int i = 0; i < _count; i++)
            {
                if(tempNode.Value.Equals(value))
                {
                    findIndex = i;
                    break;
                }

                tempNode = tempNode.Next;
            }

            return findIndex;
        }

        public bool Remove(T value)
        {
            if (_count == 0)
                throw new Exception("列表为空，无法进行删除操作");

            int findIndex = GetIndexOf(value);
            if (findIndex == -1)
                return false;
            else
            {
                RemoveAt(findIndex);
                return true;
            }       
        }

        public void RemoveAt(int index)
        {
            if (_count == 0)
                throw new Exception("列表为空，无法进行删除操作");

            if (index == 0)
                _head = _head.Next;
            else
            {
                ListNode<T> preNode = GetEle(index);
                if (preNode == null)
                    throw new ArgumentOutOfRangeException("索引不合法");
                else
                {
                    preNode.Next = preNode.Next.Next;
                }
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
            StringBuilder stringBuilder = new StringBuilder();

            ListNode<T> tempNode = _head;
            for (int i = 0; i < _count; i++)
            {
                stringBuilder.Append($"{tempNode.Value} ");
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
