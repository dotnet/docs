        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's ResponseQueue property.
        queue.MessageReadPropertyFilter.ResponseQueue = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's ResponseQueue.QueueName property.
        if(orderMessage.ResponseQueue != null)
        {
            Console.WriteLine("Message.ResponseQueue.QueueName: {0}",
                orderMessage.ResponseQueue.QueueName);
        }