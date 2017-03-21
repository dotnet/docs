            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's DestinationQueue property.
            queue->MessageReadPropertyFilter->
                DestinationQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // Destinationqueue->QueueName property.
            Console::WriteLine(
                "Message.Destinationqueue->QueueName: {0}", 
                orderMessage->DestinationQueue->QueueName);
            