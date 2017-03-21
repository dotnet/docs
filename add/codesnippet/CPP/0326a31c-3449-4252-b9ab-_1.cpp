
    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, MessageQueueTransactionType::Single);

    // Set the formatter to indicate the message body contains a String.
    queue->Formatter = gcnew XmlMessageFormatter(
        gcnew array<Type^>{String::typeid});

    // Receive the message from the queue. Because the Id of the message
    // is not specified, it might not be the message just sent.
    msg = queue->Receive(TimeSpan::FromSeconds(10.0),
        MessageQueueTransactionType::Single);

    queue->Close();
