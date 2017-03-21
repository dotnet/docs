        // Set the queue's MachineName property value to the name of the local
        // computer.
        queue.MachineName = ".";

        // Display the new value of the queue's MachineName property.
        Console.WriteLine("MessageQueue.MachineName: {0}", queue.MachineName);