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
		// This example retrieves specific groups of Message
		// properties.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Retrieve specific sets of Message properties.
			myNewQueue.RetrieveDefaultProperties();
			myNewQueue.RetrieveAllProperties();
			myNewQueue.RetrieveSelectedProperties();

			return;
		}


		//**************************************************
		// Retrieves the default properties for a Message.
		//**************************************************
		
		public void RetrieveDefaultProperties()
		{

			// Connect to a message queue.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Specify to retrieve the default properties only.
			myQueue.MessageReadPropertyFilter.SetDefaults();

			// Set the formatter for the Message.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(String)});

			// Receive the first message in the queue.
			Message myMessage = myQueue.Receive();

			// Display selected properties.
			Console.WriteLine("Label: " + myMessage.Label);
			Console.WriteLine("Body: " + (String)myMessage.Body);
	
			return;
		}


		//**************************************************
		// Retrieves all properties for a Message.
		//**************************************************
		
		public void RetrieveAllProperties()
		{

			// Connect to a message queue.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Specify to retrieve all properties.
			myQueue.MessageReadPropertyFilter.SetAll();

			// Set the formatter for the Message.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(String)});

			// Receive the first message in the queue.
			Message myMessage = myQueue.Receive();

			// Display selected properties.
			Console.WriteLine("Encryption algorithm: " + 
				myMessage.EncryptionAlgorithm.ToString());
			Console.WriteLine("Body: " + (String)myMessage.Body);
	
			return;
		}
			

		//**************************************************
		// Retrieves application-specific properties for a
		// Message.
		//**************************************************
		
		public void RetrieveSelectedProperties()
		{
			// Connect to a message queue.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Specify to retrieve selected properties.
			MessagePropertyFilter myFilter = new 
				MessagePropertyFilter();
			myFilter.ClearAll();
			// The following list is a random subset of available properties.
			myFilter.Body = true;
			myFilter.Label = true;
			myFilter.MessageType = true;
			myFilter.Priority = true;
			myQueue.MessageReadPropertyFilter = myFilter;

			// Set the formatter for the Message.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(String)});

			// Receive the first message in the queue.
			Message myMessage = myQueue.Receive();

			// Display selected properties.
			Console.WriteLine("Message type: " + 
				myMessage.MessageType.ToString());
			Console.WriteLine("Priority: " + 
				myMessage.Priority.ToString());
	
			return;
			}
	}
}
// </Snippet1>