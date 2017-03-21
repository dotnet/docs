
    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label",
        MessageQueueTransactionType::Single);

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Receive the message from the queue.
    msg = queue->ReceiveById(id, MessageQueueTransactionType::Single);

    queue->Close();
