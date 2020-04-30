
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
// <Snippet1>
// Service Code:

using System;

using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;
using System.Text;
using System.Collections.Generic;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", SessionMode=SessionMode.Required)]
    public interface IOrderTaker
    {
        [OperationContract(IsOneWay = true)]
        void OpenPurchaseOrder(string customerId);

        [OperationContract(IsOneWay = true)]
        void AddProductLineItem(string productId, int quantity);

        [OperationContract(IsOneWay = true)]
        void EndPurchaseOrder();
    }

    // Define the Purchase Order Line Item
    public class PurchaseOrderLineItem
    {
        static Random r = new Random(137);

        string ProductId;
        float UnitCost;
        int Quantity;

        public PurchaseOrderLineItem(string productId, int quantity)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitCost = r.Next(10000);
        }

        public override string ToString()
        {
            String displayString = "Order LineItem: " + Quantity + " of " + ProductId + " @unit price: $" + UnitCost + "\n";
            return displayString;
        }

        public float TotalCost
        {
            get { return UnitCost * Quantity; }
        }
    }

    // Define Purchase Order
    public class PurchaseOrder
    {
        string PONumber;
        string CustomerId;
        LinkedList<PurchaseOrderLineItem> orderLineItems = new LinkedList<PurchaseOrderLineItem>();

        public PurchaseOrder(string customerId)
        {
            this.CustomerId = customerId;
            this.PONumber = Guid.NewGuid().ToString();
        }

        public void AddProductLineItem(string productId, int quantity)
        {
            orderLineItems.AddLast(new PurchaseOrderLineItem(productId, quantity));
        }

        public float TotalCost
        {
            get
            {
                float totalCost = 0;
                foreach (PurchaseOrderLineItem lineItem in orderLineItems)
                    totalCost += lineItem.TotalCost;
                return totalCost;
            }
        }

        public string Status
        {
            get
            {
                return "Pending";
            }
        }

        public override string ToString()
        {
            StringBuilder strbuf = new StringBuilder("Purchase Order: " + PONumber + "\n");
            strbuf.Append("\tCustomer: " + CustomerId + "\n");
            strbuf.Append("\tOrderDetails\n");

            foreach (PurchaseOrderLineItem lineItem in orderLineItems)
            {
                strbuf.Append("\t\t" + lineItem.ToString());
            }

            strbuf.Append("\tTotal cost of this order: $" + TotalCost + "\n");
            strbuf.Append("\tOrder status: " + Status + "\n");
            return strbuf.ToString();
        }
    }

    // Service class which implements the service contract.
    // Added code to write output to the console window
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class OrderTakerService : IOrderTaker
    {
        PurchaseOrder po;

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void OpenPurchaseOrder(string customerId)
        {
            Console.WriteLine("Creating purchase order");
            po = new PurchaseOrder(customerId);
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void AddProductLineItem(string productId, int quantity)
        {
            po.AddProductLineItem(productId, quantity);
            Console.WriteLine("Product " + productId + " quantity " + quantity + " added to purchase order");
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void EndPurchaseOrder()
        {
            Console.WriteLine("Purchase Order Completed");
            Console.WriteLine();
            Console.WriteLine(po.ToString());
        }

        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get MSMQ queue name from app settings in configuration
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Get the base address that is used to listen for WS-MetaDataExchange requests
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            // Create a ServiceHost for the OrderTakerService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(OrderTakerService), new Uri(baseAddress)))
            {
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
        }
    }
}
// </Snippet1>