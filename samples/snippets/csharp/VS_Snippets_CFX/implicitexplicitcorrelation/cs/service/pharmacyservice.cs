//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Samples.ImplicitExplicitCorrelation
{
    class PharmacyService
    {
        static WorkflowService GetService()
        {
            Variable<Customer> customer = new Variable<Customer>();
            Variable<Order> order = new Variable<Order>();
            Variable<string> drug = new Variable<string>();
            Variable<double> adjustedCost = new Variable<double>();
            Variable<int> percentagePaidByInsurance = new Variable<int>();
            Variable<CorrelationHandle> customerHandle = new Variable<CorrelationHandle>();
            Variable<CorrelationHandle> orderHandle = new Variable<CorrelationHandle>();

            XPathMessageContext pathContext = new XPathMessageContext();
            pathContext.AddNamespace("psns", Constants.PharmacyServiceNamespace);

            // <Snippet2>
            MessageQuerySet GetOrderQuerySet = new MessageQuerySet
            {
                {
                    "OrderID", 
                    new XPathMessageQuery("//psns:Order/psns:OrderID",pathContext)
                }
            };
            // </Snippet2>
            MessageQuerySet GetOrderIDQuerySet = new MessageQuerySet
            {
                {
                    "OrderID", 
                    new XPathMessageQuery("//ser:guid",pathContext)
                }
            };

            MessageQuerySet customerQuerySet = new MessageQuerySet
            {
                {
                    "CustomerID", 
                    new XPathMessageQuery("//psns:GetBaseCost/psns:Customer/psns:CustomerID",pathContext)
                }
            };

            MessageQuerySet customerIDQuerySet = new MessageQuerySet
            {
                {
                    "CustomerID", 
                    new XPathMessageQuery("//ser:guid",pathContext)
                }
            };


            // This will use implicit correlation within the workflow using the WorkflowServiceHost's default CorrelationHandle
            // <Snippet3>
            Receive prescriptionRequest = new Receive
            {
                DisplayName = "Request Perscription",
                OperationName = "GetBaseCost",
                ServiceContractName = Constants.PharmacyServiceContractName,
                CanCreateInstance = true,
                //CorrelatesWith = customerHandle,  -- add this line for explicit correlation
                CorrelatesOn = customerQuerySet,
                Content = new ReceiveParametersContent
                {
                    Parameters = 
                    {
                        {"Customer",new OutArgument<Customer>(customer)},
                        {"Drug",new OutArgument<string>(drug)},
                    }
                }
            };
            // </Snippet3>

            // This will use implicit correlation within the workflow using the WorkflowServiceHost's default CorrelationHandle
            Receive GetInsurancePaymentPercentageRequest = new Receive
            {
                DisplayName = "Get Insurance Coverage",
                ServiceContractName = Constants.PharmacyServiceContractName,
                OperationName = "GetInsurancePaymentPercentage",
                CanCreateInstance = true,
                //CorrelatesWith = customerHandle,  -- add this line for explicit correlation
                CorrelatesOn = customerIDQuerySet,
                Content = ReceiveContent.Create(new OutArgument<Guid>())
            };


            // This will explicitly correlate with the SendReply action after the prescriptionRequest using the OrderID (stored in the orderHandle)
            Receive GetAdjustedCostRequest = new Receive
            {
                DisplayName = "Get Adjusted Cost",
                OperationName = "GetAdjustedCost",
                ServiceContractName = Constants.PharmacyServiceContractName,
                CanCreateInstance = true,
                CorrelatesOn = GetOrderIDQuerySet,
                CorrelatesWith = orderHandle,
                Content = ReceiveContent.Create(new OutArgument<Guid>())
            };


            Activity PrescriptonWorkflow = new Sequence()
            {
                Variables = { customer, order, drug, percentagePaidByInsurance, adjustedCost, customerHandle, orderHandle },
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Beginning Workflow"
                    },

                    new Parallel
                    {
                        Branches =
                        {
                            new Sequence
                            {
                                Activities = 
                                {
                                    GetInsurancePaymentPercentageRequest,
                                    new Assign<int>
                                    {
                                        To = new OutArgument<int>( (e) => percentagePaidByInsurance.Get(e) ),
                                        Value = new InArgument<int>( (e) => new Random().Next(0,100))
                                    },  
                                    new SendReply
                                    {
                                        DisplayName = "Return Percentage",
                                        Request = GetInsurancePaymentPercentageRequest,
                                        Content = SendContent.Create(new InArgument<int>((e) => percentagePaidByInsurance.Get(e)))
                                    }

                                }
                            },

                            new Sequence
                            {
                                Activities = 
                                {
                                    prescriptionRequest,
                                    new WriteLine
                                    { 
                                        Text = new InArgument<string>(env => (string.Format("{0}, {1}\t{2}", customer.Get(env).LastName ,customer.Get(env).FirstName,customer.Get(env).CustomerID.ToString())))
                                    },
                                    new Assign<Order>
                                    {
                                        To = new OutArgument<Order>(order),
                                        Value = new InArgument<Order>( (e) => new Order() { CustomerID = customer.Get(e).CustomerID, Drug = drug.Get(e), OrderID = Guid.NewGuid() } )
                                    },                                        
                                    new WriteLine
                                    { 
                                        Text = new InArgument<string>(env => (string.Format("OrderID: {0}", order.Get(env).OrderID.ToString())))
                                    },
                                    new Assign<int>
                                    {
                                        To = new OutArgument<int>( (e) => order.Get(e).Cost ),
                                        Value = new InArgument<int>( (e) => new Random().Next(20,50))
                                    },  
                                    // <Snippet0>
                                    new SendReply
                                    {
                                        DisplayName = "Send Adjusted Cost",
                                        Request = prescriptionRequest,
                                        // Initialize the orderHandle using the MessageQuerySet to correlate with the final GetAdjustedCost request
                                        CorrelationInitializers = 
                                        {
                                            // <Snippet1>
                                            new QueryCorrelationInitializer
                                            {
                                                CorrelationHandle = orderHandle,
                                                MessageQuerySet = GetOrderQuerySet
                                            }
                                            // </Snippet1>
                                        },
                                        Content = SendContent.Create(new InArgument<Order>((e) => order.Get(e)))
                                    }
                                    // </Snippet0>
                                }
                            }
                        }
                    },

                    new Assign<double>
                    {
                        To = new OutArgument<double>( (e) => adjustedCost.Get(e) ),
                        Value = new InArgument<double>( (e) => order.Get(e).Cost *  (100-percentagePaidByInsurance.Get(e)) *.01)
                    },
                    new WriteLine
                    { 
                        Text = new InArgument<string>(env => (string.Format("Base Cost: ${0}", order.Get(env).Cost.ToString())))
                    },
                    new WriteLine
                    { 
                        Text = new InArgument<string>(env => (string.Format("Insurance Coverage: {0}%", percentagePaidByInsurance.Get(env).ToString())))
                    },
                    new WriteLine
                    { 
                        Text = new InArgument<string>(env => (string.Format("Adjusted Cost: ${0}", decimal.Round(Convert.ToDecimal(adjustedCost.Get(env)),2))))
                    },
                    GetAdjustedCostRequest,
                    new SendReply
                    {
                        Request = GetAdjustedCostRequest,
                        Content = SendContent.Create(new InArgument<double>((e) => adjustedCost.Get(e)))
                    },
                    new WriteLine
                    {
                        Text = "Workflow Completed"
                    }

                }
            };

            WorkflowService service = new WorkflowService
            {
                Name = "PharmacyService",
                Body = PrescriptonWorkflow,
                ConfigurationName = "PharmacyService"
            };

            return service;

        }

        static void Main(string[] args)
        {
            Console.Title = "Service";
            Console.WriteLine("Starting up");

            System.ServiceModel.Activities.WorkflowServiceHost host = new WorkflowServiceHost(GetService());
            host.UnknownMessageReceived += new EventHandler<UnknownMessageReceivedEventArgs>(host_UnknownMessageReceived);

            host.Open();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            host.Close();
        }

        static void host_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            Debug.WriteLine("Oops, I received a message that didn't correlate!");
            Debug.WriteLine(e.Message.ToString());
        }
    }
}
