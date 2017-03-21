
    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, MessageQueueTransactionType::Single);

    queue->Close();
