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
		// This example connects to a message queue, and
		// requests exclusive read access to the queue.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Output the count of Lowest priority messages.
			myNewQueue.GetExclusiveAccess();
						
			return;
		}


		//**************************************************
		// Requests exlusive read access to the queue. If
		// access is granted, receives a message from the 
		// queue.
		//**************************************************
		
		public void GetExclusiveAccess()
		{
			try
			{
				// Request exclusive read access to the queue.
				MessageQueue myQueue = new 
					MessageQueue(".\\myQueue", true);

				// Receive a message. This is where SharingViolation 
				// exceptions would be thrown.
				Message myMessage = myQueue.Receive();
			}
			
			catch (MessageQueueException e)
			{
				// Handle request for denial of exclusive read access.
				if (e.MessageQueueErrorCode == 
					MessageQueueErrorCode.SharingViolation)
				{
					Console.WriteLine("Denied exclusive read access");
				}

				// Handle other sources of a MessageQueueException.
			}

			// Handle other exceptions as necessary.

			return;
		}
	}
}
// </Snippet1>