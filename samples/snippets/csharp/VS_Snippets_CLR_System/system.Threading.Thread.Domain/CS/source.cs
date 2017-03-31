// <Snippet1>
using System;
using System.Threading;

class Test
{
    static void Main()
    {
        Thread newThread = new Thread(new ThreadStart(ThreadMethod));
        newThread.Start();
    }

    static void ThreadMethod()
    {
        Console.WriteLine(
            "Thread {0} started in {1} with AppDomainID = {2}.",
            AppDomain.GetCurrentThreadId().ToString(), 
            Thread.GetDomain().FriendlyName, 
            Thread.GetDomainID().ToString());
    }
}
// </Snippet1>