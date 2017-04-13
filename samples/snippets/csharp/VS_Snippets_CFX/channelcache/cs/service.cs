//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel.Activities;

namespace Microsoft.Samples.ChannelCache.EchoWorkflowService
{

    class Program
    {
        static WorkflowService service;        
        
        private static void CreateService()
        {
            // <Snippet1>
            Variable<string> message = new Variable<string> { Name = "message" };
            Variable<string> echo = new Variable<string> { Name = "echo" };

            Receive receiveString = new Receive
            {
                OperationName = "Echo",
                ServiceContractName = "Echo",
                CanCreateInstance = true,
                Content = new ReceiveParametersContent
                {
                    Parameters = 
                    {
                        {"message", new OutArgument<string>(message)}
                    }
                }
            };
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
                            Value = new InArgument<string>(env =>("Hello, " + message.Get(env))),
                            To = new OutArgument<string>(echo)
                        },                        
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

            // </Snippet1>
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting up...");
            CreateService();
            Uri address = new Uri(Common.Constants.ServiceBaseAddress);
            WorkflowServiceHost host = new WorkflowServiceHost(service, address);

            // A host level channel cache is not necessary for this example as our server workflow
            // does not have a Send activity. However, the following can be used to add a host level 
            // channel cache that the Send activities in the service workflow could use.

            //Func<object> hostLevelChannelCacheProvider = () =>
            //    {
            //        return new SendMessageChannelCache
            //        {
            //            FactorySettings = new ChannelCacheSettings
            //            {
            //                MaxItemsInCache = 10,
            //                IdleTimeout = TimeSpan.FromSeconds(10),
            //                LeaseTimeout = TimeSpan.FromSeconds(5)
            //            },
            //            ChannelSettings = new ChannelCacheSettings
            //            {
            //                MaxItemsInCache = 10,
            //                IdleTimeout = TimeSpan.FromSeconds(10),
            //                LeaseTimeout = TimeSpan.FromSeconds(5)
            //            }
            //        };
            //    };

            //host.WorkflowExtensions.Add(hostLevelChannelCacheProvider);

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
        }
    }
}

