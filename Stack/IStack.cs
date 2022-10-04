using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public interface IStack<T>
    {
        int Count { get; }
        bool IsEmpty();
        void Push(T item);
        T Peek();
        T Pop();
    }
}
