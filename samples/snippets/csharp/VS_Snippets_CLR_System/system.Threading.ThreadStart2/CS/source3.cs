//<snippet3>
using System;
using System.Threading;

// The ThreadWithState class contains the information needed for
// a task, and the method that executes the task.
//
public class ThreadWithState
{
    // State information used in the task.
    private string _boilerplate;
    private int _numberValue;

    // The constructor obtains the state information.
    public ThreadWithState(string text, int number)
    {
        _boilerplate = text;
        _numberValue = number;
    }

    // The thread procedure performs the task, such as formatting
    // and printing a document.
    public void ThreadProc()
    {
        Console.WriteLine(_boilerplate, _numberValue);
    }
}

// Entry point for the example.
public class Example
{
    public static void Main()
    {
        // Supply the state information required by the task.
        ThreadWithState tws = new("This report displays the number {0}.", 42);

        // Create a thread to execute the task, and then
        // start the thread.
        Thread t = new(new ThreadStart(tws.ThreadProc));
        t.Start();
        Console.WriteLine("Main thread does some work, then waits.");
        t.Join();
        Console.WriteLine(
            "Independent task has completed; main thread ends.");
    }
}

// The example displays the following output:
//       Main thread does some work, then waits.
//       This report displays the number 42.
//       Independent task has completed; main thread ends.
//</snippet3>
