//<Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace CorrlationManager
{
    class Program
    {
        //private static TraceSource ts;
        static void Main(string[] args)
        {
            //<Snippet2>
            TraceSource ts = new TraceSource("MyApp");
            int i = ts.Listeners.Add(new ConsoleTraceListener());
            ts.Listeners[i].TraceOutputOptions = TraceOptions.LogicalOperationStack;
            ts.Switch = new SourceSwitch("MyAPP", "Verbose");
            // Start the logical operation on the Main thread.
            Trace.CorrelationManager.StartLogicalOperation("MainThread");
            //</Snippet2>
            ts.TraceEvent(TraceEventType.Error, 1, "Trace an error event.");
            Thread t = new Thread(new ThreadStart(ThreadProc));
            // Start the worker thread.
            t.Start();
            // Give the worker thread a chance to execute.
            Thread.Sleep(1000);
            Trace.CorrelationManager.StopLogicalOperation();
        }
        public static void ThreadProc()
        {
            TraceSource ts = new TraceSource("MyApp");
            int i = ts.Listeners.Add(new ConsoleTraceListener());
            ts.Listeners[i].TraceOutputOptions = TraceOptions.LogicalOperationStack;
            ts.Switch = new SourceSwitch("MyAPP", "Verbose");
            // Add another logical operation.
            Trace.CorrelationManager.StartLogicalOperation("WorkerThread");
            ts.TraceEvent(TraceEventType.Error, 1, "Trace an error event.");
            Trace.CorrelationManager.StopLogicalOperation();
        }
    }
}
// This sample generates the following output:
//MyApp Error: 1 : Trace an error event.
//    LogicalOperationStack=MainThread
//MyApp Error: 1 : Trace an error event.
//    LogicalOperationStack=WorkerThread, MainThread
//</Snippet1>
