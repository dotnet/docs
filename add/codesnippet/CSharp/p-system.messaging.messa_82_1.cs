        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's AcknowledgeType property.
        queue.MessageReadPropertyFilter.AcknowledgeType = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's AcknowledgeType property.
        Console.WriteLine("Message.AcknowledgeType: {0}",
            orderMessage.AcknowledgeType);