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
		// This example closes a queue and frees its 
		// resources.
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
		// Sends a message to a queue.
		//**************************************************
		
		public void SendMessage()
		{
			// Connect to a queue on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Send a message to the queue.
			myQueue.Send("My message data1.");
			
			// Explicitly release resources.
			myQueue.Close();

			// Attempt to reacquire resources.
			myQueue.Send("My message data2.");

			return;
		}


		//**************************************************
		// Receives a message from a queue.
		//**************************************************
		
		public  void ReceiveMessage()
		{
			// Connect to the a on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Set the formatter to indicate body contains an Order.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(String)});
			
			try
			{
				// Receive and format the message. 
				Message myMessage1 = myQueue.Receive();
				Message myMessage2 = myQueue.Receive();
			}
			
			catch (MessageQueueException)
			{
				// Handle sources of any MessageQueueException.
			}

			// Catch other exceptions as necessary.

			finally
			{
				// Free resources.
				myQueue.Close();
			}

			return;
		}
	}
}
// </Snippet1>