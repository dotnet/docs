
        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label",
            MessageQueueTransactionType.Single);

        // Get the message's Id property value.
        string id = msg.Id;

        // Create a message queuing transaction.
        MessageQueueTransaction transaction = new MessageQueueTransaction();

        try
        {
            // Begin a transaction.
            transaction.Begin();

            // Receive the message from the queue.
            msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0),
                transaction);

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
