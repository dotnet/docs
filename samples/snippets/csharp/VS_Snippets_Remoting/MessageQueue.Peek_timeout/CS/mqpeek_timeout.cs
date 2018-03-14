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
		// This example determines whether a queue is empty.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Determine whether a queue is empty.
			bool isQueueEmpty = myNewQueue.IsQueueEmpty();
						
			return;
		}


		//**************************************************
		// Determines whether a queue is empty. The Peek()
		// method throws an exception if there is no message
		// in the queue. This method handles that exception 
		// by returning true to the calling method.
		//**************************************************
		
		public bool IsQueueEmpty()
		{
			bool isQueueEmpty = false;

			// Connect to a queue.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			try
			{
				// Set Peek to return immediately.
				myQueue.Peek(new TimeSpan(0));

				// If an IOTimeout was not thrown, there is a message 
				// in the queue.
				isQueueEmpty = false;
			}

			catch(MessageQueueException e)
			{
				if (e.MessageQueueErrorCode == 
					MessageQueueErrorCode.IOTimeout)
				{
					// No message was in the queue.
					isQueueEmpty = true;
				}

				// Handle other sources of MessageQueueException.
			}

			// Handle other exceptions as necessary.

			// Return true if there are no messages in the queue.
			return isQueueEmpty;

		}
	}
}
// </Snippet1>