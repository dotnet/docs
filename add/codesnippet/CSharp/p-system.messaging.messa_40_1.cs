        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's SourceMachine property.
        queue.MessageReadPropertyFilter.SourceMachine = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's SourceMachine property.
        Console.WriteLine("Message.SourceMachine: {0}",
            orderMessage.SourceMachine);