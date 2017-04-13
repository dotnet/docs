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
		// This example sends and receives a message from
		// a queue.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			// Create new queues.
			CreateQueue(".\\myQueue");
			CreateQueue(".\\myAdministrationQueue");

			// Send messages to a queue.
			myNewQueue.SendMessage();

			// Receive messages from a queue.
			string messageId = myNewQueue.ReceiveMessage(); 

			// Receive acknowledgment message.
			if(messageId != null)
			{
				myNewQueue.ReceiveAcknowledgment(messageId, ".\\myAdministrationQueue");
			}

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
		// Sends a string message to a queue.
		//**************************************************
		
		public void SendMessage()
		{

			// Connect to a queue on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			// Create a new message.
			Message myMessage = new Message("Original Message"); 

			myMessage.AdministrationQueue = new MessageQueue(".\\myAdministrationQueue");
			myMessage.AcknowledgeType = AcknowledgeTypes.PositiveReceive | AcknowledgeTypes.PositiveArrival;

			// Send the Order to the queue.
			myQueue.Send(myMessage);

			return;
		}


		//**************************************************
		// Receives a message containing an Order.
		//**************************************************
		
		public  string ReceiveMessage()
		{
			// Connect to the a queue on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");

			myQueue.MessageReadPropertyFilter.CorrelationId = true;


			// Set the formatter to indicate body contains an Order.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(string)});

			string returnString = null;
			
			try
			{
				// Receive and format the message. 
				Message myMessage =	myQueue.Receive(); 


				// Display message information.
				Console.WriteLine("____________________________________________");
				Console.WriteLine("Original message information--");
				Console.WriteLine("Body: " +myMessage.Body.ToString());
				Console.WriteLine("Id: " + myMessage.Id.ToString());
				Console.WriteLine("____________________________________________");

				returnString =  myMessage.Id;
				
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
			
			// Catch other exceptions as necessary.

			return returnString;
		}

		//**************************************************
		// Receives a message containing an Order.
		//**************************************************
		
		public void ReceiveAcknowledgment(string messageId, string queuePath)
		{
			bool found = false;
			MessageQueue queue = new MessageQueue(queuePath);
			queue.MessageReadPropertyFilter.CorrelationId = true;
			queue.MessageReadPropertyFilter.Acknowledgment = true;

			try
			{
				while(queue.PeekByCorrelationId(messageId) != null)
				{
					Message myAcknowledgmentMessage = queue.ReceiveByCorrelationId(messageId);
			
					// Output acknowledgment message information. The correlation Id is identical
					// to the id of the original message.
					Console.WriteLine("Acknowledgment Message Information--");
					Console.WriteLine("Correlation Id: " + myAcknowledgmentMessage.CorrelationId.ToString());
					Console.WriteLine("Id: " + myAcknowledgmentMessage.Id.ToString());
					Console.WriteLine("Acknowledgment Type: " + myAcknowledgmentMessage.Acknowledgment.ToString());
					Console.WriteLine("____________________________________________");

					found = true;
				}
			}
			catch (InvalidOperationException e)
			{ 
				// This exception would be thrown if there is no (further) acknowledgment message
				// with the specified correlation Id. Only output a message if there are no messages;
				// not if the loop has found at least one.
				if(found == false)
				{	
					Console.WriteLine(e.Message);
				}

				// Handle other causes of invalid operation exception.
			}

		}
	}
}
// </Snippet1>