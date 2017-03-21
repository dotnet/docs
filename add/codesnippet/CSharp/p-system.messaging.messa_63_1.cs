        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create an array of type MessageQueuePermissionEntry.
        MessageQueuePermissionEntry[] entries =
            new MessageQueuePermissionEntry[1];

        // Create a new instance of MessageQueuePermissionEntry and place the
        // instance in the array.
	string machineName = queue.MachineName;
	string label = queue.Label;
        entries[0] = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            machineName,
            label,
            queue.Category.ToString());

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission permission = new MessageQueuePermission(
            entries);

        // Create a new instance of MessageQueuePermissionEntryCollection and
        // use it to retrieve the permission's PermissionEntries property
        // value.
        MessageQueuePermissionEntryCollection collection =
            permission.PermissionEntries;

        // Loop through the collection.
        foreach(MessageQueuePermissionEntry entry in collection)
        {
            // Display the property values of each MessageQueuePermissionEntry.
            Console.WriteLine("PermissionAccess: {0}", entry.PermissionAccess);
            Console.WriteLine("MachineName: {0}", entry.MachineName);
            Console.WriteLine("Label: {0}", entry.Label);
            Console.WriteLine("Category: {0}", entry.Category.ToString());
        }