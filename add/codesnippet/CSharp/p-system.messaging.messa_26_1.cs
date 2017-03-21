
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's Path property value, based on the queue's Path
        // property value.
        attribute.Path = queue.Path;

        // Display the new value of the attribute's Path property.
        Console.WriteLine("attribute.Path: {0}", attribute.Path);
