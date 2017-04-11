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
		// network that specify certain criteria.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Output the count of Lowest priority messages.
			myNewQueue.ListPublicQueuesByCriteria();
						
			return;
		}


		//**************************************************
		// Iterates through message queues and displays the
		// path of each queue that was created in the last
		// day and that exists on the computer "MyComputer". 
		//**************************************************
		
		public void ListPublicQueuesByCriteria()
		{
			uint numberQueues = 0;
			
			// Specify the criteria to filter by.
			MessageQueueCriteria myCriteria = new 
				MessageQueueCriteria();
			myCriteria.MachineName = "MyComputer";
			myCriteria.CreatedAfter = DateTime.Now.Subtract(new 
				TimeSpan(1,0,0,0));
	

			// Get a cursor into the queues on the network.
			MessageQueueEnumerator myQueueEnumerator = 
				MessageQueue.GetMessageQueueEnumerator(myCriteria);

			// Move to the next queue and read its path.
			while(myQueueEnumerator.MoveNext())
			{
				// Increase the count if priority is Lowest.
				Console.WriteLine(myQueueEnumerator.Current.Path);
				numberQueues++;
			}

			// Handle no queues matching the criteria.
			if (numberQueues == 0)
			{
				Console.WriteLine("No public queues match criteria.");
			}

			return;
		}
	}
}
// </Snippet1>