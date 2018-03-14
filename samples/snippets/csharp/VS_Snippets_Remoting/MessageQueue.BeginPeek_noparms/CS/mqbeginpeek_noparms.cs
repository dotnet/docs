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
		// This example performs asynchronous peek operation
		// processing.
		//**************************************************

		public static void Main()
		{
			// Create an instance of MessageQueue. Set its formatter.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(String)});

			// Add an event handler for the PeekCompleted event.
			myQueue.PeekCompleted += new 
				PeekCompletedEventHandler(MyPeekCompleted);
			
			// Begin the asynchronous peek operation.
			myQueue.BeginPeek();
			
			// Do other work on the current thread.

			return;
		}


		//**************************************************
		// Provides an event handler for the PeekCompleted
		// event.
		//**************************************************
		
		private static void MyPeekCompleted(Object source, 
			PeekCompletedEventArgs asyncResult)
		{
			// Connect to the queue.
			MessageQueue mq = (MessageQueue)source;

			// End the asynchronous peek operation.
			Message m = mq.EndPeek(asyncResult.AsyncResult);

			// Display message information on the screen.
			Console.WriteLine("Message: " + (string)m.Body);

			// Restart the asynchronous peek operation.
			mq.BeginPeek();
			
			return; 
		}
	}
}
// </Snippet1>