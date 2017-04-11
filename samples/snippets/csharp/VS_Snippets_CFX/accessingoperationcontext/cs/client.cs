//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.Xml.Linq;

namespace Microsoft.Samples.AccessingOperationContext.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Activity workflow = GetClientWorkflow();
            WorkflowInvoker.Invoke(workflow);
            WorkflowInvoker.Invoke(workflow);
            Console.WriteLine("Press [ENTER] to exit");
            Console.ReadLine();
        }

        static Activity GetClientWorkflow()
        {
            Variable<string> echoString = new Variable<string>();

            Endpoint clientEndpoint = new Endpoint
            {
                Binding = new BasicHttpBinding(),
                AddressUri = new Uri("http://localhost:8080/Service")
            };

            Send echoRequest = new Send
            {
                Endpoint = clientEndpoint,
                ServiceContractName = XName.Get("IService", "http://tempuri.org"),
                OperationName = "Echo",
                Content = new SendParametersContent()
                {
                    Parameters = { { "echoString", new InArgument<string>("Hello, World") } } 
                }
            };

            return new SendInstanceIdScope
            {
                Variables = { echoString },
                Activities =
                {                    
                    new CorrelationScope
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                echoRequest,
                                new ReceiveReply
                                {
                                    Request = echoRequest,
                                    Content = new ReceiveParametersContent
                                    {
                                        Parameters = { { "result", new OutArgument<string>(echoString) } }
                                    }
                                }
                            }
                        }
                    },                    
                    new WriteLine { Text = new InArgument<string>( (e) => "Received Text: " + echoString.Get(e) ) },                    
                }
            };
        }
    }
}
