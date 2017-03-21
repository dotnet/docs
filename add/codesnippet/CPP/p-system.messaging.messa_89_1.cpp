            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's IsLastInTransaction property.
            queue->MessageReadPropertyFilter->
                IsLastInTransaction = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // IsLastInTransaction property.
            Console::WriteLine("Message.IsLastInTransaction: {0}", 
                orderMessage->IsLastInTransaction);
            