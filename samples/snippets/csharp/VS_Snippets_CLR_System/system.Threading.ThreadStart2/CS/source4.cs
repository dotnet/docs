﻿//<snippet4>
using System;
using System.Threading;

// The ThreadWithState class contains the information needed for
// a task, the method that executes the task, and a delegate
// to call when the task is complete.
//
public class ThreadWithState
{
    // State information used in the task.
    private string boilerplate;
    private int numberValue;

    // Delegate used to execute the callback method when the
    // task is complete.
    private ExampleCallback callback;

    // The constructor obtains the state information and the
    // callback delegate.
    public ThreadWithState(string text, int number,
        ExampleCallback callbackDelegate)
    {
        boilerplate = text;
        numberValue = number;
        callback = callbackDelegate;
    }

    // The thread procedure performs the task, such as
    // formatting and printing a document, and then invokes
    // the callback delegate with the number of lines printed.
    public void ThreadProc()
    {
        Console.WriteLine(boilerplate, numberValue);
        if (callback != null)
            callback(1);
    }
}

// Delegate that defines the signature for the callback method.
//
public delegate void ExampleCallback(int lineCount);

// Entry point for the example.
//
public class Example
{
    public static void Main()
    {
        // Supply the state information required by the task.
        ThreadWithState tws = new ThreadWithState(
            "This report displays the number {0}.",
            42,
            new ExampleCallback(ResultCallback)
        );

        Thread t = new Thread(new ThreadStart(tws.ThreadProc));
        t.Start();
        Console.WriteLine("Main thread does some work, then waits.");
        t.Join();
        Console.WriteLine(
            "Independent task has completed; main thread ends.");
    }

    // The callback method must match the signature of the
    // callback delegate.
    //
    public static void ResultCallback(int lineCount)
    {
        Console.WriteLine(
            "Independent task printed {0} lines.", lineCount);
    }
}
// The example displays the following output:
//       Main thread does some work, then waits.
//       This report displays the number 42.
//       Independent task printed 1 lines.
//       Independent task has completed; main thread ends.
//</snippet4>
