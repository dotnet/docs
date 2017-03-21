
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Designate a queue to receive the acknowledgement message for this
        // message.
        msg.AdministrationQueue = new MessageQueue(".\\exampleAdminQueue");

        // Set the message to generate an acknowledgement message upon its
        // arrival.
        msg.AcknowledgeType = AcknowledgeTypes.PositiveArrival;

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // Connect to the admin queue.
        MessageQueue adminQueue = new MessageQueue(".\\exampleAdminQueue");

        // Set the admin queue's MessageReadPropertyFilter property to ensure
        // that the acknowledgement message includes the desired properties.
        adminQueue.MessageReadPropertyFilter.Acknowledgment = true;
        adminQueue.MessageReadPropertyFilter.CorrelationId = true;

        // Peek at the acknowledgement message.
        Message ackMsg = adminQueue.PeekByCorrelationId(id,
            TimeSpan.FromSeconds(10.0));

        // Display the acknowledgement message's property values.
        Console.WriteLine("Message.Label: {0}", ackMsg.Label);
        Console.WriteLine("Message.Acknowledgment: {0}", ackMsg.Acknowledgment);
        Console.WriteLine("Message.CorrelationId: {0}", ackMsg.CorrelationId);
