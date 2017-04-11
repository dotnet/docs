//<snippet1>
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class CQ_EnqueueDequeuePeek
{
   // Demonstrates:
   // ConcurrentQueue<T>.Enqueue()
   // ConcurrentQueue<T>.TryPeek()
   // ConcurrentQueue<T>.TryDequeue()
   static void Main ()
   {
      // Construct a ConcurrentQueue.
      ConcurrentQueue<int> cq = new ConcurrentQueue<int>();

      // Populate the queue.
      for (int i = 0; i < 10000; i++) cq.Enqueue(i);

      // Peek at the first element.
      int result;
      if (!cq.TryPeek(out result))
      {
         Console.WriteLine("CQ: TryPeek failed when it should have succeeded");
      }
      else if (result != 0)
      {
         Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result);
      }

      int outerSum = 0;
      // An action to consume the ConcurrentQueue.
      Action action = () =>
      {                
         int localSum = 0;
         int localValue;
         while (cq.TryDequeue(out localValue)) localSum += localValue;
         Interlocked.Add(ref outerSum, localSum);
      };

      // Start 4 concurrent consuming actions.
      Parallel.Invoke(action, action, action, action);

      Console.WriteLine("outerSum = {0}, should be 49995000", outerSum);
   }
}
//</snippet1>