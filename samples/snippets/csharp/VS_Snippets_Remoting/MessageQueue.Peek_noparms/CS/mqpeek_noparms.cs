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
		// This example posts a notification that a message
		// has arrived in a queue. It sends a message 
		// containing an other to a separate queue, and then
		// peeks the first message in the queue.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Wait for a message to arrive in the queue.
			myNewQueue.NotifyArrived();

			// Send a message to a queue.
			myNewQueue.SendMessage();	

			// Peek the first message in the queue.
			myNewQueue.PeekFirstMessage();
						
			return;
		}


		//**************************************************
		// Posts a notification when a message arrives in 
		// the queue "monitoredQueue". Does not retrieve any 
		// message information when peeking the message.
		//**************************************************
		
		public void NotifyArrived()
		{

			// Connect to a queue.
			MessageQueue myQueue = new 
				MessageQueue(".\\monitoredQueue");
	
			// Specify to retrieve no message information.
			myQueue.MessageReadPropertyFilter.ClearAll();

			// Wait for a message to arrive. 
			Message emptyMessage = myQueue.Peek();

			// Post a notification when a message arrives.
			Console.WriteLine("A message has arrived in the queue.");

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
		// Peeks a message containing an Order.
		//**************************************************
		
		public void PeekFirstMessage()
		{
			// Connect to a queue.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");
	
			// Set the formatter to indicate the body contains an Order.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(MyProject.Order)});
			
			try
			{
				// Peek and format the message. 
				Message myMessage =	myQueue.Peek(); 
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