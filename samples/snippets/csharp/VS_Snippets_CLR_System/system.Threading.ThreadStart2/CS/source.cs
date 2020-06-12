// <Snippet1>
using System;
using System.Threading;

class Test
{
    static void Main()
    {
        // To start a thread using a static thread procedure, use the
        // class name and method name when you create the ThreadStart
        // delegate. Beginning in version 2.0 of the .NET Framework,
        // it is not necessary to create a delegate explicitly.
        // Specify the name of the method in the Thread constructor,
        // and the compiler selects the correct delegate. For example:
        //
        // Thread newThread = new Thread(Work.DoWork);
        //
        ThreadStart threadDelegate = new ThreadStart(Work.DoWork);
        Thread newThread = new Thread(threadDelegate);
        newThread.Start();

        // To start a thread using an instance method for the thread
        // procedure, use the instance variable and method name when
        // you create the ThreadStart delegate. Beginning in version
        // 2.0 of the .NET Framework, the explicit delegate is not
        // required.
        //
        Work w = new Work();
        w.Data = 42;
        threadDelegate = new ThreadStart(w.DoMoreWork);
        newThread = new Thread(threadDelegate);
        newThread.Start();
    }
}

class Work
{
    public static void DoWork()
    {
        Console.WriteLine("Static thread procedure.");
    }
    public int Data;
    public void DoMoreWork()
    {
        Console.WriteLine("Instance thread procedure. Data={0}", Data);
    }
}

/* This code example produces the following output (the order
   of the lines might vary):
Static thread procedure.
Instance thread procedure. Data=42
 */
// </Snippet1>