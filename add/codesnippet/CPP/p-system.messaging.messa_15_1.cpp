            // Set the filter's DefaultLabelSize 
            // property to 1024 bytes.
            queue->MessageReadPropertyFilter->
                DefaultLabelSize = 1024;
            
            // Display the new value of the filter's 
            // DefaultLabelSize property.
            Console::WriteLine(
                "MessageReadPropertyFilter.DefaultLabelSize: {0}", 
                queue->MessageReadPropertyFilter->DefaultLabelSize);
            