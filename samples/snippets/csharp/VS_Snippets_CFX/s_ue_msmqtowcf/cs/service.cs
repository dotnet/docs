
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.MsmqIntegration;
using System.Runtime.Serialization;
using System.Configuration;
using System.Messaging;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract. 
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    [ServiceKnownType(typeof(PurchaseOrder))]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg);
    }

    // Service class that implements the service contract.
    // Added code to write output to the console window
    public class OrderProcessorService : IOrderProcessor
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> ordermsg)
        {
            PurchaseOrder po = (PurchaseOrder)ordermsg.Body;
            Random statusIndexer = new Random();
            po.Status = (OrderStates)statusIndexer.Next(3);
            Console.WriteLine("Processing {0} ", po);          
        }

        // Host the service within this EXE console application.
        public static void Main()
        {
            Snippets.Snippet6();
            
            // <Snippet0>
            // Get MSMQ queue name from appsettings in configuration.
            string queueName = @".\private$\Orders";

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService)))
            {
                
                // <Snippet2>
                // <Snippet1>
                MsmqIntegrationBindingElement msmqBindingElement = new MsmqIntegrationBindingElement();
                // </Snippet1>

                String strScheme = msmqBindingElement.Scheme;
                Console.WriteLine("Scheme = " + strScheme);
                // </Snippet2>

                Type[] types = msmqBindingElement.TargetSerializationTypes;
                
                CustomBinding binding = new CustomBinding(msmqBindingElement);


                serviceHost.AddServiceEndpoint(typeof(IOrderProcessor), binding, @"msmq.formatname:DIRECT=OS:.\private$\Orders");

                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
            }
            // </Snippet0>
           
        }  
    }
}

