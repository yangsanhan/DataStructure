using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public interface IQueue<T>
    {
        int Count { get; }
        bool IsEmpty();
        void EnQueue(T item);
        T DeQueue();
        void Clear();
    }
}
