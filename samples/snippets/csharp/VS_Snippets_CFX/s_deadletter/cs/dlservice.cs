
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
// <Snippet3>
using System;
using System.ServiceModel.Description;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Transactions;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true)]
        void SubmitPurchaseOrder(PurchaseOrder po);
    }

    // Service class that implements the service contract.
    // Added code to write output to the console window
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class PurchaseOrderDLQService : IOrderProcessor
    {
        OrderProcessorClient orderProcessorService;
        public PurchaseOrderDLQService()
        {
            orderProcessorService = new OrderProcessorClient("OrderProcessorEndpoint");
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        // <Snippet0>
        public void SimpleSubmitPurchaseOrder(PurchaseOrder po)
        {
            Console.WriteLine($"Submitting purchase order did not succeed ");
            MsmqMessageProperty mqProp = OperationContext.Current.IncomingMessageProperties[MsmqMessageProperty.Name] as MsmqMessageProperty;

            Console.WriteLine($"Message Delivery Status: {mqProp.DeliveryStatus} ");
            Console.WriteLine($"Message Delivery Failure: {mqProp.DeliveryFailure}");
            Console.WriteLine();
        }
        // </Snippet0>

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(PurchaseOrder po)
        {
            Console.WriteLine($"Submitting purchase order did not succeed ");
            MsmqMessageProperty mqProp = OperationContext.Current.IncomingMessageProperties[MsmqMessageProperty.Name] as MsmqMessageProperty;

            Console.WriteLine($"Message Delivery Status: {mqProp.DeliveryStatus} ");
            Console.WriteLine($"Message Delivery Failure: {mqProp.DeliveryFailure}");
            Console.WriteLine();

            // Resend the message if timed out.
            if (mqProp.DeliveryFailure == DeliveryFailure.ReachQueueTimeout ||
                mqProp.DeliveryFailure == DeliveryFailure.ReceiveTimeout)
            {
                // Re-send.
                Console.WriteLine("Purchase order Time To Live expired");
                Console.WriteLine("Trying to resend the message");

                // Reuse the same transaction used to read the message from dlq to enqueue the message to the application queue.
                orderProcessorService.SubmitPurchaseOrder(po);
                Console.WriteLine("Purchase order resent");
            }
        }

        // Host the service within this EXE console application.
        public static void Main()
        {
            // Create a ServiceHost for the PurchaseOrderDLQService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(PurchaseOrderDLQService)))
            {
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The dead letter service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
        }
    }
}
// </Snippet3>
