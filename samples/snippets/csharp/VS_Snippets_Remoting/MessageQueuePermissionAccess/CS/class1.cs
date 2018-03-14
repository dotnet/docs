// <snippet0>

using System;
using System.Messaging;

public class MessageQueuePermissionAccessExample
{
    public static void Main()
    {
        // Create a new instance of the class.
        MessageQueuePermissionAccessExample example =
            new MessageQueuePermissionAccessExample();

        // Create a non-transactional queue on the local computer.
        CreateQueue(".\\exampleQueue", false);

        // Demonstrate use of MessageQueuePermissionAccess.
        example.CreatePermission();
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

    // Demonstrates the use of MessageQueuePermissionAccess
    public void CreatePermission()
    {
        // <snippet1>
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");
	string machineName = queue.MachineName;
	string label = queue.Label;
        string category = queue.Category.ToString();
        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission permission = new MessageQueuePermission(
            MessageQueuePermissionAccess.Receive,
            machineName,
            label,
            category);
        // </snippet1>
    }
}

// </snippet0>