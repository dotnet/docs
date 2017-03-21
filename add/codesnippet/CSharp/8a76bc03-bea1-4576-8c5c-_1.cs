
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create an AccessControlList.
        AccessControlList list = new AccessControlList();

        // Create a new trustee to represent the "Everyone" user group.
        Trustee tr = new Trustee("Everyone");

        // Create an AccessControlEntry, granting the trustee read access to
        // the queue.
        AccessControlEntry entry = new AccessControlEntry(
            tr, GenericAccessRights.Read,
 StandardAccessRights.Read,
            AccessControlEntryType.Allow);

        // Add the AccessControlEntry to the AccessControlList.
        list.Add(entry);

        // Apply the AccessControlList to the queue.
        queue.SetPermissions(list);
