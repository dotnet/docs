//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using Microsoft.Samples.ContentBasedCorrelation.SharedTypes;

namespace Microsoft.Samples.ContentBasedCorrelation.Service
{    
    class Program
    {
        static void Main(string[] args)
        {
            using (WorkflowServiceHost host = new WorkflowServiceHost(GetServiceWorkflow(), new Uri(Constants.ServiceAddress)))
            {
                host.AddServiceEndpoint(Constants.POContractName, Constants.Binding, Constants.ServiceAddress);

                host.Open();
                Console.WriteLine("Service waiting at: " + Constants.ServiceAddress);
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
                host.Close();
            }

        }

        static Activity GetServiceWorkflow()
        {
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>();
            Variable<Customer> customer = new Variable<Customer>();
            Variable<CorrelationHandle> poidHandle = new Variable<CorrelationHandle>();
            Variable<CorrelationHandle> custidHandle = new Variable<CorrelationHandle>();
            Variable<bool> complete = new Variable<bool>() { Default = false };

            Receive submitPO = new Receive
            {
                CanCreateInstance = true,
                ServiceContractName = Constants.POContractName,
                OperationName = Constants.SubmitPOName,
                Content = ReceiveContent.Create(new OutArgument<PurchaseOrder>(po))  // creates a ReceiveMessageContent
            };

            return new Sequence
            {
                Variables = { po, customer, poidHandle, custidHandle, complete },
                Activities =
                {
                    submitPO,
                    new WriteLine { Text = "Received PurchaseOrder" },
                    new Assign<int>
                    {
                        To = new OutArgument<int>( (e) => po.Get(e).Id ),
                        Value = new InArgument<int>( (e) => new Random().Next() )
                    },                    
                    // <Snippet2>
                    new SendReply
                    {
                        Request = submitPO,
                        Content = SendContent.Create(new InArgument<int>( (e) => po.Get(e).Id)), // creates a SendMessageContent
                        CorrelationInitializers =
                        {
                            new QueryCorrelationInitializer
                            {
                                // initializes a correlation based on the PurchaseOrder Id sent in the reply message and stores it in the handle
                                CorrelationHandle = poidHandle,
                                MessageQuerySet = new MessageQuerySet
                                {
                                    // int is the name of the parameter being sent in the outgoing response
                                    { "PoId", new XPathMessageQuery("sm:body()/ser:int", Constants.XPathMessageContext) }
                                }
                            }
                        }                        
                    }, 
                    // </Snippet2>
                    new Parallel 
                    {
                        CompletionCondition = complete,
                        Branches =
                        {
                            new While
                            {
                                Condition = true,
                                Body = new Receive
                                {
                                    ServiceContractName = Constants.POContractName,
                                    OperationName = Constants.UpdatePOName,                                    
                                    CorrelatesWith = poidHandle, // identifies that the UpdatePO operation is waiting on the PurchaseOrderId that was used to initialize this handle
                                    CorrelatesOn = new MessageQuerySet // the query that is used on an incoming message to find the requisite PurchaseOrderId specified in the correlation
                                    {
                                        // Id is the name of the incoming parameter within the PurchaseOrder
                                        { "PoId", new XPathMessageQuery("sm:body()/defns:PurchaseOrder/defns:Id", Constants.XPathMessageContext) } 
                                    },
                                    Content = ReceiveContent.Create(new OutArgument<PurchaseOrder>(po)) // creates a ReceiveMessageContent
                                }
                            },
                            new Sequence
                            {
                                Activities = 
                                {
                                    new Receive
                                    {
                                        ServiceContractName = Constants.POContractName,
                                        OperationName = Constants.AddCustomerInfoName,
                                        Content = ReceiveContent.Create(new OutArgument<PurchaseOrder>(po)), // creates a ReceiveMessageContent
                                        CorrelatesWith = poidHandle, // identifies that the AddCustomerInfo operation is waiting on the PurchaseOrderId that was used to initialize this handle
                                        CorrelatesOn = new MessageQuerySet // the query that is used on an incoming message to find the requisite PurchaseOrderId specified in the correlation
                                        {
                                            // Id is the name of the incoming parameter within the PurchaseOrder
                                            { "PoId", new XPathMessageQuery("sm:body()/defns:PurchaseOrder/defns:Id", Constants.XPathMessageContext) } 
                                        },
                                        CorrelationInitializers =
                                        {
                                            new QueryCorrelationInitializer
                                            {
                                                // initializes a new correlation based on the CustomerId parameter in the message and stores it in the handle
                                                CorrelationHandle = custidHandle,
                                                MessageQuerySet = new MessageQuerySet
                                                {
                                                    // CustomerId is the name of the incoming parameter within the PurchaseOrder    
                                                    { "CustId", new XPathMessageQuery("sm:body()/defns:PurchaseOrder/defns:CustomerId", Constants.XPathMessageContext) } 
                                                } 
                                            }
                                        }
                                    },
                                    new WriteLine { Text = "Got CustomerId" },
                                    new Receive
                                    {
                                        ServiceContractName = Constants.POContractName,
                                        OperationName = Constants.UpdateCustomerName,
                                        Content = ReceiveContent.Create(new OutArgument<Customer>(customer)), // creates a ReceiveMessageContent
                                        CorrelatesWith = custidHandle, // identifies that the UpdateCustomerName operation is waiting on the CustomerId that was used to initialize this handle
                                        CorrelatesOn = new MessageQuerySet // the query that is used on an incoming message to find the requisite CustomerId specified in the correlation
                                        {
                                            // Id is the name of the incoming parameter within the Customer type
                                            { "CustId", new XPathMessageQuery("sm:body()/defns:Customer/defns:Id", Constants.XPathMessageContext) } 
                                        }
                                    },
                                    new Assign<bool>
                                    {
                                        To = new OutArgument<bool>(complete),
                                        Value = new InArgument<bool>(true)
                                    }
                                }
                            }
                        }
                    },
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Workflow completed for PurchaseOrder {0}: {1} {2}s", po.Get(e).Id, po.Get(e).Quantity, po.Get(e).PartName) ) },
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Order will be shipped to {0} as soon as possible", customer.Get(e).Name) ) }
                }
            };

        }
    }

}
