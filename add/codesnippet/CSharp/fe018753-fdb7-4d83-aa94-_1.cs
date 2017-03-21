        // Specify client channel properties.
        IDictionary dict = new Hashtable();
        dict["port"] = 9090;
        dict["impersonationLevel"] = "Identify";
        dict["authenticationPolicy"] = "AuthPolicy, Policy";
 
        // Set up a client channel.
        TcpClientChannel clientChannel = new TcpClientChannel(dict, null);
        ChannelServices.RegisterChannel(clientChannel, false);