using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class SeqQueue<T>
    {
        private T[] _data;
        private int _count;
        private int _head;
        private int _tail;

        public SeqQueue(int capacity = 4)
        {
            _data = new T[capacity];
            _count = 0;
            _head = _tail = 0;             
        }

        public int Count => _count;

        public void EnQueue(T data)
        {
            if (_count == _data.Length)
                EnSureCapacity(_data.Length * 2);

            _data[_tail] = data;
            _tail++;
            _count++;
        }

        public T DeQueue()
        {
            if (IsEmpty())
                return default(T);
            else
            {
                T deQueueValue = _data[_head];
                _data[_head] = default(T);
                _head++;

                if (_count > 0 && _count < _data.Length / 4)
                    EnSureCapacity(_data.Length / 2);

                _count--;

                return deQueueValue;
            }
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public void EnSureCapacity(int newCapacity)
        {
            T[] newData = new T[newCapacity];
            for (int i = 0; i < _count; i++)
                newData[i] = _data[i];

            _data = newData;
        }
    }
}
