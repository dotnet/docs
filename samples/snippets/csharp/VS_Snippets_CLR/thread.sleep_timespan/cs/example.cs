//<Snippet1>
using System;
using System.Threading;

class Example
{
    static void Main()
    {
        TimeSpan interval = new TimeSpan(0, 0, 2);

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Sleep for 2 seconds.");
            Thread.Sleep(interval);
        }

        Console.WriteLine("Main thread exits.");
    }
}

/* This example produces the following output:

Sleep for 2 seconds.
Sleep for 2 seconds.
Sleep for 2 seconds.
Sleep for 2 seconds.
Sleep for 2 seconds.
Main thread exits.
 */
//</Snippet1>
