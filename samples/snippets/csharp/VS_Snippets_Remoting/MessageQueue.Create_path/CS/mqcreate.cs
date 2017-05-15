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
		// This example creates new public and private 
		// queues.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Create public and private queues.
			myNewQueue.CreatePublicQueues();
			myNewQueue.CreatePrivateQueues();

			return;
		}


		//**************************************************
		// Creates public queues and sends a message.
		//**************************************************
		
		public void CreatePublicQueues()
		{

			// Create and connect to a public Message Queuing queue.
			if (!MessageQueue.Exists(".\\newPublicQueue"))
			{
				// Create the queue if it does not exist.
				MessageQueue myNewPublicQueue = 
					MessageQueue.Create(".\\newPublicQueue");

				// Send a message to the queue.
				myNewPublicQueue.Send("My message data.");
			}

			// Create (but do not connect to) a second public queue.
			if (!MessageQueue.Exists(".\\newPublicResponseQueue"))
			{
				MessageQueue.Create(".\\newPublicResponseQueue");
			}

			return;

		}


		//**************************************************
		// Creates private queues and sends a message.
		//**************************************************
		
		public void CreatePrivateQueues()
		{

			// Create and connect to a private Message Queuing queue.
			if (!MessageQueue.Exists(".\\Private$\\newPrivQueue"))
			{
				// Create the queue if it does not exist.
				MessageQueue myNewPrivateQueue = 
					MessageQueue.Create(".\\Private$\\newPrivQueue");

				// Send a message to the queue.
				myNewPrivateQueue.Send("My message data.");
			}

			// Create (but do not connect to) a second private queue.
			if (!MessageQueue.Exists(".\\Private$\\newResponseQueue"))
			{
				MessageQueue.Create(".\\Private$\\newResponseQueue");
			}
		
			return;
		}
	}
}
// </Snippet1>