Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description

Namespace client
    Class client

        Public Shared Sub Main()
            ' <Snippet2>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim paramCollection As BindingParameterCollection = New BindingParameterCollection()

            Dim factory As IChannelFactory(Of IRequestChannel) = binding.BuildChannelFactory(Of IRequestChannel)(paramCollection)
            factory.Open()
            Dim address As EndpointAddress = New EndpointAddress("http://localhost/channelApp/service")
            Dim channel As IRequestChannel = factory.CreateChannel(address)
            channel.Open()
            Dim request As Message = Message.CreateMessage(MessageVersion.Default, "hello")
            Dim reply As Message = channel.Request(request)
            Console.Out.WriteLine(reply.Headers.Action)
            reply.Close()
            channel.Close()
            factory.Close()
            ' </Snippet2>
        End Sub
    End Class
End Namespace
