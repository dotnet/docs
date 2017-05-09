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
		// This example uses a cursor to step through the
		// message queues and list the public queues on the
		// network.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Output the count of Lowest priority messages.
			myNewQueue.ListPublicQueues();
						
			return;
		}


		//**************************************************
		// Iterates through message queues and examines the
		// path for each queue. Also displays the number of
		// public queues on the network.
		//**************************************************
		
		public void ListPublicQueues()
		{
			// Holds the count of private queues.
			uint numberQueues = 0;
	
			// Get a cursor into the queues on the network.
			MessageQueueEnumerator myQueueEnumerator = 
				MessageQueue.GetMessageQueueEnumerator();

			// Move to the next queue and read its path.
			while(myQueueEnumerator.MoveNext())
			{
				// Increase the count if priority is Lowest.
				Console.WriteLine(myQueueEnumerator.Current.Path);
				numberQueues++;
			}

			// Display final count.
			Console.WriteLine("Number of public queues: " + 
				numberQueues.ToString());
			
			return;
		}
	}
}
// </Snippet1>