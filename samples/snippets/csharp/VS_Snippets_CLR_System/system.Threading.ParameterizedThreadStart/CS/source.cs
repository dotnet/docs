// <Snippet1>
using System;
using System.Threading;

public class Work
{
    public static void Main()
    {
        // Start a thread that calls a parameterized static method.
        Thread newThread = new Thread(Work.DoWork);
        newThread.Start(42);

        // Start a thread that calls a parameterized instance method.
        Work w = new Work();
        newThread = new Thread(w.DoMoreWork);
        newThread.Start("The answer.");
    }
 
    public static void DoWork(object data)
    {
        Console.WriteLine("Static thread procedure. Data='{0}'",
            data);
    }

    public void DoMoreWork(object data)
    {
        Console.WriteLine("Instance thread procedure. Data='{0}'",
            data);
    }
}
// This example displays output like the following:
//       Static thread procedure. Data='42'
//       Instance thread procedure. Data='The answer.'
// </Snippet1>


