#define LOGGING

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CDS_Spinwait
{
    class Latch
    {
        // 0 = unset, 1 = set
        private volatile int m_state = 0;

        private ManualResetEvent m_ev = new ManualResetEvent(false);

#if LOGGING
        // For fast logging with minimal impact on latch behavior.
        // Spin counts greater than 20 might be encountered depending on machine config.
        private int[] spinCountLog = new int[20];
        private volatile int totalKernelWaits = 0;

        public void PrintLog()
        {

            for (int i = 0; i < spinCountLog.Length; i++)
            {
                Console.WriteLine($"Wait succeeded with spin count of {i} on {spinCountLog[i]} attempts");
            }
            Console.WriteLine($"Wait used the kernel event on {totalKernelWaits} attempts.");
            Console.WriteLine("Logging complete");
        }
#endif

        public void Set()
        {
            // Trace.WriteLine("Set");
            m_state = 1;
            m_ev.Set();
        }

        public void Wait()
        {
            Trace.WriteLine("Wait timeout infinite");
            Wait(Timeout.Infinite);
        }

        public bool Wait(int timeout)
        {
            // Allocated on the stack.
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
                    totalKernelWaits++;
                    // Account for elapsed time.
                    int realTimeout = timeout - (int)watch.ElapsedMilliseconds;

                    // Do the wait.
                    if (realTimeout <= 0 || !m_ev.WaitOne(realTimeout))
                    {
                        Trace.WriteLine("wait timed out.");
                        return false;
                    }
                }
            }

            // Take the latch.
            m_state = 0;
            //   totalWaits++;

#if LOGGING
            spinCountLog[spinner.Count]++;
#endif

            return true;
        }
    }

    class Program
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
                    if (count % 2 != 0)
                    {
                        d = Math.Sqrt(count);
                    }
                    count++;

                    // Release the latch.
                    latch.Set();
                }
            }
        }
        static void Main(string[] args)
        {
            // Demonstrate latch with a simple scenario:
            // two threads updating a shared integer and
            // accessing a shared StringBuilder. Both operations
            // are relatively fast, which enables the latch to
            // demonstrate successful waits by spinning only.

            latch.Set();

            // UI thread. Press 'c' to cancel the loop.
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Press 'c' to cancel.");
                if (Console.ReadKey().KeyChar == 'c')
                {
                    cts.Cancel();
                }
            });

            Parallel.Invoke(

                () => TestMethod(),
                () => TestMethod(),
                () => TestMethod()
                );

#if LOGGING
            latch.PrintLog();
#endif
            Console.WriteLine("\r\nPress the Enter Key.");
            Console.ReadLine();
            cts.Dispose();
        }
    }
}

namespace SpinWait2
{

    //<snippet05>
    public class LockFreeStack<T>
    {
        private volatile Node m_head;

        private class Node { public Node Next; public T Value; }

        public void Push(T item)
        {
            var spin = new SpinWait();
            Node node = new Node { Value = item }, head;
            while (true)
            {
                head = m_head;
                node.Next = head;
                if (Interlocked.CompareExchange(ref m_head, node, head) == head) break;
                spin.SpinOnce();
            }
        }

        public bool TryPop(out T result)
        {
            result = default(T);
            var spin = new SpinWait();

            Node head;
            while (true)
            {
                head = m_head;
                if (head == null) return false;
                if (Interlocked.CompareExchange(ref m_head, head.Next, head) == head)
                {
                    result = head.Value;
                    return true;
                }
                spin.SpinOnce();
            }
        }
    }
    //</snippet05>

    //NOT SURE IF THE REST ARE USED. NOT FOUND IN FX_ADVANCE.HXS AND NO VB VERSIONS SEEM TO EXIST..11-21-09
    //<snippet6>
    class SpinwaitDemo2
    {
        volatile static bool _signalled;
        static byte[] data = new byte[4];
        static string[] files;

        // We start a new timer on each loop iteration.
        static Stopwatch watch;

        static void Main()
        {
            int spinCount = 10;
            while (true)
            {
                SpinThenWait(spinCount);

                Console.WriteLine("Press 'q' to quit or else enter a spin count.");
                string s = Console.ReadLine();
                if (s == "q" || s == "Q")
                {
                    return;
                }
                else
                {
                    try
                    {
                        spinCount = Convert.ToInt32(s);
                    }
                    // Catch any kind of bad input.
                    catch (Exception e)
                    {
                        Console.WriteLine("Please enter a valid number or q to quit.");
                    }
                }
            }
        }

