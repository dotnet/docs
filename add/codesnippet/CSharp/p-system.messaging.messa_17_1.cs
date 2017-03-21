        // Set the queue's DenySharedReceive property value.
        queue.DenySharedReceive = false;

        // Display the new value of the queue's DenySharedReceive property.
        Console.WriteLine("MessageQueue.DenySharedReceive: {0}",
            queue.DenySharedReceive);