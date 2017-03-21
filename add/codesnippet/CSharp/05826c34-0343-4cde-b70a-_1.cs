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