// <SnippetStackExample>
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
// </SnippetStackExample>

namespace StackExample
{
    // <SnippetStackUsage>
    using System;
    using Acme.Collections;
    class Example
    {
        static void Main()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1); // stack contains 1
            s.Push(10); // stack contains 1, 10
            s.Push(100); // stack contains 1, 10, 100
            Console.WriteLine(s.Pop()); // stack contains 1, 10
            Console.WriteLine(s.Pop()); // stack contains 1
            Console.WriteLine(s.Pop()); // stack is empty
        }
    }
    // </SnippetStackUsage>
}
