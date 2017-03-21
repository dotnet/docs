            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's TransactionId property.
            queue->MessageReadPropertyFilter->TransactionId = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // TransactionId property.
            Console::WriteLine("Message.TransactionId: {0}", 
                orderMessage->TransactionId);
            