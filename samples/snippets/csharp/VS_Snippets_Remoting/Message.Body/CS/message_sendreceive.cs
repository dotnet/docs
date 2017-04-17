// <Snippet1>
using System;
using System.Messaging;
using System.Drawing;
using System.IO;

namespace MyProject
{

	// The following example 
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

			// Create a queue on the local computer.
			CreateQueue(".\\myQueue");
			
			// Send a message to a queue.
			myNewQueue.SendMessage();

			// Receive a message from a queue.
			myNewQueue.ReceiveMessage();

			return;
		}

		//**************************************************
		// Creates a new queue.
		//**************************************************

		public static void CreateQueue(string queuePath)
		{
			try	
			{
				if(!MessageQueue.Exists(queuePath))
				{
					MessageQueue.Create(queuePath);
				}
				else
				{
					Console.WriteLine(queuePath + " already exists.");
				}
			}
			catch (MessageQueueException e)
			{
				Console.WriteLine(e.Message);
			}
			
		}

		//**************************************************
		// Sends an Order to a queue.
		//**************************************************
		
		public void SendMessage()
		{
			try
			{

				// Create a new order and set values.
				Order sentOrder = new Order();
				sentOrder.orderId = 3;
				sentOrder.orderTime = DateTime.Now;

				// Connect to a queue on the local computer.
				MessageQueue myQueue = new MessageQueue(".\\myQueue");


				
				// Create the new order.
				Message myMessage = new Message(sentOrder);

				// Send the order to the queue.
				myQueue.Send(myMessage);
			}
			catch(ArgumentException e)
			{
				Console.WriteLine(e.Message);
			
			}

			return;
		}


		//**************************************************
		// Receives a message containing an order.
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