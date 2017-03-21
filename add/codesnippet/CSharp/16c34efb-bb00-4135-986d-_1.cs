
        // Connect to a nontransactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message to the nontransactional queue.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the nontransactional queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // Connect to a transactional queue on the local computer.
        MessageQueue transQueue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message in response to the original message.
        Message responseMsg = new Message("Example Response Message Body");

        // Set the response message's CorrelationId property value to the Id
        // property value of the original message.
        responseMsg.CorrelationId = id;

        // Send the response message to the transactional queue.
        transQueue.Send(responseMsg, "Example Response Message Label",
            MessageQueueTransactionType.Single);

        // Set the transactional queue's MessageReadPropertyFilter property to
        // ensure that the response message includes the desired properties.
        transQueue.MessageReadPropertyFilter.CorrelationId = true;

        // Create a message queuing transaction.
        MessageQueueTransaction transaction = new MessageQueueTransaction();

        try
        {
            // Begin a transaction.
            transaction.Begin();

            // Receive the response message from the transactional queue.
            responseMsg = transQueue.ReceiveByCorrelationId(id,
                TimeSpan.FromSeconds(10.0), transaction);

            // Commit the transaction.
            transaction.Commit();
        }
        catch(System.Exception e)
        {
            // Cancel the transaction.
            transaction.Abort();

            // Propagate the exception.
            throw e;
        }
        finally
        {
            // Dispose of the transaction object.
            transaction.Dispose();
        }

        // Display the response message's property values.
        Console.WriteLine("Message.Label: {0}", responseMsg.Label);
        Console.WriteLine("Message.CorrelationId: {0}",
            responseMsg.CorrelationId);
