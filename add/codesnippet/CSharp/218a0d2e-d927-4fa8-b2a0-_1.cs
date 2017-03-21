        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission permission = new MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection collection =
            permission.PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.MachineName,
            queue.Label,
            queue.Category.ToString());

        // Add the entry to the collection.
        collection.Add(entry);

        // Show that the collection contains the entry.
        Console.WriteLine("Collection contains first entry (true/false): {0}",
            collection.Contains(entry));

        // Create another new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry newEntry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Send,
            queue.MachineName,
            queue.Label,
            queue.Category.ToString());

        // Show that the collection does not contain the new entry.
        Console.WriteLine("Collection contains second entry (true/false): {0}",
            collection.Contains(newEntry));