
    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Create a message queuing transaction.
    MessageQueueTransaction^ transaction = gcnew MessageQueueTransaction();

    try
    {
        // Begin a transaction.
        transaction->Begin();

        // Send the message to the queue.
        queue->Send(msg, "Example Message Label", transaction);

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
