//<snippet01>
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpinLockDemo
{
    // C#
    public class SpinLockTest
    {
        // Specify true to enable thread tracking. This will cause
        // exception to be thrown when the first thread attempts to reenter the lock.
        // Specify false to cause deadlock due to coding error below.
        private static SpinLock _spinLock = new SpinLock(true);

        static void Main()
        {
            Parallel.Invoke(
                () => DoWork(),
                () => DoWork(),
                () => DoWork(),
                () => DoWork()
                );

            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }

        public static void DoWork()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {

                bool lockTaken = false;

                try
                {
                    _spinLock.Enter(ref lockTaken);

                    // do work here protected by the lock
                    Thread.SpinWait(50000);
                    sb.Append(Thread.CurrentThread.ManagedThreadId);
                    sb.Append(" Entered-");
                }
                catch (LockRecursionException ex)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} attempted to reenter the lock");
                    throw;
                }
                finally
                {
                    // INTENTIONAL CODING ERROR TO DEMONSTRATE THREAD TRACKING!
                    // UNCOMMENT THE LINES FOR CORRECT SPINLOCK BEHAVIOR
                    // Commenting out these lines causes the same thread
                    // to attempt to reenter the lock. If the SpinLock was
                    // created with thread tracking enabled, the exception
                    // is thrown. Otherwise the spinlock deadlocks.
                    if (lockTaken)
                    {
                       // _spinLock.Exit(false);
                       // sb.Append("Exited ");
                    }
                }

                // Output for diagnostic display.
                if(i % 4 != 0)
                    Console.Write(sb.ToString());
                else
                    Console.WriteLine(sb.ToString());
                sb.Clear();
            }
        }
    }
}
//</snippet01>

 //<snippet02>

    class SpinLockDemo2
    {
        const int N = 100000;
        static Queue<Data> _queue = new Queue<Data>();
        static object _lock = new Object();
        static SpinLock _spinlock = new SpinLock();

        class Data
        {
            public string Name { get; set; }
            public double Number { get; set; }
        }
        static void Main(string[] args)
        {

            // First use a standard lock for comparison purposes.
            UseLock();
            _queue.Clear();
            UseSpinLock();

            Console.WriteLine("Press a key");
            Console.ReadKey();
        }

        private static void UpdateWithSpinLock(Data d, int i)
        {
            bool lockTaken = false;
            try
            {
                _spinlock.Enter(ref lockTaken);
                _queue.Enqueue( d );
            }
            finally
            {
                if (lockTaken) _spinlock.Exit(false);
            }
        }

        private static void UseSpinLock()
        {

              Stopwatch sw = Stopwatch.StartNew();

              Parallel.Invoke(
                      () => {
                          for (int i = 0; i < N; i++)
                          {
                              UpdateWithSpinLock(new Data() { Name = i.ToString(), Number = i }, i);
                          }
                      },
                      () => {
                          for (int i = 0; i < N; i++)
                          {
                              UpdateWithSpinLock(new Data() { Name = i.ToString(), Number = i }, i);
                          }
                      }
                  );
              sw.Stop();
              Console.WriteLine($"elapsed ms with spinlock: {sw.ElapsedMilliseconds}");
        }

        static void UpdateWithLock(Data d, int i)
        {
            lock (_lock)
            {
                _queue.Enqueue(d);
            }
        }

        private static void UseLock()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Parallel.Invoke(
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithLock(new Data() { Name = i.ToString(), Number = i }, i);
                        }
                    },
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithLock(new Data() { Name = i.ToString(), Number = i }, i);
                        }
                    }
                );
            sw.Stop();
            Console.WriteLine($"elapsed ms with lock: {sw.ElapsedMilliseconds}");
        }
    }
    //</snippet02>

    // In snippet02, the problem is actually more suited to data parallelism,
    // but that didn't show much perf benefit for spinlock.
    class ExtraForSnippet4
    {
        static void ParallelForWithLock()
        {
            //Parallel.For(0, _table.Length, (i) =>
            //{
            //    UpdateWithLock(new Data() { Name = i.ToString(), Number = i }, i);
            //}
            // );
            //sw.Stop();
            // Console.WriteLine($"elapsed ms with lock: {sw.ElapsedMilliseconds}");
        }

        static void ParallelForwithSpinLock()
        {

            //Parallel.For(0, _table.Length, (i) =>
            //    {
            //        UpdateWithSpinLock(new Data() { Name = i.ToString(), Number = i }, i);
            //    }
            //  );

          //  Task.Factory.ContinueWhenAll(
        }
    }
