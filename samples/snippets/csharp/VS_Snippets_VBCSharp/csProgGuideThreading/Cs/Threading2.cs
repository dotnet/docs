// examples removed from Threading topic.

//namespace WrapThreading
//{
//    public class AClass
//    {
//        public void AMethod() { }
//    }

//    class TestThreading
//    {
//        static void Main()
//        {
//            AClass anObject = new AClass();

//            //<Snippet11>
//            System.Threading.Thread newThread;
//            newThread = new System.Threading.Thread(anObject.AMethod);
//            //</Snippet11>

//            //<Snippet12>
//            newThread.Start();
//            //</Snippet12>
//        }
//    }
//}


//-----------------------------------------------------------------------------
namespace WrapSynchronization
{
    //<Snippet13>
    public class TestThreading
    {
        private System.Object lockThis = new System.Object();
        
        public void Process()
        {
            
            lock (lockThis)
            {
                // Access thread-sensitive resources.
            }
        }
        
    }
    //</Snippet13>
    public class TestThreading2
    {

        public void DoSomething()
        {
        }

        public void TestMonitors()
        {
            System.Object x = new System.Object();

            //<Snippet14>
            lock (x)
            {
                DoSomething();
            }
            //</Snippet14>


            //<Snippet15>
            System.Object obj = (System.Object)x;
            System.Threading.Monitor.Enter(obj);
            try
            {
                DoSomething();
            }
            finally
            {
                System.Threading.Monitor.Exit(obj);
            }
            //</Snippet15>
        }


    }
}


//-----------------------------------------------------------------------------
namespace WrapSynchronization2
{
    //<Snippet16>
    using System;
    using System.Threading;

    class ThreadingExample
    {
        static AutoResetEvent autoEvent;

        static void DoWork()
        {
            Console.WriteLine("   worker thread started, now waiting on event...");
            autoEvent.WaitOne();
            Console.WriteLine("   worker thread reactivated, now exiting...");
        }

        static void Main()
        {
            autoEvent = new AutoResetEvent(false);

            Console.WriteLine("main thread starting worker thread...");
            Thread t = new Thread(DoWork);
            t.Start();

            Console.WriteLine("main thread sleeping for 1 second...");
            Thread.Sleep(1000);

            Console.WriteLine("main thread signaling worker thread...");
            autoEvent.Set();
        }
    }
    //</Snippet16>
}



