
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

    // Create a message queuing transaction.
    MessageQueueTransaction^ transaction = gcnew MessageQueueTransaction();

    try
    {
        // Begin a transaction.
        transaction->Begin();

        // Receive the message from the queue.
        msg = queue->ReceiveById(id, transaction);

        // Commit the transaction.
        transaction->Commit();
    }
    catch (Exception^ ex)
    {
        // Cancel the transaction.
        transaction->Abort();

        // Propagate the exception.
        throw ex;
    }
    finally
    {
        // Dispose of the transaction object.
        delete transaction;
        queue->Close();
    }
