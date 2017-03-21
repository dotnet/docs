
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Populate an array with copies of all the messages in the queue.
        Message[] msgs = queue.GetAllMessages();

        // Loop through the messages.
        foreach(Message msg in msgs)
        {
            // Display the label of each message.
            Console.WriteLine(msg.Label);
        }
