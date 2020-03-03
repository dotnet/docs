using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel.Activities;
using System.ServiceModel;
using System.Collections.Generic;
using System.ServiceModel.Description;

namespace ContentCorrelationDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            HostContentCorrelation();
        }

        private static void HostContentCorrelation()
        {
            Activity wf = GetCCWorkflowWithInitializeCorrelationActivity(); // GetCCWorkflow();

            string baseAddress = "http://localhost:8080/OrderService";

            using (WorkflowServiceHost host = new WorkflowServiceHost(wf, new Uri(baseAddress)))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
                sdb.IncludeExceptionDetailInFaults = true;

                // Unneeded using ZeroConfig
                //host.AddServiceEndpoint(OrderContractName, Binding2, Service1Address);

                host.Open();
                Console.WriteLine("Service waiting at: " + baseAddress);
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
                host.Close();
            }
        }

        private static Activity GetCCWorkflowWithInitializeCorrelationActivity()
        {
            //<snippet4>
            Variable<string> OrderId = new Variable<string>();
            Variable<string> Item = new Variable<string>();
            Variable<CorrelationHandle> OrderIdHandle = new Variable<CorrelationHandle>();

            InitializeCorrelation OrderIdCorrelation = new InitializeCorrelation
            {
                Correlation = OrderIdHandle,
                CorrelationData = { { "OrderId", new InArgument<string>(OrderId) } }
            };

            Receive StartOrder = new Receive
            {
                CanCreateInstance = true,
                ServiceContractName = "IOrderService",
                OperationName = "StartOrder"
            };

            SendReply ReplyToStartOrder = new SendReply
            {
                Request = StartOrder,
                Content = SendParametersContent.Create(new Dictionary<string, InArgument> { { "OrderId", new InArgument<string>((env) => OrderId.Get(env)) } }),
            };

            // Other messaging activities omitted...
            //</snippet4>

            Receive AddItem = new Receive
            {
                ServiceContractName = "IOrderService",
                OperationName = "AddItem",
                CorrelatesWith = OrderIdHandle,
                CorrelatesOn = new MessageQuerySet
                {
                    {
                        "OrderId", 
                          new XPathMessageQuery("sm:body()/tempuri:AddItem/tempuri:OrderId")
                    }
                },
                Content = ReceiveParametersContent.Create(new Dictionary<string, OutArgument>
                    { { "OrderId", new OutArgument<string>(OrderId) },  
                    { "Item", new OutArgument<string>(Item) } })
            };

            SendReply ReplyToAddItem = new SendReply
            {
                Request = AddItem,
                Content = SendParametersContent.Create(new Dictionary<string, InArgument> { { "Reply", new InArgument<string>((env) => "Item added: " + Item.Get(env)) } }),
            };

            //<snippet5>
            // Construct a workflow using OrderIdCorrelation, StartOrder, ReplyToStartOrder,
            // and other messaging activities.
            Activity wf = new Sequence
            {
                Variables =
                {
                    OrderId,
                    Item,
                    OrderIdHandle
                },
                Activities =
                {
                    // Wait for a new order.
                    StartOrder,
                    // Assign a unique identifier to the order.
                    new Assign<string>
                    {
                        To = new OutArgument<string>( (env) => OrderId.Get(env)),
                        Value = new InArgument<string>( (env) => Guid.NewGuid().ToString() )
                    },
                    ReplyToStartOrder,
                    // Initialize the correlation.
                    OrderIdCorrelation,
                    // Wait for an item to be added to the order.
                    AddItem,
                    ReplyToAddItem
                 }
            };
            //</snippet5>

            return wf;
        }

        private static Activity GetCCWorkflow()
        {
            //<snippet1>
            Variable<string> OrderId = new Variable<string>();
            Variable<string> Item = new Variable<string>();
            Variable<CorrelationHandle> OrderIdHandle = new Variable<CorrelationHandle>();

            Receive StartOrder = new Receive
            {
                CanCreateInstance = true,
                ServiceContractName = "IOrderService",
                OperationName = "StartOrder"
            };

            //<snippet2>
            SendReply ReplyToStartOrder = new SendReply
            {
                Request = StartOrder,
                Content = SendParametersContent.Create(new Dictionary<string, InArgument>
                    { { "OrderId", new InArgument<string>((env) => OrderId.Get(env)) } }),
                CorrelationInitializers =
                {
                    new QueryCorrelationInitializer
                    {
                        CorrelationHandle = OrderIdHandle,
                        MessageQuerySet = new MessageQuerySet
                        {
                            {
                                "OrderId", 
                                new XPathMessageQuery("sm:body()/tempuri:StartOrderResponse/tempuri:OrderId")
                            }
                        }
                    }
                }
            };
            //</snippet2>

            //<snippet3>
            Receive AddItem = new Receive
            {
                ServiceContractName = "IOrderService",
                OperationName = "AddItem",
                CorrelatesWith = OrderIdHandle,
                CorrelatesOn = new MessageQuerySet
                {
                    {
                        "OrderId", 
                          new XPathMessageQuery("sm:body()/tempuri:AddItem/tempuri:OrderId")
                    }
                },
                Content = ReceiveParametersContent.Create(new Dictionary<string, OutArgument>
                    { { "OrderId", new OutArgument<string>(OrderId) },  
                    { "Item", new OutArgument<string>(Item) } })
            };
            //</snippet3>

            SendReply ReplyToAddItem = new SendReply
            {
                Request = AddItem,
                Content = SendParametersContent.Create(new Dictionary<string, InArgument>
                    { { "Reply", new InArgument<string>((env) => "Item added: " + Item.Get(env)) } }),
            };

            // Construct a workflow using StartOrder, ReplyToStartOrder, and AddItem.
            //</snippet1>
            Activity wf = new Sequence
            {
                Variables =
                {
                    OrderId,
                    Item,
                    OrderIdHandle
                },
                Activities =
                {
                    StartOrder,
                    new Assign<string>
                    {
                        To = new OutArgument<string>( (env) => OrderId.Get(env)),
                        Value = new InArgument<string>( (env) => Guid.NewGuid().ToString() )
                    },
                    ReplyToStartOrder,
                    AddItem,
                    ReplyToAddItem
                 }
            };

            return wf;
        }
    }
}
