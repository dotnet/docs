
    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Populate an array with copies of all the messages in the queue.
    array<Message^>^ msgs = queue->GetAllMessages();

    // Loop through the messages.
    for each(Message^ msg in msgs)
    {
        // Display the label of each message.
        Console::WriteLine(msg->Label);
    }

    queue->Close();
