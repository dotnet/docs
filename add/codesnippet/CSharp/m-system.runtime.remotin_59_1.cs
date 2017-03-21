        // Set up a server channel.
        TcpServerChannel serverChannel = new TcpServerChannel(9090);
        ChannelServices.RegisterChannel(serverChannel);    