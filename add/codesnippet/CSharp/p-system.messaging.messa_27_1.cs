        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's EncryptionAlgorithm property.
        queue.MessageReadPropertyFilter.EncryptionAlgorithm = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's EncryptionAlgorithm property.
        Console.WriteLine("Message.EncryptionAlgorithm: {0}",
            orderMessage.EncryptionAlgorithm);