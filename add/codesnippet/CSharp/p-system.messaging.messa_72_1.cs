        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's DestinationSymmetricKey property.
        queue.MessageReadPropertyFilter.DestinationSymmetricKey = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's DestinationSymmetricKey property.
        Console.WriteLine("Message.DestinationSymmetricKey: {0}",
            orderMessage.DestinationSymmetricKey);