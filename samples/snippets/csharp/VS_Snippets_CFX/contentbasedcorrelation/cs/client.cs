//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using Microsoft.Samples.ContentBasedCorrelation.SharedTypes;

namespace Microsoft.Samples.ContentBasedCorrelation.Client
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(GetClientWorkflow());
            Console.WriteLine("Press [ENTER] to exit");
            Console.ReadLine();

        }

        static Activity GetClientWorkflow()
        {
            // <Snippet0>
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>();
            Variable<Customer> customer = new Variable<Customer>();

            Endpoint clientEndpoint = new Endpoint
            {
                Binding = Constants.Binding,
                AddressUri = new Uri(Constants.ServiceAddress)
            };

            Send submitPO = new Send
            {
                Endpoint = clientEndpoint,
                ServiceContractName = Constants.POContractName,
                OperationName = Constants.SubmitPOName,
                Content = new SendMessageContent(new InArgument<PurchaseOrder>(po))               
            };
            // </Snippet0>
            // <Snippet3>
            return new Sequence
            {
                Variables = { po, customer },
                Activities =
                {                    
                    new Assign<PurchaseOrder> 
                    {
                        To = po,
                        Value = new InArgument<PurchaseOrder>( (e) => new PurchaseOrder() { PartName = "Widget", Quantity = 150 } )
                    },
                    new Assign<Customer>
                    {
                        To = customer,
                        Value = new InArgument<Customer>( (e) => new Customer() { Id = 12345678, Name = "John Smith" } )
                    },
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Submitting new PurchaseOrder for {0} {1}s", po.Get(e).Quantity, po.Get(e).PartName) ) },
                    new CorrelationScope
                    {
                        Body = new Sequence
                        { 
                            Activities = 
                            {
                                submitPO,
                                new ReceiveReply
                                {
                                    Request = submitPO,
                                    Content = ReceiveContent.Create(new OutArgument<int>( (e) => po.Get(e).Id ))
                                }
                            }
                        }
                    },                    
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Received ID for new PO: {0}", po.Get(e).Id) ) },
                    new Assign<int> { To = new OutArgument<int>( (e) => po.Get(e).Quantity ), Value = 250 },
                    new WriteLine { Text = "Updated PO with new quantity: 250.  Resubmitting updated PurchaseOrder based on POId." },
                    // <Snippet1>
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.UpdatePOName,
                        Content = SendContent.Create(new InArgument<PurchaseOrder>(po))
                    },           
                    // </Snippet1>
                    new Assign<int> 
                    { 
                        To = new OutArgument<int>( (e) => po.Get(e).CustomerId ), 
                        Value = new InArgument<int>( (e) => customer.Get(e).Id )
                    },
                    new WriteLine { Text = "Updating customer data based on CustomerId." },
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.AddCustomerInfoName,
                        Content = SendContent.Create(new InArgument<PurchaseOrder>(po))
                    },                    
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.UpdateCustomerName,
                        Content = SendContent.Create(new InArgument<Customer>(customer))
                    },
                    new WriteLine { Text = "Client completed." }
                }
            };
            // </Snippet3>
        }
    }
}
