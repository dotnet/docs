
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    // Define the purchase order line item.
    [DataContract]
    public class PurchaseOrderLineItem
    {
        [DataMember]
        public string ProductId;

        [DataMember]
        public float UnitCost;

        [DataMember]
        public int Quantity;

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

    // Define the purchase order.
    [DataContract]
    public class PurchaseOrder
    {
        static readonly string[] OrderStates = { "Pending", "Processed", "Shipped" };
        static Random statusIndexer = new Random(137);

        [DataMember]
        public string PONumber;

        [DataMember]
        public string CustomerId;

        [DataMember]
        public PurchaseOrderLineItem[] orderLineItems;

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
                return OrderStates[statusIndexer.Next(3)];
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

    // Order Processing Logic
    // Can replace with transaction-aware resource such as SQL or transacted hashtable to hold the purchase orders.
    // This example uses a non-transactional resource.
    public class Orders
    {
        static Dictionary<string, PurchaseOrder> purchaseOrders = new Dictionary<string, PurchaseOrder>();

        public static void Add(PurchaseOrder po)
        {
            purchaseOrders.Add(po.PONumber, po);
        }

        public static string GetOrderStatus(string poNumber)
        {
            PurchaseOrder po;
            if (purchaseOrders.TryGetValue(poNumber, out po))
                return po.Status;
            else
                return null;
        }

        public static void DeleteOrder(string poNumber)
        {
            if (purchaseOrders[poNumber] != null)
                purchaseOrders.Remove(poNumber);
        }
    }

    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true)]
        void SubmitPurchaseOrder(PurchaseOrder po);
    }

    // Service class that implements the service contract.
    // Added code to write output to the console window
    [PoisonErrorBehavior(typeof(PoisonErrorHandler))]
    public class OrderProcessorService : IOrderProcessor
    {
        static Random r = new Random(137);

        // <Snippet4>
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(PurchaseOrder po)
        {
            // <Snippet1>
            MsmqMessageProperty mqProp = OperationContext.Current.IncomingMessageProperties[MsmqMessageProperty.Name] as MsmqMessageProperty;
            Console.WriteLine("Abort count: {0} ", mqProp.AbortCount);
            Console.WriteLine("Move count: {0} ", mqProp.MoveCount);
            // code to submit purchase order ...
            // </Snippet1>

            int randomNumber = r.Next(10);

            if (randomNumber % 2 == 0)
            {
                Orders.Add(po);
                Console.WriteLine("Processing {0} ", po);
            }
            else
            {
                Console.WriteLine("Aborting transaction, cannot process purchase order: " + po.PONumber);
                Console.WriteLine();
                throw new Exception("Cannot process purchase order: " + po.PONumber);
            }
        }
        // </Snippet4>
    }
}
