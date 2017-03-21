
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Get an IEnumerator object.
        System.Collections.IEnumerator enumerator = queue.GetEnumerator();

        // Use the IEnumerator object to loop through the messages.
        while(enumerator.MoveNext())
        {
            // Get a message from the enumerator.
            Message msg = (Message)enumerator.Current;

            // Display the label of the message.
            Console.WriteLine(msg.Label);
        }
