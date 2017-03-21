    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void ProcessMessage (IMessage message,
                                ITransportHeaders requestHeaders,
                                Stream requestStream,
                                out ITransportHeaders responseHeaders,
                                out Stream responseStream)
    {
        // Print the request message properties.
        Console.WriteLine("---- Message from the client ----");
        IDictionary dictionary = message.Properties;
        foreach (Object key in dictionary.Keys)
        {
            Console.WriteLine("{0} = {1}", key, dictionary[key]);
        }
        Console.WriteLine("---------------------------------");

        // Hand off to the next sink in the chain.
        nextSink.ProcessMessage(message, requestHeaders, requestStream, out responseHeaders, out responseStream);
    } 