//<Snippet1>
//<Snippet2>
// The complete code is located in the ReaderWriterLock class topic.
using System;
using System.Threading;

public class Example
{
   static ReaderWriterLock rwl = new ReaderWriterLock();
   // Define the shared resource protected by the ReaderWriterLock.
   static int resource = 0;
   //</Snippet2>

   const int numThreads = 26;
   static bool running = true;
   static Random rnd = new Random();

   // Statistics.
   static int readerTimeouts = 0;
   static int writerTimeouts = 0;
   static int reads = 0;
   static int writes = 0;

   public static void Main()
   {
      // Start a series of threads to randomly read from and
      // write to the shared resource.
      Thread[] t = new Thread[numThreads];
      for (int i = 0; i < numThreads; i++){
         t[i] = new Thread(new ThreadStart(ThreadProc));
         t[i].Name = new String(Convert.ToChar(i + 65), 1);
         t[i].Start();
         if (i > 10)
            Thread.Sleep(300);
      }

      // Tell the threads to shut down and wait until they all finish.
      running = false;
      for (int i = 0; i < numThreads; i++)
         t[i].Join();

      // Display statistics.
      Console.WriteLine("\n{0} reads, {1} writes, {2} reader time-outs, {3} writer time-outs.",
            reads, writes, readerTimeouts, writerTimeouts);
      Console.Write("Press ENTER to exit... ");
      Console.ReadLine();
   }

   static void ThreadProc()
   {
      // Randomly select a way for the thread to read and write from the shared
      // resource.
      while (running) {
         double action = rnd.NextDouble();
         if (action < .8)
            ReadFromResource(10);
         else if (action < .81)
            ReleaseRestore(50);
         else if (action < .90)
            UpgradeDowngrade(100);
         else
            WriteToResource(100);
      }
   }

   //<Snippet3>
   // Request and release a reader lock, and handle time-outs.
   static void ReadFromResource(int timeOut)
   {
      try {
         rwl.AcquireReaderLock(timeOut);
         try {
            // It is safe for this thread to read from the shared resource.
            Display("reads resource value " + resource);
            Interlocked.Increment(ref reads);
         }
         finally {
            // Ensure that the lock is released.
            rwl.ReleaseReaderLock();
         }
      }
      catch (ApplicationException) {
         // The reader lock request timed out.
         Interlocked.Increment(ref readerTimeouts);
      }
   }
   //</Snippet3>

   //<Snippet4>
   // Request and release the writer lock, and handle time-outs.
   static void WriteToResource(int timeOut)
   {
      try {
         rwl.AcquireWriterLock(timeOut);
         try {
            // It's safe for this thread to access from the shared resource.
            resource = rnd.Next(500);
            Display("writes resource value " + resource);
            Interlocked.Increment(ref writes);
         }
         finally {
            // Ensure that the lock is released.
            rwl.ReleaseWriterLock();
         }
      }
      catch (ApplicationException) {
         // The writer lock request timed out.
         Interlocked.Increment(ref writerTimeouts);
      }
   }
   //</Snippet4>

   //<Snippet5>
   // Requests a reader lock, upgrades the reader lock to the writer
   // lock, and downgrades it to a reader lock again.
   static void UpgradeDowngrade(int timeOut)
   {
      try {
         rwl.AcquireReaderLock(timeOut);
         try {
            // It's safe for this thread to read from the shared resource.
            Display("reads resource value " + resource);
            Interlocked.Increment(ref reads);

            // To write to the resource, either release the reader lock and
            // request the writer lock, or upgrade the reader lock. Upgrading
            // the reader lock puts the thread in the write queue, behind any
            // other threads that might be waiting for the writer lock.
            try {
               LockCookie lc = rwl.UpgradeToWriterLock(timeOut);
               try {
                  // It's safe for this thread to read or write from the shared resource.
                  resource = rnd.Next(500);
                  Display("writes resource value " + resource);
                  Interlocked.Increment(ref writes);
               }
               finally {
                  // Ensure that the lock is released.
                  rwl.DowngradeFromWriterLock(ref lc);
               }
            }
            catch (ApplicationException) {
               // The upgrade request timed out.
               Interlocked.Increment(ref writerTimeouts);
            }

            // If the lock was downgraded, it's still safe to read from the resource.
            Display("reads resource value " + resource);
            Interlocked.Increment(ref reads);
         }
         finally {
            // Ensure that the lock is released.
            rwl.ReleaseReaderLock();
         }
      }
      catch (ApplicationException) {
         // The reader lock request timed out.
         Interlocked.Increment(ref readerTimeouts);
      }
   }
   //</Snippet5>

   //<Snippet6>
   // Release all locks and later restores the lock state.
   // Uses sequence numbers to determine whether another thread has
   // obtained a writer lock since this thread last accessed the resource.
   static void ReleaseRestore(int timeOut)
   {
      int lastWriter;

      try {
         rwl.AcquireReaderLock(timeOut);
         try {
            // It's safe for this thread to read from the shared resource,
            // so read and cache the resource value.
            int resourceValue = resource;     // Cache the resource value.
            Display("reads resource value " + resourceValue);
            Interlocked.Increment(ref reads);

            // Save the current writer sequence number.
            lastWriter = rwl.WriterSeqNum;

            // Release the lock and save a cookie so the lock can be restored later.
            LockCookie lc = rwl.ReleaseLock();

            // Wait for a random interval and then restore the previous state of the lock.
            Thread.Sleep(rnd.Next(250));
            rwl.RestoreLock(ref lc);

            // Check whether other threads obtained the writer lock in the interval.
            // If not, then the cached value of the resource is still valid.
            if (rwl.AnyWritersSince(lastWriter)) {
               resourceValue = resource;
               Interlocked.Increment(ref reads);
               Display("resource has changed " + resourceValue);
            }
            else {
               Display("resource has not changed " + resourceValue);
            }
         }
         finally {
            // Ensure that the lock is released.
            rwl.ReleaseReaderLock();
         }
      }
      catch (ApplicationException) {
         // The reader lock request timed out.
         Interlocked.Increment(ref readerTimeouts);
      }
   }
   //</Snippet6>

   // Helper method briefly displays the most recent thread action.
   static void Display(string msg)
   {
      Console.Write("Thread {0} {1}.       \r", Thread.CurrentThread.Name, msg);
   }
//<Snippet7>
}
//</Snippet7>
//</Snippet1>

