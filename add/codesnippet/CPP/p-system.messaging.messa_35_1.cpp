            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's UseEncryption property.
            queue->MessageReadPropertyFilter->UseEncryption = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // UseEncryption property.
            Console::WriteLine("Message.UseEncryption: {0}", 
                orderMessage->UseEncryption);
            