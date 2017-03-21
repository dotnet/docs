        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's Label property.
        queue.MessageReadPropertyFilter.Label = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's Label property.
        Console.WriteLine("Message.Label: {0}",
            orderMessage.Label);