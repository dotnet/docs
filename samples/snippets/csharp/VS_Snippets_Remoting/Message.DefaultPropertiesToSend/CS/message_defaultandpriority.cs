// <Snippet1>
using System;
using System.Messaging;

namespace MyProject
{

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

			// Send messages to a queue.
			myNewQueue.SendMessage(MessagePriority.Normal, "First Message Body.");
			myNewQueue.SendMessage(MessagePriority.Highest, "Second Message Body.");

			// Receive messages from a queue.
			myNewQueue.ReceiveMessage(); 
			myNewQueue.ReceiveMessage();

			return;
		}


		//**************************************************
		// Sends a string message to a queue.
		//**************************************************
		
		public void SendMessage(MessagePriority priority, string messageBody)
		{

			// Connect to a queue on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Create a new message.
			Message myMessage = new Message();

			if(priority > MessagePriority.Normal)
			{
				myMessage.Body = "High Priority: " + messageBody;
			}
			else myMessage.Body = messageBody;

			// Set the priority of the message.
			myMessage.Priority = priority;


			// Send the Order to the queue.
			myQueue.Send(myMessage);

			return;
		}


		//**************************************************
		// Receives a message.
		//**************************************************
		
		public  void ReceiveMessage()
		{
			// Connect to the a queue on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Set the queue to read the priority. By default, it
			// is not read.
			myQueue.MessageReadPropertyFilter.Priority = true;

			// Set the formatter to indicate body contains a string.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(string)});
			
			try
			{
				// Receive and format the message. 
				Message myMessage =	myQueue.Receive(); 

				// Display message information.
				Console.WriteLine("Priority: " + 
					myMessage.Priority.ToString());
				Console.WriteLine("Body: " + 
					myMessage.Body.ToString());
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