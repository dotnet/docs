// <Snippet1>
using System;
using System.Messaging;

namespace MyProject
{

	// This class represents an object the following example 
	// sends to a queue and receives from a queue.
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
		// This example sends and receives a message from
		// a queue.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Send a message to a queue.
			myNewQueue.SendMessage();

			// Receive a message from a queue.
			myNewQueue.ReceiveMessage();

			return;
		}


		//**************************************************
		// Sends an Order to a queue.
		//**************************************************
		
		public void SendMessage()
		{
			
			// Create a new order and set values.
			Order sentOrder = new Order();
			sentOrder.orderId = 3;
			sentOrder.orderTime = DateTime.Now;

			// Connect to a queue on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Send the Order to the queue.
			myQueue.Send(sentOrder);

			return;
		}


		//**************************************************
		// Receives a message containing an Order.
		//**************************************************
		
		public  void ReceiveMessage()
		{
			// Connect to the a queue on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Set the formatter to indicate body contains an Order.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(MyProject.Order)});
			
			try
			{
				// Receive and format the message. 
				Message myMessage =	myQueue.Receive(); 
				Order myOrder = (Order)myMessage.Body;

				// Display message information.
				Console.WriteLine("Order ID: " + 
					myOrder.orderId.ToString());
				Console.WriteLine("Sent: " + 
					myOrder.orderTime.ToString());
			}
			
			catch (MessageQueueException)
			{
				// Handle Message Queuing exceptions.
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