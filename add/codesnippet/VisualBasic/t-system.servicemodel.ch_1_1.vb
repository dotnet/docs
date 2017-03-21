            Dim binding As New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim paramCollection As New BindingParameterCollection()

            Dim listener As IChannelListener(Of IReplyChannel)
            listener = binding.BuildChannelListener(Of IReplyChannel)(New Uri("http://localhost/channelApp"), paramCollection)

            listener.Open()
            Dim channel As IReplyChannel = listener.AcceptChannel()
            Console.WriteLine("Listening for messages")
            channel.Open()
            Dim request As RequestContext = channel.ReceiveRequest()
            Dim msg As Message = request.RequestMessage
            Console.WriteLine("Message Received")
            Console.WriteLine("Message Action: {0}", msg.Headers.Action)

            If (msg.Headers.Action = "hello") Then

                Dim reply As Message = Message.CreateMessage(MessageVersion.Default, "wcf")
                request.Reply(reply)
            End If

            msg.Close()
            channel.Close()
            listener.Close()