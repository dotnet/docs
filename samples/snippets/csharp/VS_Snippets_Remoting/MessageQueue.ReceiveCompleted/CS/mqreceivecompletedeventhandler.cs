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
		// This example performs asynchronous receive operation
		// processing.
		//**************************************************

		public static void Main()
		{
			// Create an instance of MessageQueue. Set its formatter.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(String)});

			// Add an event handler for the ReceiveCompleted event.
			myQueue.ReceiveCompleted += new 
				ReceiveCompletedEventHandler(MyReceiveCompleted);
			
			// Begin the asynchronous receive operation.
			myQueue.BeginReceive();
			
			// Do other work on the current thread.

			return;
		}


		//**************************************************
		// Provides an event handler for the ReceiveCompleted
		// event.
		//**************************************************
		
		private static void MyReceiveCompleted(Object source, 
			ReceiveCompletedEventArgs asyncResult)
		{
			// Connect to the queue.
			MessageQueue mq = (MessageQueue)source;

			// End the asynchronous Receive operation.
			Message m = mq.EndReceive(asyncResult.AsyncResult);

			// Display message information on the screen.
			Console.WriteLine("Message: " + (string)m.Body);

			// Restart the asynchronous Receive operation.
			mq.BeginReceive();
			
			return; 
		}
	}
}
// </Snippet1>