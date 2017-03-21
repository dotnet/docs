        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create an array of type MessageQueuePermissionEntry.
        array<MessageQueuePermissionEntry^>^ entries = 
            gcnew array<MessageQueuePermissionEntry^>(1);

        // Create a new instance of MessageQueuePermissionEntry and place the
        // instance in the array.
        entries[0] = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the array to the collection.
        collection->AddRange(entries);

        queue->Close();