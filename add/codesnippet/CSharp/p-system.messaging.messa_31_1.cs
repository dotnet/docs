
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's Label property value, based on the queue's Label
        // property value.
        attribute.Label = queue.Label;

        // Display the new value of the attribute's Label property.
        Console.WriteLine("attribute.Label: {0}", attribute.Label);
