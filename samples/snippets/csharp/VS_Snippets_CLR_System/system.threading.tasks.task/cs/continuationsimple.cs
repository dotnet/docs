//<snippet03>
using System;
using System.Threading;
using System.Threading.Tasks;

class ContinuationSimpleDemo
{
    // Demonstrated features:
    // 		Task.Factory
    //		Task.ContinueWith()
    //		Task.Wait()
    // Expected results:
    // 		A sequence of three unrelated tasks is created and executed in this order - alpha, beta, gamma.
    //		A sequence of three related tasks is created - each task negates its argument and passes is to the next task: 5, -5, 5 is printed.
    //		A sequence of three unrelated tasks is created where tasks have different types.
    // Documentation:
    //		http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskfactory_members(VS.100).aspx
    static void Main()
    {
        Action<string> action =
            (str) =>
                Console.WriteLine("Task={0}, str={1}, Thread={2}", Task.CurrentId, str, Thread.CurrentThread.ManagedThreadId);

        // Creating a sequence of action tasks (that return no result).
        Console.WriteLine("Creating a sequence of action tasks (that return no result)");
        Task.Factory.StartNew(() => action("alpha"))
            .ContinueWith(antecendent => action("beta"))        // Antecedent data is ignored
            .ContinueWith(antecendent => action("gamma"))
            .Wait();


        Func<int, int> negate =
            (n) =>
            {
                Console.WriteLine("Task={0}, n={1}, -n={2}, Thread={3}", Task.CurrentId, n, -n, Thread.CurrentThread.ManagedThreadId);
                return -n;
            };

        // Creating a sequence of function tasks where each continuation uses the result from its antecendent
        Console.WriteLine("\nCreating a sequence of function tasks where each continuation uses the result from its antecendent");
        Task<int>.Factory.StartNew(() => negate(5))
            .ContinueWith(antecendent => negate(antecendent.Result))		// Antecedent result feeds into continuation
            .ContinueWith(antecendent => negate(antecendent.Result))
            .Wait();


        // Creating a sequence of tasks where you can mix and match the types
        Console.WriteLine("\nCreating a sequence of tasks where you can mix and match the types");
        Task<int>.Factory.StartNew(() => negate(6))
            .ContinueWith(antecendent => action("x"))
            .ContinueWith(antecendent => negate(7))
            .Wait();
    }
}
//</snippet03>

