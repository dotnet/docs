        // Connect to a queue on the local computer. You must set the queue's
        // Path property before you can use the queue.
        MessageQueue queue = new MessageQueue();
        queue.Path = ".\\exampleQueue";