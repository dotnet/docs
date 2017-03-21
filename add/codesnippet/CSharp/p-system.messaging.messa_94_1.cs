        // Set the filter's DefaultExtensionSize property to 1024 bytes.
        queue.MessageReadPropertyFilter.DefaultExtensionSize = 1024;

        // Display the new value of the filter's DefaultExtensionSize property.
        Console.WriteLine("MessageReadPropertyFilter.DefaultExtensionSize: {0}",
            queue.MessageReadPropertyFilter.DefaultExtensionSize.ToString());