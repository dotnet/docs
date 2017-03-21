        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
	string queueCategory = queue.Category.ToString();
	string machineName = queue.MachineName;
	string label = queue.Label;
        MessageQueuePermission permission = new MessageQueuePermission(
            MessageQueuePermissionAccess.Receive,
            machineName,
            label,
            queueCategory);