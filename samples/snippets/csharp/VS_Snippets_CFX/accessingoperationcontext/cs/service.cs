//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.Xml.Linq;

namespace Microsoft.Samples.AccessingOperationContext.Service
{    
    class Program
    {
        const string addr = "http://localhost:8080/Service";
        static XName contract = XName.Get("IService", "http://tempuri.org");

        static void Main(string[] args)
        {
            string addr = "http://localhost:8080/Service";

            using (WorkflowServiceHost host = new WorkflowServiceHost(GetServiceWorkflow()))
            {
                host.AddServiceEndpoint(contract, new BasicHttpBinding(), addr);

                host.Open();
                Console.WriteLine("Service waiting at: " + addr);
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
                host.Close();
            }

        }

        static Activity GetServiceWorkflow()
        {
            Variable<string> echoString = new Variable<string>();

            Receive echoRequest = new Receive
            {
                CanCreateInstance = true,
                ServiceContractName = contract,
                OperationName = "Echo",
                Content = new ReceiveParametersContent()
                {
                    Parameters = { { "echoString", new OutArgument<string>(echoString) } }
                }
            };

            return new ReceiveInstanceIdScope
            {
                Variables = { echoString },
                Activities =
                {
                    echoRequest,
                    new WriteLine { Text = new InArgument<string>( (e) => "Received: " + echoString.Get(e) ) },
                    new SendReply
                    {
                        Request = echoRequest,
                        Content = new SendParametersContent()
                        {
                            Parameters = { { "result", new InArgument<string>(echoString) } } 
                        }
                    }
                }
            };
        }
    }

}
