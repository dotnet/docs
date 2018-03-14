//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel.Activities;
using Microsoft.Samples.WorkflowServicesSamples.Common;

namespace Microsoft.Samples.WorkflowServicesSamples.EchoWorkflowService
{

    class Program
    {
        static WorkflowService service;

        private static WorkflowService CreateService()
        {
            // <Snippet0>
            Variable<string> message = new Variable<string> { Name = "message" };
            Variable<string> echo = new Variable<string> { Name = "echo" };
            // <Snippet1>
            Receive receiveString = new Receive
            {
                OperationName = "Echo",
                ServiceContractName = "Echo",
                CanCreateInstance = true,
                //parameters for receive
                Content = new ReceiveParametersContent
                {
                    Parameters = 
                    {
                        {"message", new OutArgument<string>(message)}
                    }
                }
            };
            // </Snippet1>

            Sequence workflow = new Sequence()
            {
                Variables = { message, echo },
                Activities =
                    {
                        receiveString,
                        new WriteLine
                        {
                            Text = new InArgument<string>(env =>("Message received: " + message.Get(env)))
                        },
                        new Assign<string>
                        {
                            Value = new InArgument<string>(env =>("<echo> " + message.Get(env))),
                            To = new OutArgument<string>(echo)
                        },                        
                        //parameters for reply
                        // <Snippet2>
                        new SendReply
                        {                           
                            Request = receiveString,                            
                            Content = new SendParametersContent
                            {
                                Parameters =
                                {
                                    { "echo", new InArgument<string>(echo) }
                                },
                            }
                        },
                        // </Snippet2>
                        new WriteLine
                        {
                            Text = new InArgument<string>(env =>("Message sent: " + echo.Get(env)))
                        },
                    },
            };

            service = new WorkflowService
            {
                Name = "Echo",
                Body = workflow
            };
            // </Snippet0>
            return service;
        }



        static void Main(string[] args)
        {
            // <Snippet03>
            Console.WriteLine("Starting up...");
            WorkflowService service = CreateService();
            Uri address = new Uri(Constants.ServiceBaseAddress);
            WorkflowServiceHost host = new WorkflowServiceHost(service, address);

            try
            {
                Console.WriteLine("Opening service...");
                host.Open();

                Console.WriteLine("Service is listening on {0}...", address);
                Console.WriteLine("To terminate press ENTER");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service terminated with exception {0}", ex.ToString());
            }
            finally
            {
                host.Close();
            }
            // </Snippet03>
        }
    }
}

