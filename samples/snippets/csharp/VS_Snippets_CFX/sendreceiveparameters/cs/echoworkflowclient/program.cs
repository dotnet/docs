//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.Xml.Linq;

namespace Microsoft.Samples.WorkflowServicesSamples.EchoWorkflowClient
{

    class Program
    {
        static Activity workflow;

        static void Main(string[] args)
        {
            CreateClientWorkflow();
            try
            {
                WorkflowInvoker.Invoke(workflow);
                Console.WriteLine("Workflow completed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Workflow completed with {0}: {1}.", e.GetType().FullName, e.Message);
            }
            Console.WriteLine("To exit press ENTER.");
            Console.ReadLine();
        }

        // <Snippet99>
        static void CreateClientWorkflow()
        {
            Variable<string> message = new Variable<string>("message", "Hello!");
            Variable<string> result = new Variable<string> { Name = "result" };
            
            Endpoint endpoint = new Endpoint
            {
                AddressUri = new Uri(Microsoft.Samples.WorkflowServicesSamples.Common.Constants.ServiceBaseAddress),
                Binding = new BasicHttpBinding(),
            };

            Send requestEcho = new Send
            {
                ServiceContractName = XName.Get("Echo", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "Echo",
                //parameters for send
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
                            Text = new InArgument<string>("Client is ready!")
                        },
                        requestEcho,

                        new WriteLine {
                            Text = new InArgument<string>("Message sent: Hello!")
                        },

                        new ReceiveReply
                        {
                            Request = requestEcho,
                            //parameters for the reply
                            Content = new ReceiveParametersContent                            
                            {
                                Parameters = 
                                {
                                    { "echo", new OutArgument<string>(result) }
                                }
                            }
                        },                                                
                        new WriteLine {
                            Text = new InArgument<string>(env => "Message received: "+result.Get(env))
                        }
                    }
                }
            };
        }
        // </Snippet99>
    }
}
