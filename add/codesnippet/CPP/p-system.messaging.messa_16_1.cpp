            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's IsFirstInTransaction property.
            queue->MessageReadPropertyFilter->
                IsFirstInTransaction = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // IsFirstInTransaction property.
            Console::WriteLine("Message.IsFirstInTransaction: {0}", 
                orderMessage->IsFirstInTransaction);
            