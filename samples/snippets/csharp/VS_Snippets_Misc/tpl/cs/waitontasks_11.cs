//<snippet11>

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            // Wait on a single task with no timeout specified.
            Task taskA = Task.Factory.StartNew(() => DoSomeWork(10000000));
            taskA.Wait();
            Console.WriteLine("taskA has completed.");

            // Wait on a single task with a timeout specified.
            Task taskB = Task.Factory.StartNew(() => DoSomeWork(10000000));
            taskB.Wait(100); //Wait for 100 ms.

            if (taskB.IsCompleted)
                Console.WriteLine("taskB has completed.");
            else
                Console.WriteLine("Timed out before taskB completed.");

            // Wait for all tasks to complete.
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => DoSomeWork(10000000));
            }
            Task.WaitAll(tasks);

            // Wait for first task to complete.
            Task<double>[] tasks2 = new Task<double>[3];

            // Try three different approaches to the problem. Take the first one.
            tasks2[0] = Task<double>.Factory.StartNew(() => TrySolution1());
            tasks2[1] = Task<double>.Factory.StartNew(() => TrySolution2());
            tasks2[2] = Task<double>.Factory.StartNew(() => TrySolution3());

            int index = Task.WaitAny(tasks2);
            double d = tasks2[index].Result;
            Console.WriteLine("task[{0}] completed first with result of {1}.", index, d);

            Console.ReadKey();
        }

        static void DoSomeWork(int val)
        {
            // Pretend to do something.
            Thread.SpinWait(val);
        }

        static double TrySolution1()
        {
            int i = rand.Next(1000000);
            // Simulate work by spinning
            Thread.SpinWait(i);
            return DateTime.Now.Millisecond;
        }
        static double TrySolution2()
        {
            int i = rand.Next(1000000);
            // Simulate work by spinning
            Thread.SpinWait(i);
            return DateTime.Now.Millisecond;
        }
        static double TrySolution3()
        {
            int i = rand.Next(1000000);
            // Simulate work by spinning
            Thread.SpinWait(i);
            Thread.SpinWait(1000000);
            return DateTime.Now.Millisecond;
        }
    }

    //</snippet11>
