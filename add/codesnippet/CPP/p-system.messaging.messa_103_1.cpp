
    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's Category property value, based on the queue's
    // Category property value.
    attribute->Category = queue->Category.ToString();

    // Display the new value of the attribute's Category property.
    Console::WriteLine("attribute->Category: {0}",
        attribute->Category);

    queue->Close();