﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace TPL_Exceptions
{
    class ExceptionDemoCS
    {
        class MyCustomException : Exception
        {
            public MyCustomException(string s) : base(s) { }
        }

        static void ThrowDemo()
        {
            var task1 = Task.Factory.StartNew(() =>
            {
                throw new MyCustomException("I'm bad, but not too bad!");
            });

            try
            {
                task1.Wait();
            }
            catch (AggregateException ae)
            {
                // Assume we know what's going on with this particular exception.
                // Rethrow anything else. AggregateException.Handle provides
                // another way to express this. See later example.
                //<snippet5>
                foreach (var e in ae.InnerExceptions)
                {
                    if (e is MyCustomException)
                    {
                        Console.WriteLine(e.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
                //</snippet5>
            }
        }

        static void CancelDemo()
        {
            bool someCondition = true;
            //<snippet4>
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var task1 = Task.Factory.StartNew(() =>
            {
                CancellationToken ct = token;
                while (someCondition)
                {
                    // Do some work...
                    Thread.SpinWait(50000);
                    ct.ThrowIfCancellationRequested();
                }
            },
            token);

            // No waiting required.
            tokenSource.Dispose();
            //</snippet4>
        }
    }

    //<snippet08>
    class ExceptionDemo2
    {
        static void Main(string[] args)
        {
            // Create some random data to process in parallel.
            // There is a good probability this data will cause some exceptions to be thrown.
            byte[] data = new byte[5000];
            Random r = new Random();
            r.NextBytes(data);

            try
            {
                ProcessDataInParallel(data);
            }
            catch (AggregateException ae)
            {
                var ignoredExceptions = new List<Exception>();
                // This is where you can choose which exceptions to handle.
                foreach (var ex in ae.Flatten().InnerExceptions)
                {
                    if (ex is ArgumentException)
                        Console.WriteLine(ex.Message);
                    else
                        ignoredExceptions.Add(ex);
                }
                if (ignoredExceptions.Count > 0) throw new AggregateException(ignoredExceptions);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ProcessDataInParallel(byte[] data)
        {
            // Use ConcurrentQueue to enable safe enqueueing from multiple threads.
            var exceptions = new ConcurrentQueue<Exception>();

            // Execute the complete loop and capture all exceptions.
            Parallel.ForEach(data, d =>
            {
                try
                {
                    // Cause a few exceptions, but not too many.
                    if (d < 3)
                        throw new ArgumentException($"Value is {d}. Value must be greater than or equal to 3.");
                    else
                        Console.Write(d + " ");
                }
                // Store the exception and continue with the loop.
                catch (Exception e)
                {
                    exceptions.Enqueue(e);
                }
            });
            Console.WriteLine();

            // Throw the exceptions here after the loop completes.
            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
    }
    //</snippet08>
}