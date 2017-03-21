        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the entry to the collection.
        collection->Add(entry);

        // Create an array of type MessageQueuePermissionEntry.
        array<MessageQueuePermissionEntry^>^ entries = 
            gcnew array<MessageQueuePermissionEntry^>(1);

        // Copy the collection to index 0 of the array.
        collection->CopyTo(entries, 0);

        // Show that the array now contains the entry.
        Console::WriteLine("entries[0].PermissionAccess: {0}",
            entries[0]->PermissionAccess);
        Console::WriteLine("entries[0].MachineName: {0}",
            entries[0]->MachineName);
        Console::WriteLine("entries[0].Label: {0}", entries[0]->Label);
        Console::WriteLine("entries[0].Category: {0}",
            entries[0]->Category);

        queue->Close();