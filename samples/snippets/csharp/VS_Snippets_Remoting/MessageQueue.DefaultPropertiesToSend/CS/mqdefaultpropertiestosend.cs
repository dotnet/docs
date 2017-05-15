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
		// This example specifies different types of default
		// properties for messages.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Send normal and high priority messages.
			myNewQueue.SendNormalPriorityMessages();
			myNewQueue.SendHighPriorityMessages();
						
			return;
		}


		//**************************************************
		// Associates selected message property values
		// with high priority messages.
		//**************************************************
		
		public void SendHighPriorityMessages()
		{

			// Connect to a message queue.
			MessageQueue myQueue = new 
				MessageQueue(".\\myQueue");

			// Associate selected default property values with high
			// priority messages.
			myQueue.DefaultPropertiesToSend.Priority = 
				MessagePriority.High;
			myQueue.DefaultPropertiesToSend.Label = 
				"High Priority Message";
			myQueue.DefaultPropertiesToSend.Recoverable = true;
			myQueue.DefaultPropertiesToSend.TimeToReachQueue =
				new TimeSpan(0,0,30);
			
			// Send messages using these defaults.
			myQueue.Send("High priority message data 1.");
			myQueue.Send("High priority message data 2.");
			myQueue.Send("High priority message data 3.");
			
			return;
		}


		//**************************************************
		// Associates selected message property values
		// with normal priority messages.
		//**************************************************
		
		public void SendNormalPriorityMessages()
		{

			// Connect to a message queue.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Associate selected default property values with normal
			// priority messages.
			myQueue.DefaultPropertiesToSend.Priority = 
				MessagePriority.Normal;
			myQueue.DefaultPropertiesToSend.Label = 
				"Normal Priority Message";
			myQueue.DefaultPropertiesToSend.Recoverable = false;
			myQueue.DefaultPropertiesToSend.TimeToReachQueue =
				new TimeSpan(0,2,0);
			
			// Send messages using these defaults.
			myQueue.Send("Normal priority message data 1.");
			myQueue.Send("Normal priority message data 2.");
			myQueue.Send("Normal priority message data 3.");
			
			return;
		}
	}
}
// </Snippet1>