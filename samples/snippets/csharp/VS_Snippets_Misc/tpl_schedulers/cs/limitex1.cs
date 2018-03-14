// <Snippet02>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Example
{
   static void Main()
   {
       // Create a scheduler that uses two threads. 
       LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(2);
       List<Task> tasks = new List<Task>();
       
       // Create a TaskFactory and pass it our custom scheduler. 
       TaskFactory factory = new TaskFactory(lcts);
       CancellationTokenSource cts = new CancellationTokenSource();
       
       // Use our factory to run a set of tasks. 
       Object lockObj = new Object();
       int outputItem = 0;
       
       for (int tCtr = 0; tCtr <= 4; tCtr++) {
          int iteration = tCtr;
          Task t = factory.StartNew(() => {
                                       for (int i = 0; i < 1000; i++) {
                                          lock (lockObj) {
                                             Console.Write("{0} in task t-{1} on thread {2}   ", 
                                                           i, iteration, Thread.CurrentThread.ManagedThreadId);
                                             outputItem++;
                                             if (outputItem % 3 == 0)
                                                Console.WriteLine();
                                          }
                                       }                   
                                    }, cts.Token);
          tasks.Add(t);                      
      }
      // Use it to run a second set of tasks.                       
      for (int tCtr = 0; tCtr <= 4; tCtr++) {
         int iteration = tCtr;
         Task t1 = factory.StartNew(() => {
                                       for (int outer = 0; outer <= 10; outer++) {
                                          for (int i = 0x21; i <= 0x7E; i++) {
                                             lock (lockObj) {
                                                Console.Write("'{0}' in task t1-{1} on thread {2}   ", 
                                                              Convert.ToChar(i), iteration, Thread.CurrentThread.ManagedThreadId);
                                                outputItem++;
                                                if (outputItem % 3 == 0)
                                                   Console.WriteLine();
                                             } 
                                          }
                                       }                                           
                                    }, cts.Token);           
         tasks.Add(t1);
      }
      
      // Wait for the tasks to complete before displaying a completion message.
      Task.WaitAll(tasks.ToArray());
      cts.Dispose();
      Console.WriteLine("\n\nSuccessful completion.");
   }
}

