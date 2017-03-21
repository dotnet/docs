        // Create a message sink.
        string messageSinkUri;
        System.Runtime.Remoting.Messaging.IMessageSink messageSink =
            clientChannel.CreateMessageSink(
                "ipc://localhost:9090/RemoteObject.rem", null,
                out messageSinkUri);
        Console.WriteLine("The URI of the message sink is {0}.",
            messageSinkUri);
        if (messageSink != null)
        {
            Console.WriteLine("The type of the message sink is {0}.",
                messageSink.GetType().ToString());
        }