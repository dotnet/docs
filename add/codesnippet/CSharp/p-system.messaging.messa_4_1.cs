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

        // Display the entry's properties, using the collection's Item
        // accessor.
        Console.WriteLine("collection[0].PermissionAccess: {0}",
            collection[0].PermissionAccess);
        Console.WriteLine("collection[0].MachineName: {0}",
            collection[0].MachineName);
        Console.WriteLine("collection[0].Label: {0}", collection[0].Label);
        Console.WriteLine("collection[0].Category: {0}",
            collection[0].Category.ToString());
