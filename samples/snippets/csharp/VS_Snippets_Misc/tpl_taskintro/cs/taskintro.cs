using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleTaskCreation();
            ChildTaskSnippets();
            TaskDemo2();
            Console.ReadKey();
        }

        static void SimpleTaskCreation()
        {
            //<snippet01>
            // Create a task and supply a user delegate by using a lambda expression.
            var taskA = new Task(() => Console.WriteLine("Hello from taskA."));

            // Start the task.
            taskA.Start();

            // Output a message from the calling thread.
            Console.WriteLine("Hello from the calling thread.");
            // Message from taskA should follow.

            /* Output:
             * Hello from the calling thread.
             * Hello from taskA.
             */

            //</snippet01>
        }

        static void SimpleStartNew()
        {
            //<snippet09>
            // Create and start the task in one operation.
            var taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from taskA."));

            // Output a message from the calling thread.
            Console.WriteLine("Hello from the calling thread.");
            //</snippet09>
        }

        //<snippet02>

       class MyCustomData
       {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
        }

    static void TaskDemo2()
    {
        // Create the task object by using an Action(Of Object) to pass in custom data
        // in the Task constructor. This is useful when you need to capture outer variables
        // from within a loop. As an experiment, try modifying this code to
        // capture i directly in the lambda, and compare results.
        Task[] taskArray = new Task[10];

        for(int i = 0; i < taskArray.Length; i++)
        {
            taskArray[i] = new Task((obj) =>
                {
                                        MyCustomData mydata = (MyCustomData) obj;
                                        mydata.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                                        Console.WriteLine($"Hello from Task #{mydata.Name} created at {mydata.CreationTime} running on thread #{mydata.ThreadNum}.");
                },
            new MyCustomData () {Name = i, CreationTime = DateTime.Now.Ticks}
            );
            taskArray[i].Start();
        }
    }

        //</snippet02>

        static void TaskDemo2A()
        {
            Task.Factory.StartNew(state =>
            {
                dynamic data = state;
                Console.WriteLine(data.Name);
                Console.WriteLine(data.Date);
            }, new { Name = "taskB", Date = DateTime.Today });
        }

        static void TaskDemo3()
        {
            //<snippet03>
            var task3 = new Task(() => MyLongRunningMethod(),
                                TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
            task3.Start();
            //</snippet03>
        }

        // dummy methods
        static void MyLongRunningMethod() { }
        static double DoComputation1() { return 1.0; }
        static double DoComputation2() { return 1.0; }
        static double DoComputation3() { return 1.0; }
        static byte[] GetFileData() { return new byte[100]; }
        static double[] Analyze(byte[] input) { return new double[100]; }
        static string Summarize(double[] d) { return "looks good"; }
        static void MethodA() { }
        static void MethodB() { }
        static void MethodC() { }

        static void MoreSimple()
        {

            //<snippet04>
            Task<double>[] taskArray = new Task<double>[]
               {
                   Task<double>.Factory.StartNew(() => DoComputation1()),

                   // May be written more conveniently like this:
                   Task.Factory.StartNew(() => DoComputation2()),
                   Task.Factory.StartNew(() => DoComputation3())
               };

            double[] results = new double[taskArray.Length];
            for (int i = 0; i < taskArray.Length; i++)
                results[i] = taskArray[i].Result;
            //</snippet04>

            //<snippet05>
            Task<byte[]> getData = new Task<byte[]>(() => GetFileData());
            Task<double[]> analyzeData = getData.ContinueWith(x => Analyze(x.Result));
            Task<string> reportData = analyzeData.ContinueWith(y => Summarize(y.Result));

            getData.Start();

            //or...
            Task<string> reportData2 = Task.Factory.StartNew(() => GetFileData())
                                        .ContinueWith((x) => Analyze(x.Result))
                                        .ContinueWith((y) => Summarize(y.Result));

            System.IO.File.WriteAllText(@"C:\reportFolder\report.txt", reportData.Result);

            //</snippet05>

            //<snippet06>
            Task[] tasks = new Task[3]
            {
                Task.Factory.StartNew(() => MethodA()),
                Task.Factory.StartNew(() => MethodB()),
                Task.Factory.StartNew(() => MethodC())
            };

            //Block until all tasks complete.
            Task.WaitAll(tasks);

            // Continue on this thread...
            //</snippet06>
        }

        static void ChildTaskSnippets()
        {
            //<snippet07>
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task beginning.");

                var child = Task.Factory.StartNew(() =>
                {
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Detached task completed.");
                });
            });

            outer.Wait();
            Console.WriteLine("Outer task completed.");
            // The example displays the following output:
            //    Outer task beginning.
            //    Outer task completed.
            //    Detached task completed.
            //</snippet07>

            //<snippet08>
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent task beginning.");

                var child = Task.Factory.StartNew(() =>
                {
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Attached task completed.");
                }, TaskCreationOptions.AttachedToParent);
            });

            parent.Wait();
            Console.WriteLine("Parent task completed.");

            /* Output:
                Parent task beginning.
                Attached task completed.
                Parent task completed.
             */
            //</snippet08>

            var t = Task<int>.Factory.StartNew(() => 1);
        }
    }
}
