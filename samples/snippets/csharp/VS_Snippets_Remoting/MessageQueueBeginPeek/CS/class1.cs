// <snippet0>

using System;
using System.Messaging;

public class QueueExample
{
    // Represents a state object associated with each message.
    static int messageNumber = 0;

    public static void Main()
    {
        // Create a non-transactional queue on the local computer.
        // Note that the queue might not be immediately accessible, and
        // therefore this example might throw an exception of type
        // System.Messaging.MessageQueueException when trying to send a
        // message to the newly created queue.
        CreateQueue(".\\exampleQueue", false);

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Send a message to the queue.
        queue.Send("Example Message");

        // Begin the asynchronous peek operation.
        queue.BeginPeek(TimeSpan.FromSeconds(10.0), messageNumber++,
            new AsyncCallback(MyPeekCompleted));

        // Simulate doing other work on the current thread.
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10.0));

        return;
    }

    // Creates a new queue.
    public static void CreateQueue(string queuePath, bool transactional)
    {
        if(!MessageQueue.Exists(queuePath))
        {
            MessageQueue.Create(queuePath, transactional);
        }
        else
        {
            Console.WriteLine(queuePath + " already exists.");
        }
    }

    // Provides an event handler for the PeekCompleted event.
    private static void MyPeekCompleted(IAsyncResult asyncResult)
    {
        // Connect to the queue.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // End the asynchronous peek operation.
        Message msg = queue.EndPeek(asyncResult);

        // Display the message information on the screen.
        Console.WriteLine("Message number: {0}", (int)asyncResult.AsyncState);
        Console.WriteLine("Message body: {0}", (string)msg.Body);

        // Receive the message. This will remove the message from the queue.
        msg = queue.Receive(TimeSpan.FromSeconds(10.0));
    }
}

// </snippet0>