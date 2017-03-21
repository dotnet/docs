        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's SentTime property.
        queue.MessageReadPropertyFilter.SentTime = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's SentTime property.
        Console.WriteLine("Message.SentTime: {0}",
            orderMessage.SentTime);