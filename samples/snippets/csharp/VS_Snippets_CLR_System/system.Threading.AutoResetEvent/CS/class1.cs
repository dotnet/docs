//<snippet1>
using System;
using System.Threading;

namespace AutoResetEvent_Examples
{
	class MyMainClass
	{
		//Initially not signaled.
      const int numIterations = 100;
      static AutoResetEvent myResetEvent = new AutoResetEvent(false);
      static int number;
      
      static void Main()
		{
         //Create and start the reader thread.
         Thread myReaderThread = new Thread(new ThreadStart(MyReadThreadProc));
         myReaderThread.Name = "ReaderThread";
         myReaderThread.Start();

         for(int i = 1; i <= numIterations; i++)
         {
            Console.WriteLine("Writer thread writing value: {0}", i);
            number = i;
            
            //Signal that a value has been written.
            myResetEvent.Set();
            
            //Give the Reader thread an opportunity to act.
            Thread.Sleep(1);
         }

         //Terminate the reader thread.
         myReaderThread.Abort();
      }

      static void MyReadThreadProc()
      {
         while(true)
         {
            //The value will not be read until the writer has written
            // at least once since the last read.
            myResetEvent.WaitOne();
            Console.WriteLine("{0} reading value: {1}", Thread.CurrentThread.Name, number);
         }
      }
	}
}
//</snippet1>
