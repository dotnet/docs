        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, queue->Category.ToString());

        // Add the entry to the permission's collection.
        permission->PermissionEntries->Add(entry);

        // Create another new instance of MessageQueuePermission.
        MessageQueuePermission^ newPermission = gcnew MessageQueuePermission();

        // Use AddRange() to append the original permission's collection to the
        // new permission's collection.
        newPermission->PermissionEntries->AddRange(
            permission->PermissionEntries);

        // To show that AddRange() copies collections by value and not by
        // reference, we'll clear the original permission's collection, then
        // display a count of how many entries are in the original permission's
        // collection and how many entries are in the new permission's
        // collection.

        // Clear the original permission's collection.
        permission->PermissionEntries->Clear();

        // The original permission now contains 0 entries, but the new
        // permission still contains 1 entry.
        Console::WriteLine("Original permission contains {0} entries.",
            permission->PermissionEntries->Count);
        Console::WriteLine("New permission contains {0} entries.",
            newPermission->PermissionEntries->Count);

        queue->Close();