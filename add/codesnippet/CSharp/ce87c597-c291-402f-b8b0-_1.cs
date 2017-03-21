	       
	       EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
	       IRequestChannel channel = ChannelFactory<IRequestChannel>.CreateChannel(binding, address);
	       channel.Open();