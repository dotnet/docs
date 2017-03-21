        // Parse the object URL.
        string objectUrl = "ipc://localhost:9090/RemoteObject.rem";
        string objectUri;
        string channelUri = clientChannel.Parse(objectUrl, out objectUri);
        Console.WriteLine("The object URL is {0}.", objectUrl);
        Console.WriteLine("The object URI is {0}.", objectUri);
        Console.WriteLine("The channel URI is {0}.", channelUri);