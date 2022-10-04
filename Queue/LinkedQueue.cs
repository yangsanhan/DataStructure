namespace DataStructure
{
    public class LinkedQueue<T>
    {
        private QueueNode<T> _front;
        private QueueNode<T> _rear;
        private int _count;

        public LinkedQueue()
        {
            _front = null;
            _rear = null;
            _count = 0;
        }

        public int Count => _count;

        public void EnQueue(T data)
        {
            QueueNode<T> newNode = new QueueNode<T>(data);
            if(IsEmpty())
            {
                _front = newNode;
                _rear = newNode;
            }
            else
            {
                _rear.Next = newNode;
                _rear = newNode;
            }

            _count++;
        }

        public T DeQueue()
        {
            if (IsEmpty())
                return default(T);
            else
            {
                T deQueueValue = _front.Value;
                _front = _front.Next;
                _count--;

                return deQueueValue;
            }
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }

    public class QueueNode<T>
    {
        public QueueNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public QueueNode<T> Next { get; set; }
    }
}
