            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            BindingParameterCollection paramCollection = new BindingParameterCollection();
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (new Uri("http://localhost:8000/ChannelApp"), paramCollection);

            listener.Open();
            IReplyChannel channel = listener.AcceptChannel();
            Console.WriteLine("Listening for messages");
            channel.Open();
            RequestContext request = channel.ReceiveRequest();
            Message msg = request.RequestMessage;
            Console.WriteLine("Message Received");
            Console.WriteLine("Message Action: {0}", msg.Headers.Action);

            if (msg.Headers.Action == "hello")
            {
                Message reply = Message.CreateMessage(MessageVersion.Default, "wcf");
                request.Reply(reply);
            }

            msg.Close();
            channel.Close();
            listener.Close();