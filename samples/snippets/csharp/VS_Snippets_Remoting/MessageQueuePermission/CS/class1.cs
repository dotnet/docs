// <snippet0>

using System;
using System.Messaging;

public class MessageQueuePermissionExample
{
    public static void Main()
    {
        // Create a new instance of the class.
        MessageQueuePermissionExample example =
            new MessageQueuePermissionExample();

        // Create a message queue on the local computer.
        CreateQueue(".\\exampleQueue", false);

        // Demonstrate MessageQueuePermission's constructors.
        example.CreatePermission1();
        example.CreatePermission2();
        example.CreatePermission3();
        example.CreatePermission4();
        example.CreatePermission5();

        // Get and set MessageQueuePermission's PermissionEntries property.
        example.GetPermissionEntries();
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
    // public #ctor ()
    public void CreatePermission1()
    {
        // <snippet1>
        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission permission = new MessageQueuePermission();
        // </snippet1>
    }

    // Demonstrates the following MessageQueuePermission constructor:
    // public #ctor (MessageQueuePermissionAccess permissionAccess,
    //  String path)
    public void CreatePermission2()
    {
        // <snippet2>
        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission permission = new MessageQueuePermission(
            MessageQueuePermissionAccess.Receive,
            ".\\exampleQueue");
        // </snippet2>
    }

    // Demonstrates the following MessageQueuePermission constructor:
    // public #ctor (MessageQueuePermissionAccess permissionAccess,
    //  String machineName, String label, String category)
    public void CreatePermission3()
    {
        // <snippet3>
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
	string queueCategory = queue.Category.ToString();
	string machineName = queue.MachineName;
	string label = queue.Label;
        MessageQueuePermission permission = new MessageQueuePermission(
            MessageQueuePermissionAccess.Receive,
            machineName,
            label,
            queueCategory);
        // </snippet3>
    }

    // Demonstrates the following MessageQueuePermission constructor:
    //public #ctor (MessageQueuePermissionEntry[] permissionAccessEntries)
    public void CreatePermission4()
    {
        // <snippet4>
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create an array of type MessageQueuePermissionEntry.
        MessageQueuePermissionEntry[] entries =
            new MessageQueuePermissionEntry[1];

        // Create a new instance of MessageQueuePermissionEntry and place the
        // instance in the array.
	string machineName = queue.MachineName;
	string label = queue.Label;
        entries[0] = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            machineName,
            label,
            queue.Category.ToString());

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission permission = new MessageQueuePermission(
            entries);
        // </snippet4>
    }

    // Demonstrates the following MessageQueuePermission constructor:
    //public #ctor (PermissionState state)
    public void CreatePermission5()
    {
        // <snippet5>
        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission permission = new MessageQueuePermission(
            System.Security.Permissions.PermissionState.Unrestricted);
        // </snippet5>
    }

    public void GetPermissionEntries()
    {
	
        // <snippet6>
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create an array of type MessageQueuePermissionEntry.
        MessageQueuePermissionEntry[] entries =
            new MessageQueuePermissionEntry[1];

        // Create a new instance of MessageQueuePermissionEntry and place the
        // instance in the array.
	string machineName = queue.MachineName;
	string label = queue.Label;
        entries[0] = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            machineName,
            label,
            queue.Category.ToString());

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission permission = new MessageQueuePermission(
            entries);

        // Create a new instance of MessageQueuePermissionEntryCollection and
        // use it to retrieve the permission's PermissionEntries property
        // value.
        MessageQueuePermissionEntryCollection collection =
            permission.PermissionEntries;

        // Loop through the collection.
        foreach(MessageQueuePermissionEntry entry in collection)
        {
            // Display the property values of each MessageQueuePermissionEntry.
            Console.WriteLine("PermissionAccess: {0}", entry.PermissionAccess);
            Console.WriteLine("MachineName: {0}", entry.MachineName);
            Console.WriteLine("Label: {0}", entry.Label);
            Console.WriteLine("Category: {0}", entry.Category.ToString());
        }
        // </snippet6>
    }
}

// </snippet0>