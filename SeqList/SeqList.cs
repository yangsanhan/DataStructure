using System;
using System.Text;

namespace DataStrcuture
{
    public class SeqList<T> where T : IComparable<T>
    {
        private T[] _data;
        private int _capacity;
        private int _length;

        public SeqList(int capacity = 4)
        {
            _data = new T[capacity];
            _capacity = capacity;
            _length = 0;
        }

        public T this[int index]
        {
            get
            {
                return GetEle(index);
            }

            set
            {
                if (index < 0 || index > _length)
                    throw new IndexOutOfRangeException("索引不合法");

                _data[index] = value;
            }
        }

        //获取列表的长度
        public int Count => _length;

        public void Add(T value)
        {
            if (_length == _capacity)
                EnsureCapacity();

            _data[_length++] = value;       
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > _length)
                throw new IndexOutOfRangeException("索引不合法");

            if (_length == _capacity)
                EnsureCapacity();

            for (int i = _length; i > index; i--)
                _data[i] = _data[i - 1];

            _data[index] = value;
            _length++;
       }

        public T GetEle(int index)
        {
            if (index < 0 || index > _length)
                throw new IndexOutOfRangeException("索引不合法");

            return _data[index];
        }

        public int GetIndexOf(T value)
        {
            int findIndex = -1;
            for(int i = 0; i < _length; i++)
            {
                if (_data[i].Equals(value))
                {
                    findIndex = i;
                    break;
                }
            }

            return findIndex;
        }

        public bool Remove(T value)
        {
            int findIndex = GetIndexOf(value);

            if(findIndex > 0)
            {
                RemoveAt(findIndex);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > _length)
                throw new IndexOutOfRangeException("索引不合法");

            for (int i = index; i < _length - 1; i++)
                _data[i] = _data[i + 1];

            _length--;
        }    

        public void Clear()
        {
            _data = null;
            _length = 0;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < _length; i++)
            {
                stringBuilder.Append($"{_data[i]} ");
            }

            return stringBuilder.ToString();
        }

        private void EnsureCapacity()
        {
            int newCapacity = _capacity * 2;
            T[] newData = new T[newCapacity];
            for (int i = 0; i < _capacity; i++)
                newData[i] = _data[i];

            _data = newData;
            _capacity = newCapacity;
        }
    }
}
