//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.ServiceModel;
using System.ServiceModel.Activities;

namespace Microsoft.Samples.WF.ManagementEndpoint
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Client starting...");
            // <Snippet1>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();

            // Start a new instance of the workflow
            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));
            controlClient.Unsuspend(instanceId);
            // </Snippet1>
            Console.WriteLine("Client exiting...");
        }

        static void Snippet2()
        {
            // <Snippet2>
            WorkflowControlEndpoint wce = new WorkflowControlEndpoint(new BasicHttpBinding(), new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));
            WorkflowControlClient controlClient = new WorkflowControlClient(wce);
            // </Snippet2>
        }

        static void Snippet3()
        {
            // <Snippet3>
            WorkflowControlClient controlClient = new WorkflowControlClient("ConfigName");
            // </Snippet3>
        }

        static void Snippet4()
        {
            // <Snippet4>
            WorkflowControlClient controlClient = new WorkflowControlClient("ConfigName", new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));
            // </Snippet4>
        }

        static void Snippet5()
        {
            // <Snippet5>
            WorkflowControlClient controlClient = new WorkflowControlClient("ConfigName", "http://localhost/DataflowControl.xaml");
            // </Snippet5>
        }

        static void Snippet6()
        {
            // <Snippet6>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();

            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));
            controlClient.Unsuspend(instanceId);
            // ...
            controlClient.Abandon(instanceId);
            // </Snippet6>
        }

        static void Snippet7()
        {
            // <Snippet7>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();

            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));
            controlClient.Unsuspend(instanceId);
            // ...
            controlClient.Abandon(instanceId, "Sample to abandon");
            // </Snippet7>
        }

        static void Snippet8()
        {
            // <Snippet8>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();

            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));
            controlClient.Unsuspend(instanceId);
            // ...
            controlClient.Cancel(instanceId);
            // </Snippet8>
        }

        static void Snippet9()
        {
            // <Snippet9>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();
            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));

            // ...

            controlClient.Run(instanceId);
            // </Snippet9>
        }

        static void Snippet10()
        {
            // <Snippet10>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();
            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));

            // ...

            controlClient.Suspend(instanceId);
            // </Snippet10>
        }

        static void Snippet11()
        {
            // <Snippet11>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();
            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));

            // ...

            controlClient.Suspend(instanceId, "Sample to suspend");
            // </Snippet11>
        }

        static void Snippet12()
        {
            // <Snippet12>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();
            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));

            controlClient.Unsuspend(instanceId);
            
            // ...

            controlClient.Terminate(instanceId);
            // </Snippet12>
        }

        static void Snippet13()
        {
            // <Snippet13>
            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();
            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));

            controlClient.Unsuspend(instanceId);

            // ...

            controlClient.Terminate(instanceId, "Sample to terminate");
            // </Snippet13>
        }
    }
}
