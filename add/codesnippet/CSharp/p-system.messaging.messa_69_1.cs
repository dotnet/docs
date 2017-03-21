        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's AppSpecific property.
        queue.MessageReadPropertyFilter.AppSpecific = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's AppSpecific property.
        Console.WriteLine("Message.AppSpecific: {0}",
            orderMessage.AppSpecific);