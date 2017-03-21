            // Set the filter's DefaultBodySize 
            // property to 2048 bytes.
            queue->MessageReadPropertyFilter->
                DefaultBodySize = 2048;
            
            // Display the new value of the filter's 
            // DefaultBodySize property.
            Console::WriteLine(
                "MessageReadPropertyFilter.DefaultBodySize: {0}", 
                queue->MessageReadPropertyFilter->DefaultBodySize);
            