Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description


Public Class clientSnippets

    Public Shared Sub Snippet11()
        ' <Snippet11>
        Dim binding As CustomBinding = New CustomBinding()
        binding.Elements.Add(New HttpTransportBindingElement())
        Dim paramCollection As BindingParameterCollection = New BindingParameterCollection()

        binding.CanBuildChannelFactory(Of IRequestChannel)(paramCollection)
        ' </Snippet11>
    End Sub

    Public Shared Sub Snippet12()
        ' <Snippet12>
        Dim binding As CustomBinding = New CustomBinding()
        Binding.Elements.Add(New HttpTransportBindingElement())
        Dim bindingParameters(2) As Object

        binding.CanBuildChannelFactory(Of IRequestChannel)(bindingParameters)
        ' </Snippet12>
    End Sub

    Public Shared Sub Snippet3()
        ' <Snippet3>
        Dim binding As CustomBinding = New CustomBinding()
        binding.Elements.Add(New HttpTransportBindingElement())
        Dim bindingParams(2) As Object

        Dim factory As IChannelFactory(Of IRequestChannel) = binding.BuildChannelFactory(Of IRequestChannel)(bindingParams)
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
        ' </Snippet3>
    End Sub

End Class
