
    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's PermissionAccess property value.
    attribute->PermissionAccess = MessageQueuePermissionAccess::Receive;

    // Display the new value of the attribute's PermissionAccess property.
    Console::WriteLine("attribute->PermissionAccess: {0}",
        attribute->PermissionAccess);

    queue->Close();