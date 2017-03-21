            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's 
            // AuthenticationProviderType property.
            queue->MessageReadPropertyFilter->
                AuthenticationProviderType = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AuthenticationProviderType property.
            Console::WriteLine(
                "Message.AuthenticationProviderType: {0}", 
                orderMessage->AuthenticationProviderType);
            