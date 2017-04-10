//<Snippet1>
using System;
using System.Threading;

class Example
{
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Sleep for 2 seconds.");
            Thread.Sleep(2000);
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
