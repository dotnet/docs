            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's AdministrationQueue property.
            queue->MessageReadPropertyFilter->
                AdministrationQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AdministrationQueue property.
            Console::WriteLine("Message.AdministrationQueue: {0}", 
                orderMessage->AdministrationQueue);
            