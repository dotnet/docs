
    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's Path property value, based on the queue's Path
    // property value.
    attribute->Path = queue->Path;

    // Get an IPermission interface by calling the attribute's
    // CreatePermission() method.
    System::Security::IPermission^ permission = attribute->CreatePermission();

    queue->Close();