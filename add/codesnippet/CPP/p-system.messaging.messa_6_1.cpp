            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's Id property.
            queue->MessageReadPropertyFilter->Id = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's Id property.
            Console::WriteLine("Message.Id: {0}", orderMessage->Id);
            