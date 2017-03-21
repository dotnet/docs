            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's ArrivedTime property.
            queue->MessageReadPropertyFilter->ArrivedTime = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // ArrivedTime property.
            Console::WriteLine("Message.ArrivedTime: {0}", 
                orderMessage->ArrivedTime);
            