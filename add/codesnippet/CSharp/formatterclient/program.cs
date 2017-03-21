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
        static Sequence ExpenseRequest(Endpoint endpoint)
        {
            Variable<Expense> mealExpense = new Variable<Expense>
            {
                Name = "mealExpense",
            };
            Variable<bool> result = new Variable<bool>
            {
                Name = "result"
            };

            Send approveExpense = new Send
            {
                ServiceContractName = XName.Get("FinanceService", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "ApproveExpense",
                Content = SendContent.Create(new InArgument<Expense>(mealExpense))
            };
            approveExpense.KnownTypes.Add(typeof(Travel));
            approveExpense.KnownTypes.Add(typeof(Meal));
//<Snippet1>
            Sequence workflow = new Sequence
            {
                Variables = { mealExpense, result },
                Activities =
                    {
                        new Assign<Expense>
                        {
                           Value = new InArgument<Expense>( (e) => new Meal { Amount = 50, Location = "Redmond", Vendor = "KFC" }),
                           To = new OutArgument<Expense>(mealExpense)
                        },
                        new WriteLine 
                        {
                            Text = new InArgument<string>("Hello")
                        },
                        approveExpense,
                        new ReceiveReply
                        {
                            Request = approveExpense,                            
                            Content = ReceiveContent.Create(new OutArgument<bool>(result))
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (result),
                           Then =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Expense Approved")
                                },
                           Else =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Expense Cannot be Approved")
                                },
                        },

                    }
            };
//</Snippet1>
            return workflow;
        }
        static Sequence PurchaseOrderRequest(Endpoint endpoint)
        {
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>
            {
                Name = "po"                
            };
            Variable<bool> result = new Variable<bool>
            {
                Name = "result"
            };

            Send approveExpense = new Send
            {
                ServiceContractName = XName.Get("FinanceService", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "ApprovePurchaseOrder",
                Content = SendContent.Create(new InArgument<PurchaseOrder>(po)),
                SerializerOption = SerializerOption.XmlSerializer
            };

            Sequence workflow = new Sequence
            {
                Variables = { po, result },
                Activities =
                    {
                        new Assign<PurchaseOrder>
                        {
                           Value = new InArgument<PurchaseOrder>( (e) => new PurchaseOrder { RequestedAmount = 500, Description = "New PC" }),
                           To = new OutArgument<PurchaseOrder>(po)
                        },
                        new WriteLine 
                        {
                            Text = new InArgument<string>("Hello")
                        },
                        approveExpense,
                        new ReceiveReply
                        {
                            Request = approveExpense,                            
                            Content = ReceiveContent.Create(new OutArgument<bool>(result))
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (result),
                           Then =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Purchase order Approved")
                                },
                           Else =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Purchase order Cannot be Approved")
                                },
                        },

                    }
            };
            return workflow;
        }
        static Sequence VendorApprovalRequest(Endpoint endpoint)
        {
            Variable<VendorRequest> vendor = new Variable<VendorRequest>
            {
                Name = "vendor",
            };
            Variable<VendorResponse> result = new Variable<VendorResponse>
            {
                Name = "result"
            };

            Send approvedVendor = new Send
            {
                ServiceContractName = XName.Get("FinanceService", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "ApprovedVendor",
                Content = SendContent.Create(new InArgument<VendorRequest>(vendor)),
            };

            Sequence workflow = new Sequence
            {
                Variables = { vendor, result },
                Activities =
                    {
                        new Assign<VendorRequest>
                        {
                           Value = new InArgument<VendorRequest>( (e) => new VendorRequest { Name = "Vendor1", requestingDepartment = "HR" }),
                           To = new OutArgument<VendorRequest>(vendor)
                        },
                        new WriteLine 
                        {
                            Text = new InArgument<string>("Hello")
                        },
                        approvedVendor,
                        new ReceiveReply
                        {
                            Request = approvedVendor,                            
                            Content = ReceiveContent.Create(new OutArgument<VendorResponse>(result))
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (env => result.Get(env).isPreApproved),
                           Then =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Vendor Approved")
                                },
                           Else =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Vendor is not Approved")
                                },
                        },

                    }
            };
            return workflow;
        }
        static void CreateClientWorkflow()
        {

            Endpoint endpoint = new Endpoint
            {
                AddressUri = new Uri(Constants.EchoServiceAddress),
                Binding = new BasicHttpBinding(),
            };
            workflow = new CorrelationScope
            {
                Body = new Sequence
                {
                    Activities =
                    {
                        ExpenseRequest(endpoint),
                        PurchaseOrderRequest(endpoint),
                        VendorApprovalRequest(endpoint)
                    }
                }
            };
        }
    }
}
