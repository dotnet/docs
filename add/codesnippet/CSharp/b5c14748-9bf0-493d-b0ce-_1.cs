
        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Create a message queuing transaction.
        MessageQueueTransaction transaction = new MessageQueueTransaction();

        try
        {
            // Begin a transaction.
            transaction.Begin();

            // Send the message to the queue.
            queue.Send(msg, "Example Message Label", transaction);

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
