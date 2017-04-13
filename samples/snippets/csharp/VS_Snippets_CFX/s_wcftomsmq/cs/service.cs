
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;
using System.Configuration;

namespace Microsoft.ServiceModel.Samples
{
	class Program
	{
		static void Main(string[] args)
		{
	
			// Create a transaction queue using System.Messaging API
			// You can also choose to not do this and instead create the
			// queue using MSMQ MMC. Make sure you create a transactional queue.

            if (!MessageQueue.Exists(ConfigurationManager.AppSettings["queueName"]))
				MessageQueue.Create(ConfigurationManager.AppSettings["queueName"], true);

			//Connect to the queue.
			MessageQueue Queue = new MessageQueue(ConfigurationManager.AppSettings["queueName"]);

			Queue.ReceiveCompleted += new ReceiveCompletedEventHandler(ProcessOrder);
			Queue.BeginReceive();
			Console.WriteLine("Order Service is running");
			Console.ReadLine();
		}

		public static void ProcessOrder(Object source,ReceiveCompletedEventArgs asyncResult)
		{
			try
			{
				// Connect to the queue.
				MessageQueue Queue = (MessageQueue)source;
				// End the asynchronous receive operation.
				System.Messaging.Message msg = Queue.EndReceive(asyncResult.AsyncResult);
				msg.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(PurchaseOrder) });
				PurchaseOrder po = (PurchaseOrder) msg.Body;
                Random statusIndexer = new Random();
                po.Status = (OrderStates)statusIndexer.Next(3);
                Console.WriteLine("Processing {0} ", po);
				Queue.BeginReceive();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
