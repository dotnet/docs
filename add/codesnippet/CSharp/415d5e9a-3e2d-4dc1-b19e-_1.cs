           BasicHttpBinding binding = new BasicHttpBinding();
           EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
	   Uri via = new Uri("http://localhost:8000/Via");

	   ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>(binding);

           IRequestChannel channel = factory.CreateChannel(address, via);
           channel.Open();
           Message request = Message.CreateMessage(MessageVersion.Soap11, "hello");
           Message reply = channel.Request(request);
           Console.Out.WriteLine(reply.Headers.Action);
           reply.Close();
           channel.Close();
           factory.Close();