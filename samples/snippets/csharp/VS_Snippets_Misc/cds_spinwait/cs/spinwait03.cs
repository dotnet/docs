// <Snippet03>
#define LOGGING

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Latch
{
   private object latchLock = new object();
   // 0 = unset, 1 = set.
   private int m_state = 0;
   private volatile int totalKernelWaits = 0;

   // Block threads waiting for ManualResetEvent.
   private ManualResetEvent m_ev = new ManualResetEvent(false);
#if LOGGING
   // For fast logging with minimal impact on latch behavior.
   // Spin counts greater than 20 might be encountered depending on machine config.
   private long[] spinCountLog = new long[20];

   public void DisplayLog()
   {
      for (int i = 0; i < spinCountLog.Length; i++)
      {
          Console.WriteLine($"Wait succeeded with spin count of {i} on {spinCountLog[i]:N0} attempts");
      }
      Console.WriteLine($"Wait used the kernel event on {totalKernelWaits:N0} attempts.");
      Console.WriteLine("Logging complete");
   }
#endif

   public void Set()
   {
      lock(latchLock) {
         m_state = 1;
         m_ev.Set();
      }
   }

   public void Wait()
   {
      Trace.WriteLine("Wait timeout infinite");
      Wait(Timeout.Infinite);
   }

   public bool Wait(int timeout)
   {
      SpinWait spinner = new SpinWait();
      Stopwatch watch;

      while (m_state == 0)
      {
          // Lazily allocate and start stopwatch to track timeout.
          watch = Stopwatch.StartNew();

          // Spin only until the SpinWait is ready
          // to initiate its own context switch.
          if (!spinner.NextSpinWillYield)
          {
              spinner.SpinOnce();
          }
          // Rather than let SpinWait do a context switch now,
          //  we initiate the kernel Wait operation, because
          // we plan on doing this anyway.
          else
          {
              Interlocked.Increment(ref totalKernelWaits);
              // Account for elapsed time.
              long realTimeout = timeout - watch.ElapsedMilliseconds;

              // Do the wait.
              if (realTimeout <= 0 || !m_ev.WaitOne((int)realTimeout))
              {
                  Trace.WriteLine("wait timed out.");
                  return false;
              }
          }
      }

#if LOGGING
      Interlocked.Increment(ref spinCountLog[spinner.Count]);
#endif
      // Take the latch.
      Interlocked.Exchange(ref m_state, 0);

      return true;
   }
}

class Example
{
   static Latch latch = new Latch();
   static int count = 2;
   static CancellationTokenSource cts = new CancellationTokenSource();

   static void TestMethod()
   {
      while (!cts.IsCancellationRequested)
      {
         // Obtain the latch.
         if (latch.Wait(50))
         {
            // Do the work. Here we vary the workload a slight amount
            // to help cause varying spin counts in latch.
            double d = 0;
            if (count % 2 != 0) {
               d = Math.Sqrt(count);
            }
            Interlocked.Increment(ref count);

            // Release the latch.
            latch.Set();
         }
      }
   }

   static void Main()
   {
      // Demonstrate latch with a simple scenario: multiple
      // threads updating a shared integer. Both operations
      // are relatively fast, which enables the latch to
      // demonstrate successful waits by spinning only.
      latch.Set();

      // UI thread. Press 'c' to cancel the loop.
      Task.Factory.StartNew(() =>
      {
         Console.WriteLine("Press 'c' to cancel.");
         if (Console.ReadKey(true).KeyChar == 'c') {
            cts.Cancel();
         }
      });

      Parallel.Invoke( () => TestMethod(),
                       () => TestMethod(),
                       () => TestMethod() );

#if LOGGING
      latch.DisplayLog();
      if (cts != null) cts.Dispose();
#endif
   }
}
// </Snippet03>
