using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CDSCountdownEvent
{
    class Data
    {
        public int Num { get; set; }
        public Data(int i) { Num = i; }
        public Data() { }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //   SemaphoreWithCancel();

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
        static void ProcessData(object obj)
        {
            Data d = (Data)obj;
            Thread.SpinWait(50000000);
            Console.WriteLine("Processed {0}", d.Num);
        }

        static IEnumerable<Data> GetData()
        {
            return new List<Data>() { new Data(1), new Data(2), new Data(3), new Data(4), new Data(5) };
        }

        void SnippetOne()
        {
            //<snippet01>
            IEnumerable<Data> source = GetData();
            using (CountdownEvent e = new CountdownEvent(1))
            {
                // fork work:
                foreach (Data element in source)
                {
                    // Dynamically increment signal count.
                    e.AddCount();
                    ThreadPool.QueueUserWorkItem(delegate(object state)
                     {
                         try
                         {
                             ProcessData(state);
                         }
                         finally
                         {
                             e.Signal();
                         }
                     },
                     element);
                }
                e.Signal();

                // The first element could be run on this thread.

                // Join with work.
                e.Wait();
            }
            // .,.
            //</snippet01>
        } //end method
    }

    //<snippet02>
    class CancelableCountdownEvent
    {
        class Data
        {
            public int Num { get; set; }
            public Data(int i) { Num = i; }
            public Data() { }
        }

        class DataWithToken
        {
            public CancellationToken Token { get; set; }
            public Data Data { get; private set; }
            public DataWithToken(Data data, CancellationToken ct)
            {
                this.Data = data;
                this.Token = ct;
            }
        }
        static IEnumerable<Data> GetData()
        {
            return new List<Data>() { new Data(1), new Data(2), new Data(3), new Data(4), new Data(5) };
        }
        static void ProcessData(object obj)
        {
            DataWithToken dataWithToken = (DataWithToken)obj;
            if (dataWithToken.Token.IsCancellationRequested)
            {
                Console.WriteLine("Canceled before starting {0}", dataWithToken.Data.Num);
                return;
            }

            for (int i = 0; i < 10000; i++)
            {
                if (dataWithToken.Token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancelling while executing {0}", dataWithToken.Data.Num);
                    return;
                }
                // Increase this value to slow down the program.
                Thread.SpinWait(100000);
            }
            Console.WriteLine("Processed {0}", dataWithToken.Data.Num);
        }

        static void Main(string[] args)
        {
            EventWithCancel();

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        static void EventWithCancel()
        {
            //<snippet04>
            IEnumerable<Data> source = GetData();
            CancellationTokenSource cts = new CancellationTokenSource();

            //Enable cancellation request from a simple UI thread.
            Task.Factory.StartNew(() =>
                 {
                     if (Console.ReadKey().KeyChar == 'c')
                         cts.Cancel();
                 });

            // Event must have a count of at least 1
            CountdownEvent e = new CountdownEvent(1);

            // fork work:
            foreach (Data element in source)
            {
                DataWithToken item = new DataWithToken(element, cts.Token);
                // Dynamically increment signal count.
                e.AddCount();
                ThreadPool.QueueUserWorkItem(delegate(object state)
                 {
                     ProcessData(state);
                     if (!cts.Token.IsCancellationRequested)
                         e.Signal();
                 },
                 item);
            }
            // Decrement the signal count by the one we added
            // in the constructor.
            e.Signal();

            // The first element could be run on this thread.

            // Join with work or catch cancellation.
            try
            {
                e.Wait(cts.Token);
            }
            catch (OperationCanceledException oce)
            {
                if (oce.CancellationToken == cts.Token)
                {
                    Console.WriteLine("User canceled.");
                }
                else
                {
                    throw; //We don't know who canceled us!
                }
            }
            finally {
                e.Dispose();
                cts.Dispose();
            }
            //...
            //</snippet04>
        } //end method
    } //end class
    //</snippet02>

    class CancelSemaphore
    {
        static IEnumerable<Data> GetData()
        {
            return new List<Data>() { new Data(1), new Data(2), new Data(3), new Data(4), new Data(5) };
        }

        static void SemaphoreWithCancel()
        {

            //<snippet03>
            IEnumerable<Data> source = GetData();
            CancellationTokenSource cts = new CancellationTokenSource();

            //Enable cancellation request from a simple UI thread.
            Task.Factory.StartNew(() =>
                 {
                     if (Console.ReadKey().KeyChar == 'c')
                         cts.Cancel();
                 });

            // CountdownEvent e = new CountdownEvent(1);
            SemaphoreSlim ss = new SemaphoreSlim(2);
            Task t = Task.Factory.StartNew(() =>
                {
                    ss.Release();
                    Thread.SpinWait(5000000);
                });

            try
            {

                ss.Wait(1000, cts.Token);
            }

            catch (AggregateException ae)
            {
                Console.WriteLine(ae.InnerException.Message);
            }
            catch (OperationCanceledException oce)
            {
                if (oce.CancellationToken == cts.Token)
                {
                    Console.WriteLine("User canceled.");
                }
                else
                {
                    throw; //We don't know who canceled us!
                }
            }
            finally
            {
                ss.Dispose();
                cts.Dispose();
            }
            //...
            //</snippet03>
        } //end method
    } //end class
} //end namespace
