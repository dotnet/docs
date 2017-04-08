//<snippet01>
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class UnWrapDemo
{
     // Demonstrated features:
        //		Task.Unwrap()
        // 		Task.Factory.StartNew()
        //		Task.ContinueWith()
        // Expected results:
        // 		Indicates that continuation chains can be set up virtually instantaneously using Unwrap(), and then left to run on their own.
        //      The results of the RemoteIncrement(0) chain and the RemoteIncrement(4) chain may be intermixed with each other.
        //		The results of the sequence that starts with RemoteIncrement(4) are in strict order.
        // Documentation:
        //		http://msdn.microsoft.com/en-us/library/dd781129(VS.100).aspx
        // More information:
        //		http://blogs.msdn.com/pfxteam/archive/2009/11/04/9917581.aspx
        // Other notes:
        //		The combination of Task<T>, ContinueWith() and Unwrap() can be particularly useful for setting up a chain of long-running
        //      tasks where each task uses the results of its predecessor.
        static void Main()
        {
            // Invoking individual tasks is straightforward
            Task<int> t1 = RemoteIncrement(0);
            Console.WriteLine("Started RemoteIncrement(0)");

            // Chain together the results of (simulated) remote operations.
            // The use of Unwrap() instead of .Result below prevents this thread from blocking while setting up this continuation chain.
            Task<int> t2 = RemoteIncrement(4)
                .ContinueWith(t => RemoteIncrement(t.Result))			// RemoteIncrement() returns Task<int> so no unwrapping is needed for the first continuation.
                .Unwrap().ContinueWith(t => RemoteIncrement(t.Result))	// ContinueWith() returns Task<Task<int>>. Therefore unwrapping is needed.
                .Unwrap().ContinueWith(t => RemoteIncrement(t.Result))	// and on it goes...
                .Unwrap();
            Console.WriteLine("Started RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)");

            try
            {
                t1.Wait();
                Console.WriteLine("Finished RemoteIncrement(0)\n");

                t2.Wait();
                Console.WriteLine("Finished RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)");
            }
            catch (AggregateException e)
            {
                Console.WriteLine("A task has thrown the following (unexpected) exception:\n{0}", e);
            }

        }
        // This method represents a remote API.
        static Task<int> RemoteIncrement(int n)
        {
            return Task<int>.Factory.StartNew(
                (obj) =>
                {
                    // Simulate a slow operation
                    Thread.Sleep(1 * 1000);

                    int x = (int)obj;
                    Console.WriteLine("Thread={0}, Next={1}", Thread.CurrentThread.ManagedThreadId, ++x);
                    return x;
                },
                n);
        }
      
}

//</snippet01>