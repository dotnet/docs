//<Snippet1>
using System;
using System.Threading; 

namespace Examples.AdvancedProgramming.AsynchronousOperations
{
    public class AsyncDemo 
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId) 
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }
    // The delegate must have the same signature as the method
    // it will call asynchronously.
    public delegate string AsyncMethodCaller(int callDuration, out int threadId);
}
//</Snippet1>
