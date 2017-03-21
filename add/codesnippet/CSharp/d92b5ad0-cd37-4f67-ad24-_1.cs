           ContractDescription contract = new ContractDescription("MyContract");
           EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
           BasicHttpBinding binding = new BasicHttpBinding();
           ServiceEndpoint endpoint = new ServiceEndpoint(contract, binding, address);
           
           ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>(endpoint);