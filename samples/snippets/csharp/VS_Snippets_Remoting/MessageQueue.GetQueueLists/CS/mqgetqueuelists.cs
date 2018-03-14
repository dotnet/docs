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
		// This example gets lists of queues by a variety
		// of criteria.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Send normal and high priority messages.
			myNewQueue.GetQueuesByCategory();
			myNewQueue.GetQueuesByLabel();
			myNewQueue.GetQueuesByComputer();
			myNewQueue.GetAllPublicQueues();
			myNewQueue.GetPublicQueuesByCriteria();
			myNewQueue.GetPrivateQueues();
						
			return;
		}


		//**************************************************
		// Gets a list of queues with a specified category.
		// Sends a broadcast message to all queues in that
		// category.
		//**************************************************
		
		public void GetQueuesByCategory()
		{
			// Get a list of queues with the specified category.
			MessageQueue[] QueueList = 
				MessageQueue.GetPublicQueuesByCategory(new 
				Guid("{00000000-0000-0000-0000-000000000001}"));

			// Send a broadcast message to each queue in the array.
			foreach(MessageQueue queueItem in QueueList)
			{
				queueItem.Send("Broadcast message.");
			}
			
			return;
		}


		//**************************************************
		// Gets a list of queues with a specified label.
		// Sends a broadcast message to all queues with that
		// label.
		//**************************************************
		
		public void GetQueuesByLabel()
		{
			// Get a list of queues with the specified label.
			MessageQueue[] QueueList = 
				MessageQueue.GetPublicQueuesByLabel("My Label");

			// Send a broadcast message to each queue in the array.
			foreach(MessageQueue queueItem in QueueList)
			{
				queueItem.Send("Broadcast message.");
			}
			
			return;
		}


		//**************************************************
		// Gets a list of queues on a specified computer. 
		// Displays the list on screen.
		//**************************************************
		
		public void GetQueuesByComputer()
		{
			// Get a list of queues on the specified computer.
			MessageQueue[] QueueList = 
				MessageQueue.GetPublicQueuesByMachine("MyComputer");

			// Display the paths of the queues in the list.
			foreach(MessageQueue queueItem in QueueList)
			{
				Console.WriteLine(queueItem.Path);
			}

			return;
		}


		//**************************************************
		// Gets a list of all public queues.
		//**************************************************
		
		public void GetAllPublicQueues()
		{
			// Get a list of public queues.
			MessageQueue[] QueueList = 
				MessageQueue.GetPublicQueues();
	
			return;
		}


		//**************************************************
		// Gets a list of all public queues that match 
		// specified criteria. Displays the list on 
		// screen.
		//**************************************************
		
		public void GetPublicQueuesByCriteria()
		{
			// Define criteria to filter the queues.
			MessageQueueCriteria myCriteria = new 
				MessageQueueCriteria();
			myCriteria.CreatedAfter = DateTime.Now.Subtract(new 
				TimeSpan(1,0,0,0));
			myCriteria.ModifiedBefore = DateTime.Now;
			myCriteria.MachineName = ".";
			myCriteria.Label = "My Queue";
			
			// Get a list of queues with that criteria.
			MessageQueue[] QueueList = 
				MessageQueue.GetPublicQueues(myCriteria);

			// Display the paths of the queues in the list.
			foreach(MessageQueue queueItem in QueueList)
			{
				Console.WriteLine(queueItem.Path);
			}

			return;
		}


		//**************************************************
		// Gets a list of private queues on the local 
		// computer. Displays the list on screen.
		//**************************************************
		
		public void GetPrivateQueues()
		{
			// Get a list of queues with the specified category.
			MessageQueue[] QueueList = 
				MessageQueue.GetPrivateQueuesByMachine(".");

			// Display the paths of the queues in the list.
			foreach(MessageQueue queueItem in QueueList)
			{
				Console.WriteLine(queueItem.Path);
			}
			
			return;
		}
	}
}
// </Snippet1>