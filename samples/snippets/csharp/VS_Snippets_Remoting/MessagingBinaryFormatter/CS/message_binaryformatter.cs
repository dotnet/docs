// <Snippet1>
using System;
using System.Messaging;
using System.Drawing;
using System.IO;

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
		// This example sends and receives a message from
		// a queue.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Create a queue on the local computer.
			CreateQueue(".\\myQueue");
			
			// Send a message to a queue.
			myNewQueue.SendMessage();

			// Receive a message from a queue.
			myNewQueue.ReceiveMessage();

			return;
		}

		//**************************************************
		// Creates a new queue.
		//**************************************************

		public static void CreateQueue(string queuePath)
		{
			try	
				{
				if(!MessageQueue.Exists(queuePath))
				{
					MessageQueue.Create(queuePath);
				}
				else
				{
					Console.WriteLine(queuePath + " already exists.");
				}
			}
			catch (MessageQueueException e)
			{
				Console.WriteLine(e.Message);
			}
			
		}

		//**************************************************
		// Sends an image to a queue, using the BinaryMessageFormatter.
		//**************************************************
		
		public void SendMessage()
		{
			try{

				// Create a new bitmap.
				// The file must be in the \bin\debug or \bin\retail folder, or
				// you must give a full path to its location.
				Image myImage = Bitmap.FromFile("SentImage.bmp");

				// Connect to a queue on the local computer.
				MessageQueue myQueue = new MessageQueue(".\\myQueue");
				
				Message myMessage = new Message(myImage, new BinaryMessageFormatter());

				// Send the image to the queue.
				myQueue.Send(myMessage);
			}
			catch(ArgumentException e)
			{
				Console.WriteLine(e.Message);
			
			}

			return;
		}


		//**************************************************
		// Receives a message containing an image.
		//**************************************************
		
		public  void ReceiveMessage()
		{
						
			try
			{

				// Connect to the a queue on the local computer.
				MessageQueue myQueue = new MessageQueue(".\\myQueue");

				// Set the formatter to indicate body contains an Order.
				myQueue.Formatter = new BinaryMessageFormatter();

				// Receive and format the message. 
				System.Messaging.Message myMessage = myQueue.Receive(); 
				Bitmap myImage = (Bitmap)myMessage.Body;
				
				// This will be saved in the \bin\debug or \bin\retail folder.
				myImage.Save("ReceivedImage.bmp",System.Drawing.Imaging.ImageFormat.Bmp);
				
				
			}
			
			catch (MessageQueueException)
			{
				// Handle Message Queuing exceptions.
			}

			// Handle invalid serialization format.
			catch (InvalidOperationException e)
			{
				Console.WriteLine(e.Message);
			}

			catch (IOException e)
			{
				// Handle file access exceptions.
			}
			
			// Catch other exceptions as necessary.

			return;
		}
	}
}
// </Snippet1>