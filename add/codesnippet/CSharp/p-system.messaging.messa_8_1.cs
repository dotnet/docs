
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's MachineName property value, based on the queue's
        // MachineName property value.
        attribute.MachineName = queue.MachineName;

        // Display the new value of the attribute's MachineName property.
        Console.WriteLine("attribute.MachineName: {0}",
            attribute.MachineName);
