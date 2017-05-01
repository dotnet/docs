//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.XamlIntegration;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activities;

namespace Microsoft.Samples.WF.ManagementEndpoint
{
    class Program
    {
        static void Main()
        {
            // Same workflow as Dataflow sample
            Activity workflow = LoadProgram("Dataflow.xaml");
            WorkflowServiceHost host = new WorkflowServiceHost(workflow,
                new Uri("http://localhost/Dataflow.xaml"));            

            WorkflowControlEndpoint controlEndpoint = new WorkflowControlEndpoint(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));

            CreationEndpoint creationEndpoint = new CreationEndpoint(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml/Creation")));

            
            host.AddServiceEndpoint(controlEndpoint);
            host.AddServiceEndpoint(creationEndpoint);

            host.Open();

            Console.WriteLine("Host open...");

            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(creationEndpoint.Binding, creationEndpoint.Address).CreateChannel();

            // Start a new instance of the workflow
            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(controlEndpoint);
            controlClient.Unsuspend(instanceId);

            Console.WriteLine("Hit any key to exit Host...");
            Console.ReadLine();
        }
        
        public static Activity LoadProgram(string xamlPath)
        {
            FileStream stream = null;
            Activity activity = null;

            try
            {
                stream = File.OpenRead(xamlPath);
                activity = ActivityXamlServices.Load(stream);

            }
            finally
            {
                stream.Close();
            }

            return activity;
        }

    }    
}
