using System;
namespace Acme.Collections
{
    public class Stack<T>
    {
        Entry top;
        public void Push(T data)
        {
            top = new Entry(top, data);
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            T result = top.data;
            top = top.next;
            return result;
        }

        class Entry
        {
            public Entry next;
            public T data;
            public Entry(Entry next, T data)
            {
                this.next = next;
                this.data = data;
            }
        }
    }
}
