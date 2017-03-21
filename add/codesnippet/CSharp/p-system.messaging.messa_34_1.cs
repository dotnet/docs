        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's UseAuthentication property.
        queue.MessageReadPropertyFilter.UseAuthentication = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's UseAuthentication property.
        Console.WriteLine("Message.UseAuthentication: {0}",
            orderMessage.UseAuthentication);