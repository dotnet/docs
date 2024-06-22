namespace snippets;

public class SchedulingThreads
{
    public void RunMultipleThreadsOnDifferentPriorities()
    {
        var threadsList = new List<Thread>(9);

        // Initialize 9 threads. 5 with Highest priority, and the first 4 from Lowest to Normal range.
        for (int i = 0; i < 9; i++)
        {
            var thread = new Thread(() => { new ThreadWithCallback(Callback).Process(); });

            if (i > 3)
                thread.Priority = ThreadPriority.Highest;
            else
                thread.Priority = (ThreadPriority)i;

            threadsList.Add(thread);
        }

        threadsList.ForEach(thread => thread.Start());
    }

    public void Callback(ThreadPriority threadPriority)
    {
        Console.WriteLine($"Callback in {threadPriority} priority. \t\t ThreadId: {Thread.CurrentThread.ManagedThreadId}.");
    }

    public class ThreadWithCallback
    {
        public ThreadWithCallback(Action<ThreadPriority> callback)
        {
            this.callback = callback;
        }

        public Action<ThreadPriority> callback;

        public void Process()
        {
            Console.WriteLine($"Entered process in {Thread.CurrentThread.Priority} priority.  \t\t ThreadId: {Thread.CurrentThread.ManagedThreadId}.");
            Thread.Sleep(1000);
            Console.WriteLine($"Finished process in {Thread.CurrentThread.Priority} priority. \t\t ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            if (callback != null)
            {
                callback(Thread.CurrentThread.Priority);
            }
        }
    }

    // The example displays the output like the following:
    //      Entered process in Highest priority.             ThreadId: 9.
    //      Entered process in Highest priority.             ThreadId: 12.
    //      Entered process in Normal priority.              ThreadId: 6.
    //      Entered process in BelowNormal priority.         ThreadId: 5.
    //      Entered process in Lowest priority.              ThreadId: 4.
    //      Entered process in AboveNormal priority.         ThreadId: 7.
    //      Entered process in Highest priority.             ThreadId: 11.
    //      Entered process in Highest priority.             ThreadId: 10.
    //      Entered process in Highest priority.             ThreadId: 8.
    //      Finished process in Highest priority.            ThreadId: 9.
    //      Finished process in Highest priority.            ThreadId: 12.
    //      Finished process in Highest priority.            ThreadId: 8.
    //      Finished process in Highest priority.            ThreadId: 10.
    //      Callback in Highest priority.                    ThreadId: 10.
    //      Finished process in AboveNormal priority.        ThreadId: 7.
    //      Callback in AboveNormal priority.                ThreadId: 7.
    //      Finished process in Lowest priority.             ThreadId: 4.
    //      Callback in Lowest priority.                     ThreadId: 4.
    //      Finished process in Normal priority.             ThreadId: 6.
    //      Callback in Highest priority.                    ThreadId: 9.
    //      Callback in Highest priority.                    ThreadId: 8.
    //      Callback in Highest priority.                    ThreadId: 12.
    //      Finished process in Highest priority.            ThreadId: 11.
    //      Callback in Highest priority.                    ThreadId: 11.
    //      Callback in Normal priority.                     ThreadId: 6.
    //      Finished process in BelowNormal priority.        ThreadId: 5.
    //      Callback in BelowNormal priority.                ThreadId: 5.
}
