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
        // Connect to a queue on the local computer. You must set the queue's
        // Path property before you can use the queue.
        MessageQueue queue = new MessageQueue();
        queue.Path = ".\\exampleQueue";
        // </snippet1>

        // <snippet3>
        // Set the queue's Authenticate property value.
        queue.Authenticate = true;

        // Display the new value of the queue's Authenticate property.
        Console.WriteLine("MessageQueue.Authenticate: {0}", queue.Authenticate);
        // </snippet3>

        // <snippet4>
        // Set the queue's BasePriority property value.
        queue.BasePriority = 10;

        // Display the new value of the queue's BasePriority property.
        Console.WriteLine("MessageQueue.BasePriority: {0}", queue.BasePriority);
        // </snippet4>

        // <snippet5>
        // Display the value of the queue's CanRead property.
        Console.WriteLine("MessageQueue.CanRead: {0}", queue.CanRead);
        // </snippet5>

        // <snippet6>
        // Display the value of the queue's CanWrite property.
        Console.WriteLine("MessageQueue.CanWrite: {0}", queue.CanWrite);
        // </snippet6>

        // <snippet7>
        // Set the queue's Category property value.
        queue.Category =
            new System.Guid("00000000-0000-0000-0000-000000000001");

        // Display the new value of the queue's Category property.
        Console.WriteLine("MessageQueue.Category: {0}", queue.Category);
        // </snippet7>

        // <snippet8>
        // Call the MessageQueue.ClearConnectionCache method.
        MessageQueue.ClearConnectionCache();
        // </snippet8>

        // <snippet9>
        // Display the value of the queue's CreateTime property.
        Console.WriteLine("MessageQueue.CreateTime: {0}", queue.CreateTime);
        // </snippet9>

        // <snippet10>
        // Set the queue's DenySharedReceive property value.
        queue.DenySharedReceive = false;

        // Display the new value of the queue's DenySharedReceive property.
        Console.WriteLine("MessageQueue.DenySharedReceive: {0}",
            queue.DenySharedReceive);
        // </snippet10>

        // <snippet11>
        // Set the MessageQueue.EnableConnectionCache property value.
        MessageQueue.EnableConnectionCache = false;

        // Display the new value of the MessageQueue.EnableConnectionCache
        // property.
        Console.WriteLine("MessageQueue.EnableConnectionCache: {0}",
            MessageQueue.EnableConnectionCache);
        // </snippet11>

        // <snippet12>
        // Set the queue's EncryptionRequired property value.
        queue.EncryptionRequired = System.Messaging.EncryptionRequired.Optional;

        // Display the new value of the queue's EncryptionRequired property.
        Console.WriteLine("MessageQueue.EncryptionRequired: {0}",
            queue.EncryptionRequired);
        // </snippet12>

        // <snippet13>
        // Display the value of the queue's FormatName property.
        Console.WriteLine("MessageQueue.FormatName: {0}", queue.FormatName);
        // </snippet13>

        // <snippet14>
        // Get the name of the computer that contains the queue.
        string machineName = queue.MachineName;

        // Display the return value of the MessageQueue.GetMachineId method.
        Console.WriteLine("MessageQueue.GetMachineId(): {0}",
            MessageQueue.GetMachineId(machineName));
        // </snippet14>

        // <snippet15>
        // Display the value of the queue's Id property.
        Console.WriteLine("MessageQueue.Id: {0}", queue.Id);
        // </snippet15>

        // <snippet16>
        // Set the queue's MaximumQueueSize property to
        // MessageQueue.InfiniteQueueSize.
        queue.MaximumQueueSize = MessageQueue.InfiniteQueueSize;

        // Display the new value of the queue's MaximumQueueSize property.
        Console.WriteLine("MessageQueue.MaximumQueueSize: {0}",
            queue.MaximumQueueSize.ToString());
        // </snippet16>

        // <snippet17>
        // Create a new message.
        Message msg = new Message();

        // Set the message's TimeToReachQueue property to
        // MessageQueue.InfiniteTimeout.
        msg.TimeToReachQueue = MessageQueue.InfiniteTimeout;

        // Display the new value of the message's TimeToReachQueue property.
        Console.WriteLine("Message.TimeToReachQueue: {0}",
            msg.TimeToReachQueue.ToString());
        // </snippet17>

        // <snippet18>
        // Set the queue's Label property value.
        queue.Label = "Example Queue";

        // Display the new value of the queue's Label property.
        Console.WriteLine("MessageQueue.Label: {0}",
            queue.Label);
        // </snippet18>

        // <snippet19>
        // Display the value of the queue's LastModifyTime property.
        Console.WriteLine("MessageQueue.LastModifyTime: {0}", queue.LastModifyTime);
        // </snippet19>

        // <snippet20>
        // Set the queue's MachineName property value to the name of the local
        // computer.
        queue.MachineName = ".";

        // Display the new value of the queue's MachineName property.
        Console.WriteLine("MessageQueue.MachineName: {0}", queue.MachineName);
        // </snippet20>

        // <snippet21>
        // Set the queue's MaximumJournalSize property value.
        queue.MaximumJournalSize = 10;

        // Display the new value of the queue's MaximumJournalSize property.
        Console.WriteLine("MessageQueue.MaximumJournalSize: {0}",
            queue.MaximumJournalSize);
        // </snippet21>

        // <snippet22>
        // Set the queue's MaximumQueueSize property value.
        queue.MaximumQueueSize = 10;

        // Display the new value of the queue's MaximumQueueSize property.
        Console.WriteLine("MessageQueue.MaximumQueueSize: {0}",
            queue.MaximumQueueSize);
        // </snippet22>

        // <snippet24>
        // Set the queue's QueueName property value.
        queue.QueueName = "Example Queue";

        // Display the new value of the queue's QueueName property.
        Console.WriteLine("MessageQueue.QueueName: {0}", queue.QueueName);
        // </snippet24>

        // <snippet27>
        // Display the value of the queue's Transactional property.
        Console.WriteLine("MessageQueue.Transactional: {0}",
            queue.Transactional);
        // </snippet27>

        // <snippet28>
        // Set the queue's UseJournalQueue property value.
        queue.UseJournalQueue = true;

        // Display the new value of the queue's UseJournalQueue property.
        Console.WriteLine("MessageQueue.UseJournalQueue: {0}",
            queue.UseJournalQueue);
        // </snippet28>
    }
}

// </snippet0>
