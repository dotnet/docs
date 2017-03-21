        string name = "RemotingServer";
        int port = 9090;
        HttpServerChannel serverChannel = 
            new HttpServerChannel(name, port);