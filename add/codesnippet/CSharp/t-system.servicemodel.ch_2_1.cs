	       BasicHttpBinding binding = new BasicHttpBinding();
	       EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");

	       ChannelFactory<IRequestChannel> factory =
		       new ChannelFactory<IRequestChannel>(binding, address);

	       IRequestChannel channel = factory.CreateChannel();
	       channel.Open();
	       Message request = Message.CreateMessage(MessageVersion.Soap11, "hello");
	       Message reply = channel.Request(request);
	       Console.Out.WriteLine(reply.Headers.Action);
	       reply.Close();
	       channel.Close();
	       factory.Close();
       }	   