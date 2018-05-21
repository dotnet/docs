    //using System.Threading;

    class ThreadTest
    {
        public void RunMe()
        {
            Console.WriteLine("RunMe called");
        }

        static void Main()
        {
            ThreadTest b = new ThreadTest();
            Thread t = new Thread(b.RunMe);
            t.Start();
        }
    }
    // Output: RunMe called
