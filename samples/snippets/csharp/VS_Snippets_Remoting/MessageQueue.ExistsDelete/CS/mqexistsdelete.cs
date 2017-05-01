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
		// This example verifies existence and attempts to 
		// delete a queue.
		//**************************************************

		public static void Main()
		{

			// Determine whether the queue exists.
			if (MessageQueue.Exists(".\\myQueue"))
			{
				try
				{
					// Delete the queue.
					MessageQueue.Delete(".\\myQueue");
				}
				catch(MessageQueueException e)
				{
					if(e.MessageQueueErrorCode == 
						MessageQueueErrorCode.AccessDenied)
					{
						Console.WriteLine("Access is denied. " + 
							"Queue might be a system queue.");
					}

					// Handle other sources of MessageQueueException.
				}

			}
		
			return;
		}

	}
}
// </Snippet1>