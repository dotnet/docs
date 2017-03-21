        // Set the queue's MaximumQueueSize property to
        // MessageQueue.InfiniteQueueSize.
        queue.MaximumQueueSize = MessageQueue.InfiniteQueueSize;

        // Display the new value of the queue's MaximumQueueSize property.
        Console.WriteLine("MessageQueue.MaximumQueueSize: {0}",
            queue.MaximumQueueSize.ToString());