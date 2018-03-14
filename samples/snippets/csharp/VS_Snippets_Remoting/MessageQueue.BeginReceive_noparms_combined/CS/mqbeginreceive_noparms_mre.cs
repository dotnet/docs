// <Snippet1>
using System;
using System.Messaging;
using System.Threading;

namespace MyProject
{
	/// <summary>
	/// Provides a container class for the example.
	/// </summary>
	public class MyNewQueue
	{
		// Define static class members.
		static ManualResetEvent signal = new ManualResetEvent(false);
		static int count = 0;

		//**************************************************
		// Provides an entry point into the application.
		//		 
		// This example performs asynchronous receive
		// operation processing.
		//**************************************************

		public static void Main()
		{
			// Create an instance of MessageQueue. Set its formatter.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(String)});

			// Add an event handler for the ReceiveCompleted event.
			myQueue.ReceiveCompleted += 
				new ReceiveCompletedEventHandler(MyReceiveCompleted);
			
			// Begin the asynchronous receive operation.
			myQueue.BeginReceive();

			signal.WaitOne();
			
			// Do other work on the current thread.

			return;
		}


		//***************************************************
		// Provides an event handler for the ReceiveCompleted
		// event.
		//***************************************************
		
		private static void MyReceiveCompleted(Object source, 
			ReceiveCompletedEventArgs asyncResult)
		{
			try
			{
				// Connect to the queue.
				MessageQueue mq = (MessageQueue)source;

				// End the asynchronous receive operation.
				Message m = mq.EndReceive(asyncResult.AsyncResult);
				
				count += 1;
				if (count == 10)
				{
					signal.Set();
				}

				// Restart the asynchronous receive operation.
				mq.BeginReceive();
			}
			catch(MessageQueueException)
			{
				// Handle sources of MessageQueueException.
			}
			
			// Handle other exceptions.
			
			return; 
		}
	}
}
// </Snippet1>