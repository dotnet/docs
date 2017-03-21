            IChannelFactory<IRequestChannel> factory = binding.BuildChannelFactory<IRequestChannel>(bindingParams);
            factory.Open();
            EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
            IRequestChannel channel = factory.CreateChannel(address);
            channel.Open();