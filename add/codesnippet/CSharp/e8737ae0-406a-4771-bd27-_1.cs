
        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label",
            MessageQueueTransactionType.Single);

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0),
            MessageQueueTransactionType.Single);
