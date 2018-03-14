//<snippet1>
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

class SafeQueue<T>
{
   //<Snippet3>
   //<Snippet2>
   // A queue that is protected by Monitor.
   private Queue<T> m_inputQueue = new Queue<T>();
   //</Snippet2>

   // Lock the queue and add an element.
   public void Enqueue(T qValue)
   {
      // Request the lock, and block until it is obtained.
      Monitor.Enter(m_inputQueue);
      try
      {
         // When the lock is obtained, add an element.
         m_inputQueue.Enqueue(qValue);
      }
      finally
      {
         // Ensure that the lock is released.
         Monitor.Exit(m_inputQueue);
      }
   }
   //</Snippet3>

   //<Snippet4>
   // Try to add an element to the queue: Add the element to the queue 
   // only if the lock is immediately available.
   public bool TryEnqueue(T qValue)
   {
      // Request the lock.
      if (Monitor.TryEnter(m_inputQueue))
      {
         try
         {
            m_inputQueue.Enqueue(qValue);
         }
         finally
         {
            // Ensure that the lock is released.
            Monitor.Exit(m_inputQueue);
         }
         return true;
      }
      else
      {
         return false;
      }
   }
   //</Snippet4>

   //<Snippet5>
   // Try to add an element to the queue: Add the element to the queue 
   // only if the lock becomes available during the specified time
   // interval.
   public bool TryEnqueue(T qValue, int waitTime)
   {
      // Request the lock.
      if (Monitor.TryEnter(m_inputQueue, waitTime))
      {
         try
         {
            m_inputQueue.Enqueue(qValue);
         }
         finally
         {
            // Ensure that the lock is released.
            Monitor.Exit(m_inputQueue);
         }
         return true;
      }
      else
      {
         return false;
      }
   }
   //</Snippet5>

   // Lock the queue and dequeue an element.
   public T Dequeue()
   {
      T retval;

      // Request the lock, and block until it is obtained.
      Monitor.Enter(m_inputQueue);
      try
      {
         // When the lock is obtained, dequeue an element.
         retval = m_inputQueue.Dequeue();
      }
      finally
      {
         // Ensure that the lock is released.
         Monitor.Exit(m_inputQueue);
      }

      return retval;
   }

   // Delete all elements that equal the given object.
   public int Remove(T qValue)
   {
      int removedCt = 0;

      // Wait until the lock is available and lock the queue.
      Monitor.Enter(m_inputQueue);
      try
      {
         int counter = m_inputQueue.Count;
         while (counter > 0)
            // Check each element.
         {
            T elem = m_inputQueue.Dequeue();
            if (!elem.Equals(qValue))
            {
               m_inputQueue.Enqueue(elem);
            }
            else
            {
               // Keep a count of items removed.
               removedCt += 1;
            }
            counter = counter - 1;
         }
      }
      finally
      {
         // Ensure that the lock is released.
         Monitor.Exit(m_inputQueue);
      }

      return removedCt;
   }

   // Print all queue elements.
   public string PrintAllElements()
   {
      StringBuilder output = new StringBuilder();

      // Lock the queue.
      Monitor.Enter(m_inputQueue);
      try
      {
         foreach( T elem in m_inputQueue )
         {
            // Print the next element.
            output.AppendLine(elem.ToString());
         }
      }
      finally
      {
         // Ensure that the lock is released.
         Monitor.Exit(m_inputQueue);
      }

      return output.ToString();
   }
}

public class Example
{
   private static SafeQueue<int> q = new SafeQueue<int>();
   private static int threadsRunning = 0;
   private static int[][] results = new int[3][];

   static void Main()
   {
      Console.WriteLine("Working...");

      for(int i = 0; i < 3; i++)
      {
         Thread t = new Thread(ThreadProc);
         t.Start(i);
         Interlocked.Increment(ref threadsRunning);
      }
   }

   private static void ThreadProc(object state)
   {
      DateTime finish = DateTime.Now.AddSeconds(10);
      Random rand = new Random();
      int[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
      int threadNum = (int) state;

      while (DateTime.Now < finish)

      {
         int what = rand.Next(250);
         int how = rand.Next(100);

         if (how < 16)
         {
            q.Enqueue(what);
            result[(int)ThreadResultIndex.EnqueueCt] += 1;
         }
         else if (how < 32)
         {
            if (q.TryEnqueue(what))
            {
               result[(int)ThreadResultIndex.TryEnqueueSucceedCt] += 1;
            }
            else
            {
               result[(int)ThreadResultIndex.TryEnqueueFailCt] += 1;
            }
         }
         else if (how < 48)
         {
            // Even a very small wait significantly increases the success 
            // rate of the conditional enqueue operation.
            if (q.TryEnqueue(what, 10))
            {
               result[(int)ThreadResultIndex.TryEnqueueWaitSucceedCt] += 1;
            }
            else
            {
               result[(int)ThreadResultIndex.TryEnqueueWaitFailCt] += 1;
            }
         }
         else if (how < 96)
         {
            result[(int)ThreadResultIndex.DequeueCt] += 1;
            try
            {
               q.Dequeue();
            }
            catch
            {
               result[(int)ThreadResultIndex.DequeueExCt] += 1;
            }
         }
         else
         {
            result[(int)ThreadResultIndex.RemoveCt] += 1;
            result[(int)ThreadResultIndex.RemovedCt] += q.Remove(what);
         }         
      }

      results[threadNum] = result;

      if (0 == Interlocked.Decrement(ref threadsRunning))      
      {
         StringBuilder sb = new StringBuilder(
            "                               Thread 1 Thread 2 Thread 3    Total\n");

         for(int row = 0; row < 9; row++)
         {
            int total = 0;
            sb.Append(titles[row]);

            for(int col = 0; col < 3; col++)
            {
               sb.Append(String.Format("{0,9}", results[col][row]));
               total += results[col][row];
            }

            sb.AppendLine(String.Format("{0,9}", total));
         }

         Console.WriteLine(sb.ToString());
      }
   }

   private static string[] titles = {
      "Enqueue                       ", 
      "TryEnqueue succeeded          ", 
      "TryEnqueue failed             ", 
      "TryEnqueue(T, wait) succeeded ", 
      "TryEnqueue(T, wait) failed    ", 
      "Dequeue attempts              ", 
      "Dequeue exceptions            ", 
      "Remove operations             ", 
      "Queue elements removed        "};

   private enum ThreadResultIndex
   {
      EnqueueCt, 
      TryEnqueueSucceedCt, 
      TryEnqueueFailCt, 
      TryEnqueueWaitSucceedCt, 
      TryEnqueueWaitFailCt, 
      DequeueCt, 
      DequeueExCt, 
      RemoveCt, 
      RemovedCt
   };
}

/* This example produces output similar to the following:

Working...
                               Thread 1 Thread 2 Thread 3    Total
Enqueue                          277382   515209   308464  1101055
TryEnqueue succeeded             276873   514621   308099  1099593
TryEnqueue failed                   109      181      134      424
TryEnqueue(T, wait) succeeded    276913   514434   307607  1098954
TryEnqueue(T, wait) failed            2        0        0        2
Dequeue attempts                 830980  1544081   924164  3299225
Dequeue exceptions                12102    21589    13539    47230
Remove operations                 69550   129479    77351   276380
Queue elements removed            11957    22572    13043    47572
 */
//</snippet1>

