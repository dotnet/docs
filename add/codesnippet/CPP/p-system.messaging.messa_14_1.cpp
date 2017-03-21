            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's UseTracing property.
            queue->MessageReadPropertyFilter->UseTracing = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // UseTracing property.
            Console::WriteLine("Message.UseTracing: {0}", 
                orderMessage->UseTracing);
            