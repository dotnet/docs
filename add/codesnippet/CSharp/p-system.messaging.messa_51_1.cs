        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's TimeToReachQueue property.
        queue.MessageReadPropertyFilter.TimeToReachQueue = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's TimeToReachQueue property.
        Console.WriteLine("Message.TimeToReachQueue: {0}",
            orderMessage.TimeToReachQueue);