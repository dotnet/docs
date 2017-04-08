// <Snippet1>
using System;
using System.Messaging;

namespace MyProject
{
	// This class represents an object the following example 
	// receives from a queue.

	public class Order
	{
		public int orderId;
		public DateTime orderTime;
	};	

	/// <summary>
	/// Provides a container class for the example.
	/// </summary>
	public class MyNewQueue
	{

		//**************************************************
		// Provides an entry point into the application.
		//		 
		// This example receives a message from a queue.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Receive a message from a queue.
			myNewQueue.ReceiveMessage();

			return;
		}


		//**************************************************
		// Receives a message containing an Order.
		//**************************************************

		public void ReceiveMessage()
		{
			// Connect to the a queue on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Set the formatter to indicate body contains an Order.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(MyProject.Order)});
			
			try
			{
				// Receive and format the message. 
				// Wait 5 seconds for a message to arrive.
				Message myMessage =	myQueue.Receive(new 
					TimeSpan(0,0,5)); 
				Order myOrder = (Order)myMessage.Body;

				// Display message information.
				Console.WriteLine("Order ID: " + 
					myOrder.orderId.ToString());
				Console.WriteLine("Sent: " + 
					myOrder.orderTime.ToString());
			}

			catch (MessageQueueException e)
			{
				// Handle no message arriving in the queue.
				if (e.MessageQueueErrorCode == 
					MessageQueueErrorCode.IOTimeout)
				{
					Console.WriteLine("No message arrived in queue.");
				}			

				// Handle other sources of a MessageQueueException.
			}
			
			// Handle invalid serialization format.
			catch (InvalidOperationException e)
			{
				Console.WriteLine(e.Message);
			}
			
			// Catch other exceptions as necessary.

			return;
		}
	}
}
// </Snippet1>