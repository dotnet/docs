

namespace TPL
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
          //  WaitOnTasks();
          //  HandleExceptions();
          //  RethrowAllExceptions();

            Console.ReadKey();
        }

        class Test
        {
            public string Name { get; set; }
            public double Number { get; set; }
        }

        static void DoSomeWork(int val)
        {
            // Pretend to do something.
            Thread.SpinWait(val); // ticks, not milliseconds
        }

        static double TrySolution1()
        {
            // Pretend to do something.
            Thread.SpinWait(1000000); // ticks, not milliseconds
            return DateTime.Now.Millisecond;
        }
        static double TrySolution2()
        {
            // Pretend to do something.
            Thread.SpinWait(10000000); // ticks, not milliseconds
            return DateTime.Now.Millisecond;
        }
        static double TrySolution3()
        {
            // Pretend to do something.
            Thread.SpinWait(1000000); // ticks, not milliseconds
            return DateTime.Now.Millisecond;
        }

        static string[] GetAllFiles(string str)
        {
            // Should throw an AccessDenied exception on Vista.
            return System.IO.Directory.GetFiles(str, "*.txt", System.IO.SearchOption.AllDirectories);
        }
//         static void HandleExceptions()
//         {
//             // Assume this is a user-entered string.
//             string path = @"C:\";
//
//             // Use this line to throw UnauthorizedAccessException, which we handle.
//             Task<string[]> task1 = Task<string[]>.Factory.StartNew(() => GetAllFiles(path));
//
//             // Use this line to throw an exception that is not handled.
//             //  Task task1 = Task.Factory.StartNew(() => { throw new IndexOutOfRangeException(); } );
//             try
//             {
//                 task1.Wait();
//             }
//             catch (AggregateException ae)
//             {
//
//                 ae.Handle((x) =>
//                 {
//                     if (x is UnauthorizedAccessException) // This we know how to handle.
//                     {
//                         Console.WriteLine("You do not have permission to access all folders in this path.");
//                         Console.WriteLine("See your network administrator or try another path.");
//                         return true;
//                     }
//                     return false; // Let anything else stop the application.
//                 });
//
//             }
//
//             Console.WriteLine("task1 has completed.");
//         }

        //<snippet13>
        static string[] GetValidExtensions(string path)
        {
            if (path == @"C:\")
                throw new ArgumentException("The system root is not a valid path.");

            return new string[10];
        }
        static void RethrowAllExceptions()
        {
            // Assume this is a user-entered string.
            string path = @"C:\";

            Task<string[]>[] tasks = new Task<string[]>[3];
            tasks[0] = Task<string[]>.Factory.StartNew(() => GetAllFiles(path));
            tasks[1] = Task<string[]>.Factory.StartNew(() => GetValidExtensions(path));
            tasks[2] = Task<string[]>.Factory.StartNew(() => new string[10]);

            //int index = Task.WaitAny(tasks2);
            //double d = tasks2[index].Result;
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }

            Console.WriteLine("task1 has completed.");
        }
        //</snippet13>
    }

 // 14 was deleted, probably because it duplicated cancellation snippet

   // 15 was moved to tpl_cancellation and so number is available in tpl

    //<snippet16>
    public class TreeWalk
    {
        static void Main()
        {
            Tree<MyClass> tree = new Tree<MyClass>();

            // ...populate tree (left as an exercise)

            // Define the Action to perform on each node.
            Action<MyClass> myAction = x => Console.WriteLine("{0} : {1}", x.Name, x.Number);

            // Traverse the tree with parallel tasks.
            DoTree(tree, myAction);
        }

        public class MyClass
        {
            public string Name { get; set; }
            public int Number { get; set; }
        }
        public class Tree<T>
        {
            public Tree<T> Left;
            public Tree<T> Right;
            public T Data;
        }

        // By using tasks explicitly.
        public static void DoTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null) return;
            var left = Task.Factory.StartNew(() => DoTree(tree.Left, action));
            var right = Task.Factory.StartNew(() => DoTree(tree.Right, action));
            action(tree.Data);

            try
            {
                Task.WaitAll(left, right);
            }
            catch (AggregateException )
            {
                //handle exceptions here
            }
        }

        // By using Parallel.Invoke
        public static void DoTree2<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null) return;
            Parallel.Invoke(
                () => DoTree2(tree.Left, action),
                () => DoTree2(tree.Right, action),
                () => action(tree.Data)
            );
        }
    }

    //</snippet16>

    //not used
    //<snippet17>
    public class OrderPreservation
    {
    }

    //</snippet17>

    class InvokeDemo
    {

        static void MethodA() { }
        static void MethodB() { }
        static void MethodC() { }
        static void DoSomeWork(int i) { }
        static void Process(int i) { }
        static void DoSomeWork() { }
        static void DoSomeOtherWork() { }

        static int[] sourceCollection = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main()
        {

            int startIndex = 0;
            int endIndex = 10;
            //<snippet18>
            Parallel.For(startIndex, endIndex, (currentIndex) => DoSomeWork(currentIndex));
            //</snippet18>

            //<snippet19>
            Parallel.Invoke(
                        () => MethodA(),
                        () => MethodB(),
                        () => MethodC());
            //</snippet19>

            //<snippet20>
            // Sequential version
            foreach (var item in sourceCollection)
            {
                Process(item);
            }

            // Parallel equivalent
            Parallel.ForEach(sourceCollection, item => Process(item));
            //</snippet20>

            //<snippet21>
            Parallel.Invoke(() => DoSomeWork(), () => DoSomeOtherWork());
            //</snippet21>
        }
    }

    //}
}
