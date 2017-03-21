
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Refresh the queue's property values to obtain its current state.
        queue.Refresh();
