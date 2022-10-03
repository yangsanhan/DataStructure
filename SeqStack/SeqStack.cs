namespace DataStructure
{
    public class SeqStack<T>
    {
        private T[] _data;
        private int _count;

        public SeqStack(int capacity = 4)
        {
            _data = new T[capacity];
            _count = 0;
        }

        public int Count => _count;

        public void Push(T data)
        {
            if (_count == _data.Length)
                EnSureCapacity(_data.Length * 2);

            _data[_count++] = data;
        }

        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            else
                return _data[_count - 1];
        }

        public T Pop()
        {
            if (IsEmpty())
                return default(T);
            else
            {
                T popValue = _data[--_count];
                if (_count > 0 && _count < _data.Length / 4)
                    EnSureCapacity(_data.Length / 2);

                
                return popValue;
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
