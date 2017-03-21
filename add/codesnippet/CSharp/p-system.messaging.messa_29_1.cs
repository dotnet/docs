        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's TransactionStatusQueue property.
        queue.MessageReadPropertyFilter.TransactionStatusQueue = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's TransactionStatusQueue.QueueName
        // property.
        Console.WriteLine("Message.TransactionStatusQueue.QueueName: {0}",
            orderMessage.TransactionStatusQueue.QueueName);