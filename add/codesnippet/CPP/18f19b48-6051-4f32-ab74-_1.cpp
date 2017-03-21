
    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, MessageQueueTransactionType::Single);

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Set the formatter to indicate the message body contains a String.
    queue->Formatter = gcnew XmlMessageFormatter(
        gcnew array<Type^>{String::typeid});

    // Receive the message from the queue.  Because the Id of the message
    // , it might not be the message just sent.
    msg = queue->Receive(MessageQueueTransactionType::Single);

    queue->Close();
