        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's TimeToBeReceived property.
        queue.MessageReadPropertyFilter.TimeToBeReceived = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's TimeToBeReceived property.
        Console.WriteLine("Message.TimeToBeReceived: {0}",
            orderMessage.TimeToBeReceived);