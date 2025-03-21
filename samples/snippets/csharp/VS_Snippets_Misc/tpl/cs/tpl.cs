namespace TPL
{
    using System;
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

        //<snippet13>
        static string[] GetValidExtensions(string path)
        {
            if (path == @"C:\")
                throw new ArgumentException("The system root is not a valid path.");

            return new string[10];
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
            Action<MyClass> myAction = x => Console.WriteLine($"{x.Name} : {x.Number}");

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
            catch (AggregateException)
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
