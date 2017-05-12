//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.Threading;
using System.Xml.Linq;

namespace Microsoft.Samples.ChannelCache.EchoWorkflowClient
{

    class Program
    {
        static Activity workflow;
        static AutoResetEvent completeEvent;
        static SendMessageChannelCache sharedChannelCache;
        static void Main(string[] args)
        {
            completeEvent = new AutoResetEvent(false);
            CreateClientWorkflow();

	    // <Snippet0>
            
            //sharing a channel cache between two workflow applications in a single app-domain.
            sharedChannelCache = new SendMessageChannelCache(new ChannelCacheSettings { MaxItemsInCache = 5 }, new ChannelCacheSettings { MaxItemsInCache = 5 });

            WorkflowApplication workflowApp1 = new WorkflowApplication(workflow);
            workflowApp1.Completed = new Action<WorkflowApplicationCompletedEventArgs>(OnCompleted);
            workflowApp1.Extensions.Add(sharedChannelCache);

            WorkflowApplication workflowApp2 = new WorkflowApplication(workflow);
            workflowApp2.Completed = new Action<WorkflowApplicationCompletedEventArgs>(OnCompleted);
            workflowApp2.Extensions.Add(sharedChannelCache);

            //disabling the channel cache so that channels are closed after being used.
            SendMessageChannelCache disabledChannelCache = new SendMessageChannelCache(new ChannelCacheSettings { MaxItemsInCache = 0 }, new ChannelCacheSettings { MaxItemsInCache = 0 });
            
            WorkflowApplication workflowApp3 = new WorkflowApplication(workflow);
            workflowApp3.Completed = new Action<WorkflowApplicationCompletedEventArgs>(OnCompleted);
            workflowApp3.Extensions.Add(disabledChannelCache);

	    // </Snippet0>

            try
            {                
                workflowApp1.Run();
                completeEvent.WaitOne();
                Console.WriteLine("Workflow 1 completed successfully.");

                workflowApp2.Run();
                completeEvent.WaitOne();
                Console.WriteLine("Workflow 2 completed successfully.");

                workflowApp3.Run();
                completeEvent.WaitOne();
                Console.WriteLine("Workflow 3 completed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Workflow completed with {0}: {1}.", e.GetType().FullName, e.Message);
            }
            Console.WriteLine("To exit press ENTER.");
            Console.ReadLine();
        }


        static void OnCompleted(WorkflowApplicationCompletedEventArgs completedArgs)
        {            
            completeEvent.Set();
        }

        static void CreateClientWorkflow()
        {
            // <Snippet2>
            Variable<string> message = new Variable<string>("message", "client");
            Variable<string> result = new Variable<string> { Name = "result" };
            
            Endpoint endpoint = new Endpoint
            {
                AddressUri = new Uri(Common.Constants.ServiceBaseAddress),
                Binding = new BasicHttpBinding(),
            };

            Send requestEcho = new Send
            {
                ServiceContractName = XName.Get("Echo", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "Echo",
                Content = new SendParametersContent
                {
                    Parameters = 
                        { 
                            { "message", new InArgument<string>(message) }
                        }
                }
            };
            workflow = new CorrelationScope
            {
                Body = new Sequence
                {
                    Variables = { message, result },
                    Activities =
                    {
                        new WriteLine {
                            Text = new InArgument<string>("Hello")
                        },
                        requestEcho,
                        new ReceiveReply
                        {
                            Request = requestEcho,
                            Content = new ReceiveParametersContent                            
                            {
                                Parameters = 
                                {
                                    { "echo", new OutArgument<string>(result) }
                                }
                            }
                        },                        
                        new WriteLine {
                            Text = new InArgument<string>(result)
                        }
                    }
                }
            };
            // </Snippet2>
        }
    }
}
