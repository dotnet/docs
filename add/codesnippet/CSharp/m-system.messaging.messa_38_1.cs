
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label");