// Provides a task scheduler that ensures a maximum concurrency level while 
// running on top of the thread pool.
public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
{
   // Indicates whether the current thread is processing work items.
   [ThreadStatic]
   private static bool _currentThreadIsProcessingItems;

  // The list of tasks to be executed 
   private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks)

   // The maximum concurrency level allowed by this scheduler. 
   private readonly int _maxDegreeOfParallelism;

   // Indicates whether the scheduler is currently processing work items. 
   private int _delegatesQueuedOrRunning = 0;

   // Creates a new instance with the specified degree of parallelism. 
   public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
   {
       if (maxDegreeOfParallelism < 1) throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
       _maxDegreeOfParallelism = maxDegreeOfParallelism;
   }

   // Queues a task to the scheduler. 
   protected sealed override void QueueTask(Task task)
   {
      // Add the task to the list of tasks to be processed.  If there aren't enough 
      // delegates currently queued or running to process tasks, schedule another. 
       lock (_tasks)
       {
           _tasks.AddLast(task);
           if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
           {
               ++_delegatesQueuedOrRunning;
               NotifyThreadPoolOfPendingWork();
           }
       }
   }

   // Inform the ThreadPool that there's work to be executed for this scheduler. 
   private void NotifyThreadPoolOfPendingWork()
   {
       ThreadPool.UnsafeQueueUserWorkItem(_ =>
       {
           // Note that the current thread is now processing work items.
           // This is necessary to enable inlining of tasks into this thread.
           _currentThreadIsProcessingItems = true;
           try
           {
               // Process all available items in the queue.
               while (true)
               {
                   Task item;
                   lock (_tasks)
                   {
                       // When there are no more items to be processed,
                       // note that we're done processing, and get out.
                       if (_tasks.Count == 0)
                       {
                           --_delegatesQueuedOrRunning;
                           break;
                       }

                       // Get the next item from the queue
                       item = _tasks.First.Value;
                       _tasks.RemoveFirst();
                   }

                   // Execute the task we pulled out of the queue
                   base.TryExecuteTask(item);
               }
           }
           // We're done processing items on the current thread
           finally { _currentThreadIsProcessingItems = false; }
       }, null);
   }

   // Attempts to execute the specified task on the current thread. 
   protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
   {
       // If this thread isn't already processing a task, we don't support inlining
       if (!_currentThreadIsProcessingItems) return false;

       // If the task was previously queued, remove it from the queue
       if (taskWasPreviouslyQueued) 
          // Try to run the task. 
          if (TryDequeue(task)) 
            return base.TryExecuteTask(task);
          else
             return false; 
       else 
          return base.TryExecuteTask(task);
   }

   // Attempt to remove a previously scheduled task from the scheduler. 
   protected sealed override bool TryDequeue(Task task)
   {
       lock (_tasks) return _tasks.Remove(task);
   }

   // Gets the maximum concurrency level supported by this scheduler. 
   public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }

   // Gets an enumerable of the tasks currently scheduled on this scheduler. 
   protected sealed override IEnumerable<Task> GetScheduledTasks()
   {
       bool lockTaken = false;
       try
       {
           Monitor.TryEnter(_tasks, ref lockTaken);
           if (lockTaken) return _tasks;
           else throw new NotSupportedException();
       }
       finally
       {
           if (lockTaken) Monitor.Exit(_tasks);
       }
   }
}
// The following is a portion of the output from a single run of the example:
//    'T' in task t1-4 on thread 3   'U' in task t1-4 on thread 3   'V' in task t1-4 on thread 3   
//    'W' in task t1-4 on thread 3   'X' in task t1-4 on thread 3   'Y' in task t1-4 on thread 3   
//    'Z' in task t1-4 on thread 3   '[' in task t1-4 on thread 3   '\' in task t1-4 on thread 3   
//    ']' in task t1-4 on thread 3   '^' in task t1-4 on thread 3   '_' in task t1-4 on thread 3   
//    '`' in task t1-4 on thread 3   'a' in task t1-4 on thread 3   'b' in task t1-4 on thread 3   
//    'c' in task t1-4 on thread 3   'd' in task t1-4 on thread 3   'e' in task t1-4 on thread 3   
//    'f' in task t1-4 on thread 3   'g' in task t1-4 on thread 3   'h' in task t1-4 on thread 3   
//    'i' in task t1-4 on thread 3   'j' in task t1-4 on thread 3   'k' in task t1-4 on thread 3   
//    'l' in task t1-4 on thread 3   'm' in task t1-4 on thread 3   'n' in task t1-4 on thread 3   
//    'o' in task t1-4 on thread 3   'p' in task t1-4 on thread 3   ']' in task t1-2 on thread 4   
//    '^' in task t1-2 on thread 4   '_' in task t1-2 on thread 4   '`' in task t1-2 on thread 4   
//    'a' in task t1-2 on thread 4   'b' in task t1-2 on thread 4   'c' in task t1-2 on thread 4   
//    'd' in task t1-2 on thread 4   'e' in task t1-2 on thread 4   'f' in task t1-2 on thread 4   
//    'g' in task t1-2 on thread 4   'h' in task t1-2 on thread 4   'i' in task t1-2 on thread 4   
//    'j' in task t1-2 on thread 4   'k' in task t1-2 on thread 4   'l' in task t1-2 on thread 4   
//    'm' in task t1-2 on thread 4   'n' in task t1-2 on thread 4   'o' in task t1-2 on thread 4   
//    'p' in task t1-2 on thread 4   'q' in task t1-2 on thread 4   'r' in task t1-2 on thread 4   
//    's' in task t1-2 on thread 4   't' in task t1-2 on thread 4   'u' in task t1-2 on thread 4   
//    'v' in task t1-2 on thread 4   'w' in task t1-2 on thread 4   'x' in task t1-2 on thread 4   
//    'y' in task t1-2 on thread 4   'z' in task t1-2 on thread 4   '{' in task t1-2 on thread 4   
//    '|' in task t1-2 on thread 4   '}' in task t1-2 on thread 4   '~' in task t1-2 on thread 4   
//    'q' in task t1-4 on thread 3   'r' in task t1-4 on thread 3   's' in task t1-4 on thread 3   
//    't' in task t1-4 on thread 3   'u' in task t1-4 on thread 3   'v' in task t1-4 on thread 3   
//    'w' in task t1-4 on thread 3   'x' in task t1-4 on thread 3   'y' in task t1-4 on thread 3   
//    'z' in task t1-4 on thread 3   '{' in task t1-4 on thread 3   '|' in task t1-4 on thread 3  
// </Snippet02>

