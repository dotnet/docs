
    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create an AccessControlList.
    AccessControlList^ list = gcnew AccessControlList();

    // Create a new trustee to represent the "Everyone" user group.
    Trustee^ tr = gcnew Trustee("Everyone");

    // Create an AccessControlEntry, granting the trustee read access to
    // the queue.
    AccessControlEntry^ entry = gcnew AccessControlEntry(
        tr, GenericAccessRights::Read,
        StandardAccessRights::Read,
        AccessControlEntryType::Allow);

    // Add the AccessControlEntry to the AccessControlList.
    list->Add(entry);

    // Apply the AccessControlList to the queue.
    queue->SetPermissions(list);

    queue->Close();
