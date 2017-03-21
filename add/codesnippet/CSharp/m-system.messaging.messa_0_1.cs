        // Get the name of the computer that contains the queue.
        string machineName = queue.MachineName;

        // Display the return value of the MessageQueue.GetMachineId method.
        Console.WriteLine("MessageQueue.GetMachineId(): {0}",
            MessageQueue.GetMachineId(machineName));