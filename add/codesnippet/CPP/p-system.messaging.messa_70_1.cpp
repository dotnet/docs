            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's 
            // AuthenticationProviderName property.
            queue->MessageReadPropertyFilter->
                AuthenticationProviderName = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AuthenticationProviderName property.
            Console::WriteLine(
                "Message.AuthenticationProviderName: {0}", 
                orderMessage->AuthenticationProviderName);
            