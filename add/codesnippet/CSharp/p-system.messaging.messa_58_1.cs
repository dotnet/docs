        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's UseDeadLetterQueue property.
        queue.MessageReadPropertyFilter.UseDeadLetterQueue = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's UseDeadLetterQueue property.
        Console.WriteLine("Message.UseDeadLetterQueue: {0}",
            orderMessage.UseDeadLetterQueue);