// <Snippet1>
using System;
using System.Threading;

class Test
{
    static TimeSpan waitTime = new TimeSpan(0, 0, 1);

    public static void Main() 
    {
        Thread newThread = new Thread(Work);
        newThread.Start();

        if(newThread.Join(waitTime + waitTime)) {
            Console.WriteLine("New thread terminated.");
        }
        else {
            Console.WriteLine("Join timed out.");
        }
    }

    static void Work()
    {
        Thread.Sleep(waitTime);
    }
}
// The example displays the following output:
//        New thread terminated.
// </Snippet1>