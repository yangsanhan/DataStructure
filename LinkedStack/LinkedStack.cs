namespace DataStructure
{
    public class LinkedStack<T>
    {
        private StackNode<T> _top;
        private int _count;

        public LinkedStack()
        {
            _top = null;
            _count = 0;
        }

        public int Count => _count;

        public void Push(T data)
        {
            StackNode<T> newNode = new StackNode<T>(data);

            if (_top == null)
                _top = newNode;
            else
            {
                newNode.Next = _top;
                _top = newNode;
            }               

            _count++;
        }

        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            else
                return _top.Value;
        }

        public T Pop()
        {
            if (IsEmpty())
                return default(T);
            else
            {
                T popValue = _top.Value;
                _top = _top.Next;
                _count--;
                return popValue;
            }            
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }

    public class StackNode<T>
    {
        public StackNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public StackNode<T> Next { get; set; }
    }
}
