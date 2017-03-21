
	       EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
	       Uri uri = new Uri("http://localhost:8000/Via");

	       IRequestChannel channel =
		  ChannelFactory<IRequestChannel>.CreateChannel(binding, address, uri);
	       channel.Open();