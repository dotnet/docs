//<snippet01>
using System;
using System.Threading;
using System.Threading.Tasks;

class ThreadLocalDemo
{
    
        // Demonstrates:
        //      ThreadLocal(T) constructor
        //      ThreadLocal(T).Value
        //      One usage of ThreadLocal(T)
        static void Main()
        {
            // Thread-Local variable that yields a name for a thread
            ThreadLocal<string> ThreadName = new ThreadLocal<string>(() =>
            {
                return "Thread" + Thread.CurrentThread.ManagedThreadId;
            });

            // Action that prints out ThreadName for the current thread
            Action action = () =>
            {
                // If ThreadName.IsValueCreated is true, it means that we are not the
                // first action to run on this thread.
                bool repeat = ThreadName.IsValueCreated;

                Console.WriteLine("ThreadName = {0} {1}", ThreadName.Value, repeat ? "(repeat)" : "");
            };

            // Launch eight of them.  On 4 cores or less, you should see some repeat ThreadNames
            Parallel.Invoke(action, action, action, action, action, action, action, action);

            // Dispose when you are done
            ThreadName.Dispose();
        }
}
// This multithreading example can produce different outputs for each 'action' invocation and will vary with each run.
// Therefore, the example output will resemble but may not exactly match the following output (from a 4 core processor):
// ThreadName = Thread5 
// ThreadName = Thread6 
// ThreadName = Thread4 
// ThreadName = Thread6 (repeat)
// ThreadName = Thread1 
// ThreadName = Thread4 (repeat)
// ThreadName = Thread7 
// ThreadName = Thread5 (repeat)
//</snippet01>
