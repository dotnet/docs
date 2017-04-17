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
        // This example sends a message to a queue.
        //**************************************************

        public static void Main()
        {
            // Create a new instance of the class.
            MyNewQueue myNewQueue = new MyNewQueue();

            // Send a message to a queue.
            myNewQueue.SendMessage();

            return;
        }


        //**************************************************
        // Sends a message to a queue.
        //**************************************************
		
        public void SendMessage()
        {
						
            // Connect to a queue on the local computer.
            MessageQueue myQueue = new MessageQueue(".\\myQueue");

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
            else
            {
                myQueue.Send("My Message Data.");
            }

            return;
        }
    }
}
// </Snippet1>