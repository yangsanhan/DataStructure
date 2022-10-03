namespace DataStructure
{
    public class SeqStack<T>
    {
        private T[] _data;
        private int _top;

        public SeqStack(int capacity = 4)
        {
            _data = new T[capacity];
            _top = 0;
        }

        public int Count => _count;

        public void Push(T data)
        {
            if (_top == _data.Length)
                EnSureCapacity(_data.Length * 2);

            _data[_top++] = data;
        }

        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            else
                return _data[_top - 1];
        }

        public T Pop()
        {
            if (IsEmpty())
                return default(T);
            else
            {
                T popValue = _data[--_top];
                if (_top > 0 && _top < _data.Length / 4)
                    EnSureCapacity(_data.Length / 2);

                
                return popValue;
            }
                
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }

        public void EnSureCapacity(int newCapacity)
        {
            T[] newData = new T[newCapacity];        
            for (int i = 0; i < _top; i++)
                newData[i] = _data[i];

            _data = newData;
        }
    }
}
