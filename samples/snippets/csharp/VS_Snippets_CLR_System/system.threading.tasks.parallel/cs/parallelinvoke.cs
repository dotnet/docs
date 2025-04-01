//<snippet01>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

    class ParallelInvokeDemo
    {

        // Demonstrated features:
        // 		Parallel.Invoke()
        // Expected results:
        // 		The threads on which each task gets executed may be different.
        //		The thread assignments may be different in different executions.
        //		The tasks may get executed in any order.
        // Documentation:
        //		http://msdn.microsoft.com/library/dd783942(VS.100).aspx
        static void Main()
        {
            try
            {
                Parallel.Invoke(
                    BasicAction,	// Param #0 - static method
                    () =>			// Param #1 - lambda expression
                    {
                        Console.WriteLine("Method=beta, Thread={0}", Thread.CurrentThread.ManagedThreadId);
                    },
                    delegate()		// Param #2 - in-line delegate
                    {
                        Console.WriteLine("Method=gamma, Thread={0}", Thread.CurrentThread.ManagedThreadId);
                    }
                );
            }
            // No exception is expected in this example, but if one is still thrown from a task,
            // it will be wrapped in AggregateException and propagated to the main thread.
            catch (AggregateException e)
            {
                Console.WriteLine($"An action has thrown an exception. THIS WAS UNEXPECTED.\n{e.InnerException.ToString()}");
            }
        }

        static void BasicAction()
        {
            Console.WriteLine("Method=alpha, Thread={0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
//</snippet01>
