            CustomBinding binding = new CustomBinding();
            HttpTransportBindingElement element = new HttpTransportBindingElement();
            BindingParameterCollection parameters = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, parameters);

            IChannelFactory<IRequestChannel> factory = element.BuildChannelFactory<IRequestChannel>(context);
            factory.Open();
            EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
            IRequestChannel channel = factory.CreateChannel(address);
            channel.Open();
            Message request = Message.CreateMessage(MessageVersion.Default, "hello");
            Message reply = channel.Request(request);
            Console.Out.WriteLine(reply.Headers.Action);
            reply.Close();
            channel.Close();
            factory.Close();