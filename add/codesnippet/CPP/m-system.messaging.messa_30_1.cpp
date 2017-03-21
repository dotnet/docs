
    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Delete all messages from the queue.
    queue->Purge();

    queue->Close();
