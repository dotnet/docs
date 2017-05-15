// <snippet0>

using System;
using System.Messaging;

public class QueueExample
{
    public static void Main()
    {
        // Create a new instance of the class.
        QueueExample example = new QueueExample();

        // Create a nontransactional queue on the local computer.
        CreateQueue(".\\exampleQueue", false);

        example.UseQueue();

        return;
    }

    // Create a new queue.
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

    public void UseQueue()
    {
        // <snippet1>
        // Connect to a queue on the local computer, grant exclusive read
        // access to the first application that accesses the queue, and
        // enable connection caching.
        MessageQueue queue = new MessageQueue(".\\exampleQueue", true, true);
        // </snippet1>
    }
}

// </snippet0>
