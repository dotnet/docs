
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
//  add main
//  using System.Security.Principal;

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.MsmqIntegration;
using System.Runtime.Serialization;
using System.Configuration;
using System.Messaging;
using System.Security.Principal;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    // <Snippet1>
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    [ServiceKnownType(typeof(PurchaseOrder))]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg);
    }
    // </Snippet1>

    // Service class that implements the service contract.
    // Added code to write output to the console window.
    // <Snippet2>
    public class OrderProcessorService : IOrderProcessor
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> ordermsg)
        {
            PurchaseOrder po = (PurchaseOrder)ordermsg.Body;
            Random statusIndexer = new Random();
            po.Status = (OrderStates)statusIndexer.Next(3);
            Console.WriteLine($"Processing {po} ");
        }

	    // Host the service within this EXE console application.
	public static void Main()
	{
	    // Get base address from appsettings in configuration.
		Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);

	    // Create a ServiceHost for the CalculatorService type and provide the base address.
		using (ServiceHost serviceHost = new ServiceHost(typeof(IOrderProcessor), baseAddress))
		{
		// Open the ServiceHostBase to create listeners and start listening for messages.
			serviceHost.Open();

		// The service can now be accessed.
			Console.WriteLine("The service is ready.");
			Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name);
			Console.WriteLine("Press <ENTER> to terminate service.");
			Console.WriteLine();
			Console.ReadLine();

		// Close the ServiceHostBase to shutdown the service.
			serviceHost.Close();
		}
	}
    }
    // </Snippet2>
}
