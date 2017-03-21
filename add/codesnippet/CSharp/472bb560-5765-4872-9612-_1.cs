        // Specify server channel properties.
        IDictionary dict = new Hashtable();
        dict["port"] = 9090;
        dict["authenticationMode"] = "IdentifyCallers";
 
        // Set up a server channel.
        TcpServerChannel serverChannel = new TcpServerChannel(dict, null);
        ChannelServices.RegisterChannel(serverChannel, false);    