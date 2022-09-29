using System;
using System.Text;

namespace DataStructure
{
    public class SeqList<T> where T : IComparable<T>
    {
        private T[] _dataArray;
        private int _capacity;
        private int _count;

        public SeqList(int capacity = 4)
        {
            _dataArray = new T[capacity];
            _capacity = capacity;
            _count = 0;
        }

        public T this[int index]
        {
            get
            {
                return GetEle(index);
            }

            set
            {
                if (index < 0 || index > _count)
                    throw new ArgumentOutOfRangeException("索引不合法");

                _dataArray[index] = value;
            }
        }

        public int Count => _count;

        public void Add(T data)
        {
            if (_count == _capacity)
                EnsureCapacity();

            _dataArray[_count++] = data;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException("索引不合法");

            if (_count == _capacity)
                EnsureCapacity();

            for (int i = _count; i > index; i--)
                _dataArray[i] = _dataArray[i - 1];

            _dataArray[index] = data;
            _count++;
        }

        public T GetEle(int index)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException("索引不合法");

            return _dataArray[index];
        }

        public int GetIndexOf(T data)
        {
            int findIndex = -1;
            for (int i = 0; i < _count; i++)
            {
                if (_dataArray[i].Equals(data))
                {
                    findIndex = i;
                    break;
                }
            }

            return findIndex;
        }

        public bool Remove(T data)
        {
            int findIndex = GetIndexOf(data);
            if (findIndex > 0)
            {
                RemoveAt(findIndex);
                return true;
            }

            return false;    
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException("索引不合法");

            for (int i = index; i < _count - 1; i++)
                _dataArray[i] = _dataArray[i + 1];

            _count--;
        }

        public void Clear()
        {
            _dataArray = null;
            _capacity = 0;
            _count = 0;    
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < _count; i++)
            {
                stringBuilder.Append($"{_dataArray[i]} ");
            }

            return stringBuilder.ToString();
        }

        private void EnsureCapacity()
        {
            int newCapacity = _capacity * 2;
            T[] newDataArray = new T[newCapacity];
            for (int i = 0; i < _capacity; i++)
                newDataArray[i] = _dataArray[i];

            _dataArray = newDataArray;
            _capacity = newCapacity;
        }
    }
}
