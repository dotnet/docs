//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------


using System;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;

namespace Microsoft.Samples.WF.CreationEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Sequence workflow;
            WorkflowServiceHost host=null;

            try
            {
                workflow = CreateWorkflow();
                host = new WorkflowServiceHost(workflow, new Uri("net.pipe://localhost"));
                CreationEndpoint creationEp = new CreationEndpoint(new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), new EndpointAddress("net.pipe://localhost/workflowCreationEndpoint"));
                host.AddServiceEndpoint(creationEp);
                host.Open();
                //client using NetNamedPipeBinding
                IWorkflowCreation client = new ChannelFactory<IWorkflowCreation>(creationEp.Binding, creationEp.Address).CreateChannel();
                //client using BasicHttpBinding
                IWorkflowCreation client2 = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), new EndpointAddress("http://localhost/workflowCreationEndpoint")).CreateChannel();
                //create instance
                Console.WriteLine("Workflow Instance created using CreationEndpoint added in code. Instance Id: {0}",  client.Create(null));
                //create another instance
                Console.WriteLine("Workflow Instance created using CreationEndpoint added in config. Instance Id: {0}", client2.Create(null));
                Console.WriteLine("Press return to exit ...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (host != null)
                {
                    host.Close();
                }
            }

        }

        static Sequence CreateWorkflow()
        {
            Sequence workflow = new Sequence
            {
                DisplayName = "CreationService",
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Hello World"
                    }
                }
            };

            return workflow;
        }

    }
}
