        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive,
            queue->Path);

        // Display the value of the entry's Path property.
        Console::WriteLine("Path: {0}", entry->Path);

        queue->Close();