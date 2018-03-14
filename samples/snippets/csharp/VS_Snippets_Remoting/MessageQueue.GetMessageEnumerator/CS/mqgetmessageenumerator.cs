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
		// messages in a queue and counts the number of 
		// Lowest priority messages.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Output the count of Lowest priority messages.
			myNewQueue.CountLowestPriority();
						
			return;
		}


		//**************************************************
		// Iterates through messages in a queue and examines
		// their priority.
		//**************************************************
		
		public void CountLowestPriority()
		{
			// Holds the count of Lowest priority messages.
			uint numberItems = 0;

			// Connect to a queue.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");
	
			// Get a cursor into the messages in the queue.
			MessageEnumerator myEnumerator = 
				myQueue.GetMessageEnumerator();

			// Specify that the messages's priority should be read.
			myQueue.MessageReadPropertyFilter.Priority = true;

			// Move to the next message and examine its priority.
			while(myEnumerator.MoveNext())
			{
				// Increase the count if priority is Lowest.
				if(myEnumerator.Current.Priority == 
					MessagePriority.Lowest)
					
					numberItems++;
			}

			// Display final count.
			Console.WriteLine("Lowest priority messages: " + 
				numberItems.ToString());
			
			return;
		}
	}
}
// </Snippet1>