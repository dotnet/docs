            CustomBinding binding = new CustomBinding();
            HttpTransportBindingElement element = new HttpTransportBindingElement();
            BindingParameterCollection parameters = new BindingParameterCollection();
            Uri baseAddress = new Uri("http://localhost:8000/ChannelApp");
            String relAddress = "http://localhost:8000/ChannelApp/service";
            BindingContext context = new BindingContext(binding, parameters, baseAddress, relAddress, ListenUriMode.Explicit);

            IChannelListener<IReplyChannel> listener = element.BuildChannelListener<IReplyChannel>(context);
            listener.Open();
            IReplyChannel channel = listener.AcceptChannel();
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