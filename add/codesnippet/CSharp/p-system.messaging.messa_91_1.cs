        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's Body property.
        queue.MessageReadPropertyFilter.Body = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's Body property.
        Console.WriteLine("Message.Body: {0}", orderMessage.Body);