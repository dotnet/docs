//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Threading;

namespace Microsoft.Samples.TransactedReceiveScope
{

    class Program
    {
        private static AutoResetEvent syncEvent = new AutoResetEvent(false);
            
        static void Main(string[] args)
        {
            //Build client
            Console.WriteLine("Building the client.");
            WorkflowApplication client = new WorkflowApplication(new DeclarativeClientWorkflow());
            client.Completed = Program.Completed;
            client.Aborted = Program.Aborted;
            client.OnUnhandledException = Program.OnUnhandledException;

            //Wait for service to start
            Console.WriteLine("Press ENTER once service is started.");
            Console.ReadLine();

            //Start the client            
            Console.WriteLine("Starting the client.");
            client.Run();
            syncEvent.WaitOne();

            //Sample complete
            Console.WriteLine();
            Console.WriteLine("Client complete. Press ENTER to exit.");
            Console.ReadLine();
        }
        
        private static void Completed(WorkflowApplicationCompletedEventArgs e)
        {
            Program.syncEvent.Set();
        }

        private static void Aborted(WorkflowApplicationAbortedEventArgs e)
        {
            Console.WriteLine("Client Aborted: {0}", e.Reason);
            Program.syncEvent.Set();
        }

        private static UnhandledExceptionAction OnUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Client had an unhandled exception: {0}", e.UnhandledException);
            return UnhandledExceptionAction.Cancel;
        }
    }
}
