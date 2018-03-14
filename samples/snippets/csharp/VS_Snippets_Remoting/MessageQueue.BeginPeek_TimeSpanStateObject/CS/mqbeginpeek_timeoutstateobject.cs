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
		// Represents a state object associated with each message.
		static int messageNumber = 0;

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
			
			// Begin the asynchronous peek operation with a time-out 
			// of one minute.
			myQueue.BeginPeek(new TimeSpan(0,1,0), messageNumber++);
			
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
			try
			{
				// Connect to the queue.
				MessageQueue mq = (MessageQueue)source;

				// End the asynchronous peek operation.
				Message m = mq.EndPeek(asyncResult.AsyncResult);

				// Display message information on the screen, 
				// including the message number (state object).
				Console.WriteLine("Message: " + 
					(int)asyncResult.AsyncResult.AsyncState + " " 
					+(string)m.Body);

				// Restart the asynchronous peek operation, with the 
				// same time-out.
				mq.BeginPeek(new TimeSpan(0,1,0), messageNumber++);

			}

			catch(MessageQueueException e)
			{
				if (e.MessageQueueErrorCode == 
					MessageQueueErrorCode.IOTimeout)
				{
					Console.WriteLine(e.ToString());
				}

				// Handle other sources of MessageQueueException.
			}
			
			// Handle other exceptions.
			
			return; 
		}
	}
}
// </Snippet1>