        private static void SpinThenWait(int count)
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem((WaitCallback)GetFiles, mre);

            _signalled = false;
            if (SpinForResult(count) == true)
            {
                ReadFiles(files);
                Console.WriteLine($"Spinning paid off. returned after {watch.ElapsedTicks} ticks");
            }

            else
            {
                mre.WaitOne();
                ReadFiles(files);
                Console.WriteLine($"Spinning timed out. Now waiting on event: returned after {watch.ElapsedTicks} ticks");
            }
        }

        private static bool SpinForResult(int spinCount)
        {
            bool result = false;
            SpinWait spinner = new SpinWait();

            // For diagnostic output.
            watch = Stopwatch.StartNew();

            while (_signalled == false && spinner.Count < spinCount)
            {
                spinner.SpinOnce();
            }

            if (_signalled == true)
                result = true;

            return result;
        }

        static void GetFiles(object obj)
        {
            ManualResetEvent ev = (ManualResetEvent)obj;
            files = System.IO.Directory.GetFiles(@"C:\users\public\documents\", "*.*");
            _signalled = true;
            ev.Set();
        }
        static void ReadFiles(string[] files)
        {
            // Do something with file data
            // ...
            Console.WriteLine("Done reading files.");
        }
    }
    //</snippet6>

    //<snippet7>
    class SpinwaitDemo3
    {
        volatile static bool _signalled;
        const int loopCount = 1000000;

        // Set up matrix sizes.
        static int colCount = 40;
        static int rowCount = 40;
        static int colCount2 = 60;
        static double[,] result;

        // For diagnostic output.
        static Stopwatch watch;

        static void Main()
        {
            UseManualResetEvent();
            UseSpinWait();

            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }

        private static void UseManualResetEvent()
        {
            // Use ManualResetEventSlim for better performance than ManualResetEvent.
            ManualResetEventSlim mre = new ManualResetEventSlim(false);
            ThreadPool.QueueUserWorkItem(new WaitCallback(GenerateDataForResetEvent), mre);
            watch = Stopwatch.StartNew();

            for (int i = 0; i < loopCount; i++)
            {
                mre.Wait();
                // Now do something with result array here...
            }
            long ticks = watch.ElapsedTicks;
            Console.WriteLine($"Waiting on {loopCount} complete. Elapsed ticks = {ticks}");
        }

        private static void UseSpinWait()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GenerateDataForSpinWait), null);
            watch = Stopwatch.StartNew();

            for (int i = 0; i < loopCount; i++)
            {
                SpinWait.SpinUntil(() => _signalled == true);

                // Now do something with result array here...
            }

            long ticks = watch.ElapsedTicks;
            Console.WriteLine($"Spinning on {loopCount} complete. Elapsed ticks = {ticks}");
        }

        static void GenerateDataForResetEvent(object state)
        {
            ManualResetEventSlim ev = (ManualResetEventSlim)state;

            for (int i = 0; i < loopCount; i++)
            {
                double[,] m1 = InitializeMatrix(rowCount, colCount);
                double[,] m2 = InitializeMatrix(colCount, colCount2);
                result = new double[rowCount, colCount2];
                MultiplyMatricesParallel(colCount, colCount2, m1, m2, result);
                ev.Set();
            }
        }

        static void GenerateDataForSpinWait(object state)
        {
            for (int i = 0; i < loopCount; i++)
            {
                double[,] m1 = InitializeMatrix(rowCount, colCount);
                double[,] m2 = InitializeMatrix(colCount, colCount2);
                result = new double[rowCount, colCount2];
                MultiplyMatricesParallel(colCount, colCount2, m1, m2, result);
                _signalled = true;
            }
        }

        #region Helper_Methods
        static double[,] InitializeMatrix(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = r.Next(100);
                }
            }
            return matrix;
        }

        static void MultiplyMatricesParallel(int matACols, int matBCols, double[,] matA, double[,] matB, double[,] result)
        {
            int matARows = matA.Length / matACols;

            // A basic matrix multiplication.
            // Parallelize the outer loop to partition the source array by rows.
            Parallel.For(0, matARows, i =>
            {
                for (int j = 0; j < matBCols; j++)
                {
                    for (int k = 0; k < matACols; k++)
                    {
                        result[i, j] += matA[i, k] * matB[k, j];
                    }
                }
            }
            ); // Parallel.For
        }
        #endregion
    }
    //</snippet7>
}
