//<Snippet5>
using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Examples.AdvancedProgramming.AsynchronousOperations
{
    public class AsyncMain4
    {
        static void Main()
        {
            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            // The threadId parameter of TestMethod is an out parameter, so
            // its input value is never used by TestMethod. Therefore, a dummy
            // variable can be passed to the BeginInvoke call. If the threadId
            // parameter were a ref parameter, it would have to be a class-
            // level field so that it could be passed to both BeginInvoke and
            // EndInvoke.
            int dummy = 0;

            // Initiate the asynchronous call, passing three seconds (3000 ms)
            // for the callDuration parameter of TestMethod; a dummy variable
            // for the out parameter (threadId); the callback delegate; and
            // state information that can be retrieved by the callback method.
            // In this case, the state information is a string that can be used
            // to format a console message.
            IAsyncResult result = caller.BeginInvoke(3000,
                out dummy,
                new AsyncCallback(CallbackMethod),
                "The call executed on thread {0}, with return value \"{1}\".");

            Console.WriteLine($"The main thread {Thread.CurrentThread.ManagedThreadId} continues to execute...");

            // The callback is made on a ThreadPool thread. ThreadPool threads
            // are background threads, which do not keep the application running
            // if the main thread ends. Comment out the next line to demonstrate
            // this.
            Thread.Sleep(4000);

            Console.WriteLine("The main thread ends.");
        }

        // The callback method must have the same signature as the
        // AsyncCallback delegate.
        static void CallbackMethod(IAsyncResult ar)
        {
            // Retrieve the delegate.
            AsyncResult result = (AsyncResult) ar;
            AsyncMethodCaller caller = (AsyncMethodCaller) result.AsyncDelegate;

            // Retrieve the format string that was passed as state
            // information.
            string formatString = (string) ar.AsyncState;

            // Define a variable to receive the value of the out parameter.
            // If the parameter were ref rather than out then it would have to
            // be a class-level field so it could also be passed to BeginInvoke.
            int threadId = 0;

            // Call EndInvoke to retrieve the results.
            string returnValue = caller.EndInvoke(out threadId, ar);

            // Use the format string to format the output message.
            Console.WriteLine(formatString, threadId, returnValue);
        }
    }
}

/* This example produces output similar to the following:

The main thread 1 continues to execute...
Test method begins.
The call executed on thread 3, with return value "My call time was 3000.".
The main thread ends.
 */
//</Snippet5>
