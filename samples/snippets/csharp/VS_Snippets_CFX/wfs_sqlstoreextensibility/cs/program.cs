//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Persistence;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Activities.Description;
using System.Xml.Linq;

namespace Microsoft.Samples.SQLStoreExtensibility
{

    class Program
    {
        const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=InstanceStore;Integrated Security=True;Asynchronous Processing=True";
        const string hostBaseAddress = "http://localhost:8080/CountingService";
        static XNamespace xNS = XNamespace.Get("http://schemas.microsoft.com/framework/samples/persistence/SqlStoreExtensibility");

        [ServiceContract(Name = "ICountingWorkflow")]
        public interface ICountingWorkflow
        {
            [OperationContract(IsOneWay = true, Action="Start")]
            void start();
        }


        // Counting Workflow inplements a workflow that waits for a client to call its Start
        // method. Once called, the workflow counts from 0 to 29, incrementing the counter
        // every 2 seconds. After every counter increment the workflow persists.
        static Sequence CountingWorkflow()
        {
            Variable<int> counter = new Variable<int>() { Name="Counter", Default = 0};

            return new Sequence()
            {
                Variables = { counter },

                Activities =
                {
                    new Receive() 
                    {
                        Action = "Start",
                        CanCreateInstance = true,
                        OperationName  = "Start",
                        ServiceContractName = "ICountingWorkflow",
                    },

                    new While( (env => counter.Get(env) < 30 ))
                    {
                        Body = new Sequence()
                        {
                            Activities = 
                            {
                                new SaveCounter() { Counter = counter },

                                new Persist(),

                                new Delay() 
                                {
                                    Duration = TimeSpan.FromSeconds(2),
                                },

                                new Assign<int>()
                                {
                                    Value = new InArgument<int>(env => counter.Get(env) + 1),
                                    To = counter
                                }
                            }
                        }
                    }
                }
            };
        }


        public class SaveCounter : CodeActivity
        {
            public InArgument<Int32> Counter { get; set; }

            protected override void Execute(CodeActivityContext context )
            {
                int currentCount = context.GetExtension<CounterStatus>().Count = this.Counter.Get(context);
                Console.WriteLine("Counter = " + currentCount);
            }
        }


        class CounterStatus : PersistenceParticipant
        {
            public Int32 Count { get; set; }

            protected override void CollectValues(
                out IDictionary<XName, object> readWriteValues,
                out IDictionary<XName, object> writeOnlyValues)
            {
                readWriteValues = null;

                writeOnlyValues = new Dictionary<XName, object>();
                writeOnlyValues.Add(xNS.GetName("Count"), this.Count);
            }
        }

//<Snippet1>
        static void Main(string[] args)
        {
            // Create service host.
            WorkflowServiceHost host = new WorkflowServiceHost(CountingWorkflow(), new Uri(hostBaseAddress));

            // Add service endpoint.
            host.AddServiceEndpoint("ICountingWorkflow", new BasicHttpBinding(), "");

            // Define SqlWorkflowInstanceStore and assign it to host.
            SqlWorkflowInstanceStoreBehavior store = new SqlWorkflowInstanceStoreBehavior(connectionString);
            List<XName> variantProperties = new List<XName>()
            {   
                xNS.GetName("Count")
            };
            store.Promote("CountStatus", variantProperties, null);

            host.Description.Behaviors.Add(store);

            host.WorkflowExtensions.Add<CounterStatus>(() => new CounterStatus());
            host.Open(); // This sample needs to be run with Admin privileges.
                         // Otherwise the channel listener is not allowed to open ports.
                         // See sample documentation for details.

            // Create a client that sends a message to create an instance of the workflow.
            ICountingWorkflow client = ChannelFactory<ICountingWorkflow>.CreateChannel(new BasicHttpBinding(), new EndpointAddress(hostBaseAddress));
            client.start();

            Console.WriteLine("(Press [Enter] at any time to terminate host)");
            Console.ReadLine();
            host.Close();
        }
//</Snippet1>        
    }
}

