        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's ConnectorType property.
        queue.MessageReadPropertyFilter.ConnectorType = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's ConnectorType property.
        Console.WriteLine("Message.ConnectorType: {0}",
            orderMessage.ConnectorType);