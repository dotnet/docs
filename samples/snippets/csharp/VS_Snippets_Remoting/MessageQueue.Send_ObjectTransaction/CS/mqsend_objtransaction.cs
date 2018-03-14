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
        // a transactional queue.
        //**************************************************

        public static void Main()
        {
            // Create a new instance of the class.
            MyNewQueue myNewQueue = new MyNewQueue();

            // Send a message to a queue.
            myNewQueue.SendMessageTransactional();

            // Receive a message from a queue.
            myNewQueue.ReceiveMessageTransactional();
		
            return;
        }


        //**************************************************
        // Sends a message to a queue.
        //**************************************************
		
        public void SendMessageTransactional()
        {
						
            // Connect to a queue on the local computer.
            MessageQueue myQueue = new 
                MessageQueue(".\\myTransactionalQueue");

            // Send a message to the queue.
            if (myQueue.Transactional == true)
            {
                // Create a transaction.
                MessageQueueTransaction myTransaction = new 
                    MessageQueueTransaction();

                // Begin the transaction.
                myTransaction.Begin();

                // Send the message.
                myQueue.Send("My Message Data.", myTransaction);

                // Commit the transaction.
                myTransaction.Commit();
            }

            return;
        }


        //**************************************************
        // Receives a message containing an Order.
        //**************************************************
		
        public  void ReceiveMessageTransactional()
        {
            // Connect to a transactional queue on the local computer.
            MessageQueue myQueue = new 
                MessageQueue(".\\myTransactionalQueue");

            // Set the formatter.
            myQueue.Formatter = new XmlMessageFormatter(new Type[]
                {typeof(String)});
			
            // Create a transaction.
            MessageQueueTransaction myTransaction = new 
                MessageQueueTransaction();

            try
            {
                // Begin the transaction.
                myTransaction.Begin();
				
                // Receive the message. 
                Message myMessage =	myQueue.Receive(myTransaction); 
                String myOrder = (String)myMessage.Body;

                // Display message information.
                Console.WriteLine(myOrder);

                // Commit the transaction.
                myTransaction.Commit();

            }
			
            catch (MessageQueueException e)
            {
                // Handle nontransactional queues.
                if (e.MessageQueueErrorCode == 
                    MessageQueueErrorCode.TransactionUsage)
                { 
                    Console.WriteLine("Queue is not transactional.");
                }
				
                // Else catch other sources of MessageQueueException.

                // Roll back the transaction.
                myTransaction.Abort();
            }

            // Catch other exceptions as necessary, such as 
            // InvalidOperationException, thrown when the formatter 
            // cannot deserialize the message.

            return;
        }
    }
}
// </Snippet1>