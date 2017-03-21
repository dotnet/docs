        // Create a new message.
        Message msg = new Message();

        // Set the message's TimeToReachQueue property to
        // MessageQueue.InfiniteTimeout.
        msg.TimeToReachQueue = MessageQueue.InfiniteTimeout;

        // Display the new value of the message's TimeToReachQueue property.
        Console.WriteLine("Message.TimeToReachQueue: {0}",
            msg.TimeToReachQueue.ToString());