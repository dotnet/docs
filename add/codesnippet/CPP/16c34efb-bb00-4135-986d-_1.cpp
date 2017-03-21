
    // Connect to a nontransactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message to the nontransactional queue.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the nontransactional queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0));

    // Connect to a transactional queue on the local computer.
    MessageQueue^ transQueue = 
        gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message in response to the original message.
    Message^ responseMsg = gcnew Message("Example Response Message Body");

    // Set the response message's CorrelationId property value to the Id
    // property value of the original message.
    responseMsg->CorrelationId = id;

    // Send the response message to the transactional queue.
    transQueue->Send(responseMsg, "Example Response Message Label",
        MessageQueueTransactionType::Single);

    // Set the transactional queue's MessageReadPropertyFilter property to
    // ensure that the response message includes the desired properties.
    transQueue->MessageReadPropertyFilter->CorrelationId = true;

    // Create a message queuing transaction.
    MessageQueueTransaction^ transaction = gcnew MessageQueueTransaction();

    try
    {
        // Begin a transaction.
        transaction->Begin();

        // Receive the response message from the transactional queue.
        responseMsg = transQueue->ReceiveByCorrelationId(id,
            TimeSpan::FromSeconds(10.0), transaction);

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
        transQueue->Close();
        queue->Close();
    }

    // Display the response message's property values.
    Console::WriteLine("Message.Label: {0}", responseMsg->Label);
    Console::WriteLine("Message.CorrelationId: {0}",
        responseMsg->CorrelationId);
                       	