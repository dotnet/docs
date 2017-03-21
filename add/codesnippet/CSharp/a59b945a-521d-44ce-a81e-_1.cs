        // Specify the properties for the server channel.
        System.Collections.IDictionary dict = 
            new System.Collections.Hashtable();
        dict["port"] = 9090;
        dict["authenticationMode"] = "IdentifyCallers";
 
        // Set up the server channel.
        TcpChannel serverChannel = new TcpChannel(dict, null, null);
        ChannelServices.RegisterChannel(serverChannel);    