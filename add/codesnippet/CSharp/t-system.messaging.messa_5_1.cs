
using System;
using System.Messaging;

public class MessageQueuePermissionEntryExample
{
    public static void Main()
    {
        // Create a new instance of the class.
        MessageQueuePermissionEntryExample example =
            new MessageQueuePermissionEntryExample();

        // Create a non-transactional queue on the local computer.
        CreateQueue(".\\exampleQueue", false);

        // Demonstrate MessageQueuePermissionEntry's constructors.
        example.CreateEntry1();
        example.CreateEntry2();

        // Demonstrate MessageQueuePermissionEntry's properties.
        example.CategoryExample();
        example.LabelExample();
        example.MachineNameExample();
        example.PathExample();
        example.PermissionAccessExample();
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

    // Demonstrates the following MessageQueuePermission constructor:
    // public #ctor (MessageQueuePermissionAccess permissionAccess,
    //  String path)
    public void CreateEntry1()
    {
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.Path);
    }

    // Demonstrates the following MessageQueuePermission constructor:
    // public #ctor (MessageQueuePermissionAccess permissionAccess,
    //  String machineName, String label, String category)
    public void CreateEntry2()
    {
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.MachineName,
            queue.Label,
            queue.Category.ToString());
    }

    public void CategoryExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.MachineName,
            queue.Label,
            queue.Category.ToString());

        // Display the value of the entry's Category property.
        Console.WriteLine("Category: {0}", entry.Category.ToString());
    }

    public void LabelExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.MachineName,
            queue.Label,
            queue.Category.ToString());

        // Display the value of the entry's Label property.
        Console.WriteLine("Label: {0}", entry.Label);
    }

    public void MachineNameExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.MachineName,
            queue.Label,
            queue.Category.ToString());

        // Display the value of the entry's MachineName property.
        Console.WriteLine("MachineName: {0}", entry.MachineName);
    }

    public void PathExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.Path);

        // Display the value of the entry's Path property.
        Console.WriteLine("Path: {0}", entry.Path);
    }

    public void PermissionAccessExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.MachineName,
            queue.Label,
            queue.Category.ToString());

        // Display the value of the entry's PermissionAccess property.
        Console.WriteLine("PermissionAccess: {0}", entry.PermissionAccess);
    }
}