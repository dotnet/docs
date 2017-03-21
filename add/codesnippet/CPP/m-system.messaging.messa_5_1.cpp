
    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Reset the queue's permission list to its default values.
    queue->ResetPermissions();

    queue->Close();
