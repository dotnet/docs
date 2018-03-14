//<Snippet9>
using System.Collections;
using System.Collections.Generic;

namespace GenericIteratorExample
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] values = new T[100];
        private int top = 0;

        public void Push(T t) { values[top++] = t; }
        public T Pop() { return values[--top]; }

        // These make Stack<T> implement IEnumerable<T> allowing
        // a stack to be used in a foreach statement.
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = top - 1; i >= 0; i-- )
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Iterate from top to bottom.
        public IEnumerable<T> TopToBottom
        {
            get
            {
                // Since we implement IEnumerable<T>
                // and the default iteration is top to bottom,
                // just return the object.
                return this;
            }
        }

        // Iterate from bottom to top.
        public IEnumerable<T> BottomToTop
        {
            get
            {
                for (int i = 0; i < top; i++)
                {
                    yield return values[i];
                }
            }
        }

        // A parameterized iterator that return n items from the top
        public IEnumerable<T> TopN(int n)
        {
            // in this example we return less than N if necessary 
            int j = n >= top ? 0 : top - n;

            for (int i = top; --i >= j; )
            {
                yield return values[i];
            }
        }
    }

    // This code uses a stack and the TopToBottom and BottomToTop properties 
    // to enumerate the elements of the stack.
    class Test
    {
        static void Main()
        {
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                s.Push(i);
            }

            // Prints: 9 8 7 6 5 4 3 2 1 0
            // Foreach legal since s implements IEnumerable<int>
            foreach (int n in s)
            {
                System.Console.Write("{0} ", n);
            }
            System.Console.WriteLine();

            // Prints: 9 8 7 6 5 4 3 2 1 0
            // Foreach legal since s.TopToBottom returns IEnumerable<int>
            foreach (int n in s.TopToBottom)
            {
                System.Console.Write("{0} ", n);
            }
            System.Console.WriteLine();

            // Prints: 0 1 2 3 4 5 6 7 8 9
            // Foreach legal since s.BottomToTop returns IEnumerable<int>
            foreach (int n in s.BottomToTop)
            {
                System.Console.Write("{0} ", n);
            }
            System.Console.WriteLine();

            // Prints: 9 8 7 6 5 4 3
            // Foreach legal since s.TopN returns IEnumerable<int>
            foreach (int n in s.TopN(7))
            {
                System.Console.Write("{0} ", n);
            }
            System.Console.WriteLine();

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
/* Output:
    9 8 7 6 5 4 3 2 1 0
    9 8 7 6 5 4 3 2 1 0
    0 1 2 3 4 5 6 7 8 9
    9 8 7 6 5 4 3
*/
//</Snippet9>
