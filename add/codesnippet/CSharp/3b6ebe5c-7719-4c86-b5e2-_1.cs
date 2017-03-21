        // Create a message sink.
        string objectUri;
        System.Runtime.Remoting.Messaging.IMessageSink messageSink = 
            clientChannel.CreateMessageSink(
            "http://localhost:9090/RemoteObject.rem", 
            null, out objectUri);
        Console.WriteLine(
            "The URI of the message sink is {0}.", 
            objectUri);
        if (messageSink != null)
        {
            Console.WriteLine("The type of the message sink is {0}.", 
                messageSink.GetType().ToString());
        }