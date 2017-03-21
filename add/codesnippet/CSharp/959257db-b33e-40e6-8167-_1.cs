           BasicHttpBinding binding = new BasicHttpBinding();
           EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
           ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>(binding, address);