//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Description;
//using Microsoft.Samples.Faults.SharedTypes;

namespace Microsoft.Samples.Faults.FaultService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WorkflowServiceHost host = new WorkflowServiceHost(GetServiceWorkflow(), new Uri(Constants.ServiceAddress)))
            {
                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
                host.AddServiceEndpoint(Constants.POContractName, Constants.Binding, Constants.ServiceAddress);

                host.Open();
                Console.WriteLine("FaultService waiting at: " + Constants.ServiceAddress);
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
                host.Close();
            }

        }

        static Activity GetServiceWorkflow()
        {
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>();
            DelegateInArgument<Exception> exception = new DelegateInArgument<Exception> { Name = "UnexpectedException" };

            // receive the order request
            Receive submitPO = new Receive
            {
                CanCreateInstance = true,
                ServiceContractName = Constants.POContractName,
                OperationName = Constants.SubmitPOName,
                Content = ReceiveContent.Create(new OutArgument<PurchaseOrder>(po))
            };

            return new TryCatch
            {
                Variables = { po },
                Try = new Sequence
                {
                    Activities =
                    {
                        // receive the order request
                        submitPO,
//<Snippet1>
                        new If 
                        {
                            // check if the order is asking for Widgets
                            Condition = new InArgument<bool>( (e) => po.Get(e).PartName.Equals("Widget") ),
                            Then = new If
                            {
                                // check if we have enough widgets in stock
                                Condition = new InArgument<bool>( (e) => po.Get(e).Quantity < 100 ),
                                Then = new SendReply
                                {
                                    DisplayName = "Successful response",
                                    Request = submitPO,                                        
                                    Content = SendContent.Create(new InArgument<string>( (e) => string.Format("Success: {0} Widgets have been ordered!", po.Get(e).Quantity)) )
                                },
                                // if we don't have enough widgets, throw an unhandled exception from this operation's body
                                Else = new Throw
                                {
                                    Exception = new InArgument<Exception>((e) => new Exception("We don't have that many Widgets."))
                                }
                            },                        
                            // if its not for widgets, reply to the client that we don't carry that part by sending back an expected fault type (POFault)
                            Else = new SendReply
                            {
                                DisplayName = "Expected fault",
                                Request = submitPO,
                                Content = SendContent.Create(new InArgument<FaultException<POFault>>( (e) => new FaultException<POFault>(
                                    new POFault
                                    {
                                        Problem = string.Format("This company does not carry {0}s, but we do carry Widgets.", po.Get(e).PartName),
                                        Solution = "Try your local hardware store."
                                    },
                                    new FaultReason("This is an expected fault.")
                                    )))
                            }
                        }
//</Snippet1>
                    }
                },
                Catches =
                {
                    // catch any unhandled exceptions and send back a reply with that exception as a fault message
                    // note: handling this exception in the workflow will prevent the instance from terminating on unhandled exception,
                    //       however, if you don't catch the exception and the instance terminates while a reply is still pending, 
                    //       the WorkflowServiceHost will send the reply automatically with the exception details included
                    new Catch<Exception>
                    {
                        Action = new ActivityAction<Exception>
                        {
                            Argument = exception,
                            Handler = new SendReply
                            {
                                DisplayName = "Unexpected fault",
                                Request = submitPO,
                                Content = SendContent.Create(new InArgument<Exception>(exception))
                            }
                        }
                    }
                }
            };

        }
    }

}
