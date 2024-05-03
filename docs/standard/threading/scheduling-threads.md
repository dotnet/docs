---
description: "Learn more about: Scheduling threads"
title: "Scheduling threads"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "threading [.NET], scheduling"
  - "scheduling threads"
ms.assetid: 67e4a0eb-3095-4ea7-b20f-908faa476277
---
# Scheduling threads

Every thread has a thread priority assigned to it. Threads created within the common language runtime are initially assigned the priority of <xref:System.Threading.ThreadPriority.Normal?displayProperty=nameWithType>. Threads created outside the runtime retain the priority they had before they entered the managed environment. You can get or set the priority of any thread with the <xref:System.Threading.Thread.Priority?displayProperty=nameWithType> property.  
  
 Threads are scheduled for execution based on their priority. Even though threads are executing within the runtime, all threads are assigned processor time slices by the operating system. The details of the scheduling algorithm used to determine the order in which threads are executed varies with each operating system. Under some operating systems, the thread with the highest priority (of those threads that can be executed) is always scheduled to run first. If multiple threads with the same priority are all available, the scheduler cycles through the threads at that priority, giving each thread a fixed time slice in which to execute. As long as a thread with a higher priority is available to run, lower priority threads do not get to execute. When there are no more runnable threads at a given priority, the scheduler moves to the next lower priority and schedules the threads at that priority for execution. If a higher priority thread becomes runnable, the lower priority thread is preempted and the higher priority thread is allowed to execute once again. On top of all that, the operating system can also adjust thread priorities dynamically as an application's user interface is moved between foreground and background. Other operating systems might choose to use a different scheduling algorithm.  

## Example 
Here is an example of the execution of 9 threads across all 5 priority levels from the [ThreadPriority](https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.priority) enumeration where the last 5 are on highest priority level. Also we have callback support from the previous article that in this context demonstrates that the order of thread initialization and prioritization may not always be reflected in subsequent code nor process executions start order. Meaning, we see here the parallel nature of code execution and demonstation of assigned processor time slices by the operating system for every thread. This highlights the influence and control of the environment in which threads are running. With that said, we certainly see that the highest priority threads are indeed receive priority in execution. 

The following code will output arbitrary results on each execution. But common sequence patters of priorities being ran could be observed after running multiple times and analyzing the outputs.

```c#
public class ThreadPriorityExample
{
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

    public void RunMultipleThreadsOnDifferentPriorities()
    {
        Thread t0 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });
        Thread t1 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });
        Thread t2 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });
        Thread t3 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });
        Thread t4 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });
        Thread t5 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });
        Thread t6 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });
        Thread t7 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });
        Thread t8 = new Thread(() => { new ThreadWithCallback(Callback).Process(); });

        t0.Priority = ThreadPriority.Lowest;
        t1.Priority = ThreadPriority.BelowNormal;
        t2.Priority = ThreadPriority.Normal;
        t3.Priority = ThreadPriority.AboveNormal;
        t4.Priority = ThreadPriority.Highest;
        t5.Priority = ThreadPriority.Highest;
        t6.Priority = ThreadPriority.Highest;
        t7.Priority = ThreadPriority.Highest;
        t8.Priority = ThreadPriority.Highest;

        t0.Start();
        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
        t5.Start();
        t6.Start();
        t7.Start();
        t8.Start();
    }

    public void Callback(ThreadPriority threadPriority)
    {
        Console.WriteLine($"Callback in {threadPriority} priority. \t\t ThreadId: {Thread.CurrentThread.ManagedThreadId}.");
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

```

## See also

- [Using Threads and Threading](using-threads-and-threading.md)
- [Managed and Unmanaged Threading in Windows](managed-and-unmanaged-threading-in-windows.md)
