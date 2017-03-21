        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's Recoverable property.
        queue.MessageReadPropertyFilter.Recoverable = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's Recoverable property.
        Console.WriteLine("Message.Recoverable: {0}",
            orderMessage.Recoverable);