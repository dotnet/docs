' <snippet1>
Imports System.ServiceModel.Channels

Namespace ProgrammingChannels
    Friend Class Service

        Private Shared Sub RunService()

            'Step1: Create a custom binding with just TCP.
            Dim bindingElements(1) As BindingElement = {New TextMessageEncodingBindingElement(), _
                                                        New HttpTransportBindingElement()}

            Dim binding As New CustomBinding(bindingElements)

            'Step2: Use the binding to build the channel listener.         
            Dim listener = binding.BuildChannelListener(Of IReplyChannel)(New Uri("http://localhost:8080/channelapp"), _
                                                                          New BindingParameterCollection())

            'Step3: Listening for messages.
            listener.Open()
            Console.WriteLine("Listening for incoming channel connections")

            'Wait for and accept incoming connections.
            Dim channel = listener.AcceptChannel()
            Console.WriteLine("Channel accepted. Listening for messages")

            'Open the accepted channel.
            channel.Open()

            'Wait for and receive a message from the channel.
            Dim request = channel.ReceiveRequest()

            'Step4: Reading the request message.
            Dim message = request.RequestMessage
            Console.WriteLine("Message received")
            Console.WriteLine("Message action: {0}", message.Headers.Action)
            Dim data = message.GetBody(Of String)()
            Console.WriteLine("Message content: {0}", data)
            'Send a reply.
            Dim replymessage = Message.CreateMessage(binding.MessageVersion, _
                                                     "http://contoso.com/someotheraction", data)
            request.Reply(replymessage)
            'Step5: Closing objects.
            'Do not forget to close the message.
            message.Close()
            'Do not forget to close RequestContext.
            request.Close()
            'Do not forget to close channels.
            channel.Close()
            'Do not forget to close listeners.
            listener.Close()
        End Sub

        Public Shared Sub Main()

            Service.RunService()
            Console.WriteLine("Press enter to exit")
            Console.ReadLine()

        End Sub

    End Class
End Namespace
' </snippet1>
