//<snippet05>
using System;
using System.Threading;
using System.Threading.Tasks;

class ContinueWhenMultiDemo
{
    // Demonstrated features:
    // 		Task.Factory
    //		TaskFactory.ContinueWhenAll()
    //		TaskFactory.ContinueWhenAny()
    //		Task.Wait()
    // Expected results:
    // 		Three tasks are created in parallel. 
    //		Each task for a different period of time prints a number and returns it.
    //      A ContinueWhenAny() task indicates the first of the three tasks to complete.
    //      A ContinueWhenAll() task sums up the results of the three tasks and prints out the total.
    // Documentation:
    //		http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskfactory_members(VS.100).aspx
    static void Main()
    {
        // Schedule a list of tasks that return integer
        Task<int>[] tasks = new Task<int>[]
			{
				Task<int>.Factory.StartNew(() => 
					{
						Thread.Sleep(500);
						Console.WriteLine("Task={0}, Thread={1}, x=5", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
						return 5;
					}),

				Task<int>.Factory.StartNew(() => 
					{
						Thread.Sleep(10);
						Console.WriteLine("Task={0}, Thread={1}, x=3", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
						return 3;
					}),

				Task<int>.Factory.StartNew(() => 
					{
						Thread.Sleep(200);
						Console.WriteLine("Task={0}, Thread={1}, x=2", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
						return 2;
					})
			};

        // Schedule a continuation to indicate the result of the first task to complete
        Task.Factory.ContinueWhenAny(tasks, winner =>
        {
            // You would expect winning result = 3 on multi-core systems, because you expect
            // tasks[1] to finish first.
            Console.WriteLine("Task={0}, Thread={1} (ContinueWhenAny): Winning result = {2}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, winner.Result);
        });


        // Schedule a continuation that sums up the results of all tasks, then wait on it.
        // The list of antecendent tasks is passed as an argument by the runtime.
        Task.Factory.ContinueWhenAll(tasks,
            (antecendents) =>
            {
                int sum = 0;
                foreach (Task<int> task in antecendents)
                {
                    sum += task.Result;
                }

                Console.WriteLine("Task={0}, Thread={1}, (ContinueWhenAll): Total={2} (expected 10)", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, sum);
            })
            .Wait();
    }
}
//</snippet05>

