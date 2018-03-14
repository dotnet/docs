// The following example illustrates deriving a service implementation from
// the System.ServiceProcess.ServiceBase class.  This simple service starts
// a worker thread, and handles various service commands.
// The main service thread and the worker thread write their trace output
// to c:\service_log.txt.

// <Snippet1>

// Turn on constant for trace output.
#define TRACE

using System;
using System.ComponentModel;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Diagnostics;

namespace SimpleServiceSample
{
    // Define custom commands for the SimpleService.
    public enum SimpleServiceCustomCommands {StopWorker=128, RestartWorker, CheckWorker};

    // Define a simple service implementation.
    public class SimpleService : System.ServiceProcess.ServiceBase
	{
        private const String logFile = @"C:\service_log.txt";
        private static TextWriterTraceListener serviceTraceListener = null;
        private Thread workerThread = null;

        // <Snippet2>
        public SimpleService()
		{
            CanPauseAndContinue = true;
            ServiceName = "SimpleService";
		}
        // </Snippet2>

        static void Main()
        {

            // Create a file for trace output.
            // A new file is created each time.  If a
            // previous log file exists, it is overwritten.
            StreamWriter myFile = File.CreateText(logFile);
      
            // Create a new trace listener writing to the text file,
            // and add it to the trace listeners.
            serviceTraceListener = new TextWriterTraceListener(myFile);
            Trace.Listeners.Add(serviceTraceListener);

            Trace.AutoFlush = true;
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                " - Service main method starting...",
                "Main");

            // Load the service into memory.
            System.ServiceProcess.ServiceBase.Run(new SimpleService());

            Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                " - Service main method exiting...",
                "Main");

            // Remove and close the trace listener for this service.
            Trace.Listeners.Remove(serviceTraceListener);

            serviceTraceListener.Close();
            serviceTraceListener = null;
            myFile.Close();
        }

        private void InitializeComponent()
        {
            // Initialize the operating properties for the service.
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.ServiceName = "SimpleService";
        }

        // Start the service.
        protected override void OnStart(string[] args)
        {
            // Start a separate thread which does the actual work.

            if ((workerThread == null) || 
                ((workerThread.ThreadState &
                 (System.Threading.ThreadState.Unstarted | System.Threading.ThreadState.Stopped)) != 0))
            {
                Trace.WriteLine(DateTime.Now.ToLongTimeString() +
                    " - Starting service worker thread.",
                    "OnStart");

                workerThread = new Thread(new ThreadStart(ServiceWorkerMethod));
                workerThread.Start();
            }
            if (workerThread != null)
            {
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                    " - Worker thread state = " + 
                    workerThread.ThreadState.ToString(),
                    "OnStart");
            }


        }
 
        // <Snippet4>
        // Stop this service.
        protected override void OnStop()
        {
            // Signal the worker thread to exit.
            if ((workerThread != null) && (workerThread.IsAlive))
            {
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                    " - Stopping service worker thread.",
                    "OnStop");

                workerThread.Abort();

                // Wait up to 500 milliseconds for the thread to terminate.
                workerThread.Join(500);
            }
            if (workerThread != null)
            {
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                    " - Worker thread state = " + 
                    workerThread.ThreadState.ToString(),
                    "OnStop");
            }
        }
        // </Snippet4>

        // <Snippet5>
        // Pause the service.
        protected override void OnPause()
        {
            // Pause the worker thread.
            if ((workerThread != null) && 
                (workerThread.IsAlive) &&
                ((workerThread.ThreadState & 
                 (System.Threading.ThreadState.Suspended | System.Threading.ThreadState.SuspendRequested)) == 0))
            {
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                    " - Suspending service worker thread.",
                    "OnPause");

                workerThread.Suspend();
            }
            
            if (workerThread != null)
            {
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                    " - Worker thread state = " + 
                    workerThread.ThreadState.ToString(),
                    "OnPause");
            }
        }
        // </Snippet5>

        // <Snippet6>
        // Continue a paused service.
        protected override void OnContinue()
        {

            // Signal the worker thread to continue.
            if ((workerThread != null) && 
                ((workerThread.ThreadState & 
                 (System.Threading.ThreadState.Suspended | System.Threading.ThreadState.SuspendRequested)) != 0))
            {
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                    " - Resuming service worker thread.",
                    "OnContinue");

                workerThread.Resume();
            }
            if (workerThread != null)
            {
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                    " - Worker thread state = " + 
                    workerThread.ThreadState.ToString(),
                    "OnContinue");
            }
        }
        // </Snippet6>
     
        // <Snippet7>
        // Handle a custom command.
        protected override void OnCustomCommand(int command)
        {
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                " - Custom command received: " +
                command.ToString(),
                "OnCustomCommand");

            // If the custom command is recognized,
            // then signal the worker thread appropriately.

            switch (command)
            {
                case (int) SimpleServiceCustomCommands.StopWorker:
                    // Signal the worker thread to terminate.
                    // For this custom command, the main service
                    // continues to run without a worker thread.
                    OnStop();
                    break;

                case (int) SimpleServiceCustomCommands.RestartWorker:

                    // Restart the worker thread if necessary.
                    OnStart(null);
                    break;

                case (int) SimpleServiceCustomCommands.CheckWorker:

                    // Log the current worker thread state.
                    Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                        " - Worker thread state = " +
                        workerThread.ThreadState.ToString(),
                        "OnCustomCommand");

                    break;
    
                default:
                    Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                        " - Unrecognized custom command ignored!",
                        "OnCustomCommand");
                    break;
            }
        }
        // </Snippet7>

        // Define a simple method that runs as the worker thread of 
        // the service.  
        public void ServiceWorkerMethod()
        {
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                " - Starting service worker thread.",
                "Worker");
            
            try 
            {
                do 
                {
                    // Wake up every 10 seconds and write
                    // a message to the trace output.

                    Thread.Sleep(10000);
                    Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                        " - heartbeat cycle.",
                        "Worker");
                }
                while (true);
            }
            catch (ThreadAbortException)
            {
                // Another thread has signalled that this thread
                // must terminate.  Typically, this occurs when
                // the main service thread gets a service stop 
                // command.

                // Write a trace line indicating the worker thread
                // is exiting.  Notice that this simple thread does
                // not have any local objects or data to clean up.

                Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                    " - Thread abort signalled.",
                    "Worker");
            }

            Trace.WriteLine(DateTime.Now.ToLongTimeString() + 
                " - Exiting service worker thread.",
                "Worker");

        }
	}
}
// </Snippet1>
