
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new trustee to represent the "Everyone" user group.
        Trustee tr = new Trustee("Everyone");

        // Create a MessageQueueAccessControlEntry, granting the trustee the
        // right to receive messages from the queue.
        MessageQueueAccessControlEntry entry = new
            MessageQueueAccessControlEntry(
            tr, MessageQueueAccessRights.ReceiveMessage,
            AccessControlEntryType.Allow);

        // Apply the MessageQueueAccessControlEntry to the queue.
        queue.SetPermissions(entry);
