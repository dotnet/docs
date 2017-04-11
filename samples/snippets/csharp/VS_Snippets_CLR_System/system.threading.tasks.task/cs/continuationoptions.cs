//<snippet04>
using System;
using System.Threading;
using System.Threading.Tasks;

class ContinuationOptionsDemo
{
    // Demonstrated features:
    //      TaskContinuationOptions
    //		Task.ContinueWith()
    // 		Task.Factory
    //		Task.Wait()
    // Expected results:
    // 		This sample demonstrates branched continuation sequences - Task+Commit or Task+Rollback.
    //      Notice that no if statements are used.
    //		The first sequence is successful - tran1 and commitTran1 are executed. rollbackTran1 is canceled.
    //		The second sequence is unsuccessful - tran2 and rollbackTran2 are executed. tran2 is faulted, and commitTran2 is canceled.
    // Documentation:
    //		http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskcontinuationoptions(VS.100).aspx
    static void Main()
    {
        Action success = () => Console.WriteLine("Task={0}, Thread={1}: Begin successful transaction",
                                                Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        Action failure = () =>
        {
            Console.WriteLine("Task={0}, Thread={1}: Begin transaction and encounter an error",
                                Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            throw new InvalidOperationException("SIMULATED EXCEPTION");
        };

        Action<Task> commit = (antecendent) => Console.WriteLine("Task={0}, Thread={1}: Commit transaction",
                                                                Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        Action<Task> rollback = (antecendent) =>
        {
            // "Observe" your antecedent's exception so as to avoid an exception
            // being thrown on the finalizer thread
            var unused = antecendent.Exception;

            Console.WriteLine("Task={0}, Thread={1}: Rollback transaction",
                  Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        };

        // Successful transaction - Begin + Commit
        Console.WriteLine("Demonstrating a successful transaction");

        // Initial task
        // Treated as "fire-and-forget" -- any exceptions will be cleaned up in rollback continuation
        Task tran1 = Task.Factory.StartNew(success);

        // The following task gets scheduled only if tran1 completes successfully
        var commitTran1 = tran1.ContinueWith(commit, TaskContinuationOptions.OnlyOnRanToCompletion);

        // The following task gets scheduled only if tran1 DOES NOT complete successfully
        var rollbackTran1 = tran1.ContinueWith(rollback, TaskContinuationOptions.NotOnRanToCompletion);

        // For demo purposes, wait for the sample to complete
        commitTran1.Wait();

        // -----------------------------------------------------------------------------------


        // Failed transaction - Begin + exception + Rollback
        Console.WriteLine("\nDemonstrating a failed transaction");

        // Initial task
        // Treated as "fire-and-forget" -- any exceptions will be cleaned up in rollback continuation
        Task tran2 = Task.Factory.StartNew(failure);

        // The following task gets scheduled only if tran2 completes successfully
        var commitTran2 = tran2.ContinueWith(commit, TaskContinuationOptions.OnlyOnRanToCompletion);

        // The following task gets scheduled only if tran2 DOES NOT complete successfully
        var rollbackTran2 = tran2.ContinueWith(rollback, TaskContinuationOptions.NotOnRanToCompletion);

        // For demo purposes, wait for the sample to complete
        rollbackTran2.Wait();
    }

}
//</snippet04>

