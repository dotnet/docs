//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.ServiceModel.Activities;
using System.Threading;

namespace Microsoft.Samples.TransactedReceiveScope
{

    class Program
    {
        private static AutoResetEvent syncEvent = new AutoResetEvent(false);
        
        static void Main()
        {
            Console.WriteLine("Building the server.");
            using (WorkflowServiceHost host = new WorkflowServiceHost(new DeclarativeServiceWorkflow(), new Uri("net.tcp://localhost:8000/TransactedReceiveService/Declarative")))
            {
                host.WorkflowExtensions.Add(new EventTrackingParticipant(Program.syncEvent));
                
                //Start the server
                host.Open();
                Console.WriteLine("Service started.");
                syncEvent.WaitOne();

                //Shutdown
                host.Close();

            };

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}
