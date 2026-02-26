// <Snippet1>
using System;
using System.Threading;

public class Example
{
    public static void Main()
    {
        // Interrupt a sleeping thread.
        var sleepingThread = new Thread(SleepIndefinitely);
        sleepingThread.Name = "Sleeping";
        sleepingThread.Start();
        Thread.Sleep(2000);
        sleepingThread.Interrupt();
        sleepingThread.Join();
    }

    private static void SleepIndefinitely()
    {
        Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' about to sleep indefinitely.");
        try
        {
            Thread.Sleep(Timeout.Infinite);
        }
        catch (ThreadInterruptedException)
        {
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' awoken.");
        }
        finally
        {
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' executing finally block.");
        }
        Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' finishing normal execution.");
        Console.WriteLine();
    }
}
// The example displays the following output:
//       Thread 'Sleeping' about to sleep indefinitely.
//       Thread 'Sleeping' awoken.
//       Thread 'Sleeping' executing finally block.
//       Thread 'Sleeping' finishing normal execution.
// </Snippet1>
