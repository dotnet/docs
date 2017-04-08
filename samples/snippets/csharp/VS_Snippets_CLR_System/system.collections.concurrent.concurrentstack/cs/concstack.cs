//<snippet1>
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class CS_Ranges
{
        // Demonstrates:
        //      ConcurrentStack<T>.PushRange();
        //      ConcurrentStack<T>.TryPopRange();
        //      ConcurrentStack<T>.IsEmpty;
        static void Main ()
        {
            int errorCount = 0;

            // Construct a ConcurrentStack
            ConcurrentStack<int> cs = new ConcurrentStack<int>();

            // Push some consecutively numbered ranges
            cs.PushRange(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            cs.PushRange(new int[] { 8, 9, 10 });
            cs.PushRange(new int[] { 11, 12, 13, 14 });
            cs.PushRange(new int[] { 15, 16, 17, 18, 19, 20 });
            cs.PushRange(new int[] { 21, 22 });
            cs.PushRange(new int[] { 23, 24, 25, 26, 27, 28, 29, 30 });

            // Now read them back, 3 at a time, concurrently
            Parallel.For(0, 10, i =>
            {
                int[] range = new int[3];
                if (cs.TryPopRange(range) != 3)
                {
                    Console.WriteLine("CS: TryPopRange failed unexpectedly");
                    Interlocked.Increment(ref errorCount);
                }

                // Each range should be consecutive integers, if the range was extracted atomically
                // And it should be reverse of the original order...
                if (!range.Skip(1).SequenceEqual(range.Take(range.Length - 1).Select(x => x - 1)))
                {
                    Console.WriteLine("CS: Expected consecutive ranges.  range[0]={0}, range[1]={1}", range[0], range[1]);
                    Interlocked.Increment(ref errorCount);
                }
            });

            // We should have emptied the thing
            if (!cs.IsEmpty)
            {
                Console.WriteLine("CS: Expected IsEmpty to be true after emptying");
                errorCount++;
            }

            if (errorCount == 0) Console.WriteLine("  OK!");
        }
}
    //</snippet1>

//<snippet2>
class CS_Singles
{
        // Demonstrates:
        //      ConcurrentStack<T>.Push();
        //      ConcurrentStack<T>.TryPeek();
        //      ConcurrentStack<T>.TryPop();
        //      ConcurrentStack<T>.Clear();
        //      ConcurrentStack<T>.IsEmpty;
        static void Main ()
        {
            int errorCount = 0;

            // Construct a ConcurrentStack
            ConcurrentStack<int> cs = new ConcurrentStack<int>();

            // Push some elements onto the stack
            cs.Push(1);
            cs.Push(2);

            int result;

            // Peek at the top of the stack
            if (!cs.TryPeek(out result))
            {
                Console.WriteLine("CS: TryPeek() failed when it should have succeeded");
                errorCount++;
            }
            else if (result != 2)
            {
                Console.WriteLine("CS: TryPeek() saw {0} instead of 2", result);
                errorCount++;
            }

            // Pop a number off of the stack
            if (!cs.TryPop(out result))
            {
                Console.WriteLine("CS: TryPop() failed when it should have succeeded");
                errorCount++;
            }
            else if (result != 2)
            {
                Console.WriteLine("CS: TryPop() saw {0} instead of 2", result);
                errorCount++;
            }

            // Clear the stack, and verify that it is empty
            cs.Clear();
            if (!cs.IsEmpty)
            {
                Console.WriteLine("CS: IsEmpty not true after Clear()");
                errorCount++;
            }

            if (errorCount == 0) Console.WriteLine("  OK!");
        }
}
//</snippet2>