        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's SenderCertificate property.
        queue.MessageReadPropertyFilter.SenderCertificate = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's SenderCertificate property.
        Console.WriteLine("Message.SenderCertificate: {0}",
            orderMessage.SenderCertificate);