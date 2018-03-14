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
        // This example creates new transactional queues.
        //**************************************************

        public static void Main()
        {
            // Create a new instance of the class.
            MyNewQueue myNewQueue = new MyNewQueue();

            // Create transactional queues.
            myNewQueue.CreatePublicTransactionalQueues();
            myNewQueue.CreatePrivateTransactionalQueues();

            return;
        }


        //**************************************************
        // Creates public transactional queues and sends a 
        // message.
        //**************************************************
		
        public void CreatePublicTransactionalQueues()
        {

            // Create and connect to a public Message Queuing queue.
            if (!MessageQueue.Exists(".\\newPublicTransQueue1"))
            {
                // Create the queue if it does not exist.
                MessageQueue.Create(".\\newPublicTransQueue1", true);
            }

            // Connect to the queue.
            MessageQueue myNewPublicQueue =
                new MessageQueue(".\\newPublicTransQueue1");

            // Send a message to the queue.
            // Create a transaction.
            MessageQueueTransaction myTransaction = new 
                MessageQueueTransaction();

            // Begin the transaction.
            myTransaction.Begin();

            // Send the message.
            myNewPublicQueue.Send("My Message Data.", myTransaction);

            // Commit the transaction.
            myTransaction.Commit();

            if (!MessageQueue.Exists(".\\newPublicTransQueue2"))
            {
                // Create (but do not connect to) second public queue.
                MessageQueue.Create(".\\newPublicTransQueue2", true);
            }

            return;

        }


        //**************************************************
        // Creates private queues and sends a message.
        //**************************************************
		
        public void CreatePrivateTransactionalQueues()
        {

            // Create and connect to a private Message Queuing queue.
            if (!MessageQueue.Exists(".\\Private$\\newPrivTransQ1"))
            {
                // Create the queue if it does not exist.
                MessageQueue.Create(".\\Private$\\newPrivTransQ1", true);
            }

            // Connect to the queue.
            MessageQueue myNewPrivateQueue =
                new MessageQueue(".\\Private$\\newPrivTransQ1");

            // Send a message to the queue.
            // Create a transaction.
            MessageQueueTransaction myTransaction = new 
                MessageQueueTransaction();

            // Begin the transaction.
            myTransaction.Begin();

            // Send the message.
            myNewPrivateQueue.Send("My Message Data.", myTransaction);

            // Commit the transaction.
            myTransaction.Commit();

            // Create (but do not connect to) a second private queue.
            if (!MessageQueue.Exists(".\\Private$\\newPrivTransQ2"))
            {
                MessageQueue.Create(".\\Private$\\newPrivTransQ2", 
                    true);
            }

            return;
        }
    }
}
// </Snippet1>