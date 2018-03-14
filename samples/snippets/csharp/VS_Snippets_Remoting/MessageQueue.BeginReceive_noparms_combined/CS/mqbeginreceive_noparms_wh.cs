// <Snippet2>
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
			
			// Define wait handles for multiple operations.
			WaitHandle[] waitHandleArray = new WaitHandle[10];
			for(int i=0; i<10; i++)
			{
				// Begin asynchronous operations.
				waitHandleArray[i] = 
					myQueue.BeginReceive().AsyncWaitHandle;
			}

			// Specify to wait for all operations to return.
			WaitHandle.WaitAll(waitHandleArray);
         
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
		
				// Process the message here.
				Console.WriteLine("Message received.");

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
// </Snippet2>