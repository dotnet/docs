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