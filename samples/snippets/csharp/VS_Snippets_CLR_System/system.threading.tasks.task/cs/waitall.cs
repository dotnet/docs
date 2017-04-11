//<snippet02>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Example
{
    static void Main()
    {
        var tasks = new List<Task<int>>();
         
        // Define a delegate that prints and returns the system tick count
        Func<object, int> action = (object obj) =>
        {
            int i = (int)obj;

            // Make each thread sleep a different time in order to return a different tick count
            Thread.Sleep(i * 100);

            // The tasks that receive an argument between 2 and 5 throw exceptions
            if (2 <= i && i <= 5)
            {
                throw new InvalidOperationException("SIMULATED EXCEPTION");
            }

            int tickCount = Environment.TickCount;
            Console.WriteLine("Task={0}, i={1}, TickCount={2}, Thread={3}", Task.CurrentId, i, tickCount, Thread.CurrentThread.ManagedThreadId);

            return tickCount;
        };

        // Construct started tasks
        for (int i = 0; i < 10; i++)
        {
            int index = i;
            tasks.Add(Task<int>.Factory.StartNew(action, index));
        }

        try
        {
            // Wait for all the tasks to finish.
            Task.WaitAll(tasks.ToArray());

            // We should never get to this point
            Console.WriteLine("WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED.");
        }
        catch (AggregateException e)
        {
            Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
            for (int j = 0; j < e.InnerExceptions.Count; j++)
            {
                Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
            }
        }
    }
}
// The example displays output like the following:
//     Task=1, i=0, TickCount=1203822250, Thread=3
//     Task=2, i=1, TickCount=1203822359, Thread=4
//     Task=7, i=6, TickCount=1203823484, Thread=3
//     Task=8, i=7, TickCount=1203823890, Thread=4
//     Task=9, i=8, TickCount=1203824296, Thread=3
//     Task=10, i=9, TickCount=1203824796, Thread=4
//     
//     The following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)
//     
//     -------------------------------------------------
//     System.InvalidOperationException: SIMULATED EXCEPTION
//        at Example.<Main>b__0(Object obj)
//        at System.Threading.Tasks.Task`1.InnerInvoke()
//        at System.Threading.Tasks.Task.Execute()
//     
//     -------------------------------------------------
//     System.InvalidOperationException: SIMULATED EXCEPTION
//        at Example.<Main>b__0(Object obj)
//        at System.Threading.Tasks.Task`1.InnerInvoke()
//        at System.Threading.Tasks.Task.Execute()
//     
//     -------------------------------------------------
//     System.InvalidOperationException: SIMULATED EXCEPTION
//        at Example.<Main>b__0(Object obj)
//        at System.Threading.Tasks.Task`1.InnerInvoke()
//        at System.Threading.Tasks.Task.Execute()
//     
//     -------------------------------------------------
//     System.InvalidOperationException: SIMULATED EXCEPTION
//        at Example.<Main>b__0(Object obj)
//        at System.Threading.Tasks.Task`1.InnerInvoke()
//        at System.Threading.Tasks.Task.Execute()
//</snippet02>

