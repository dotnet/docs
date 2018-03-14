Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description

Namespace UE.Samples.Channel

    Public Class Snippets
        Public Shared Sub Snippet1()
            ' <Snippet1>
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
            ' </Snippet1>
        End Sub

        Public Shared Sub Snippet5()

            ' <Snippet5>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim bindingParameters(2) As Object

            Dim listener As IChannelListener(Of IReplyChannel)
            listener = binding.BuildChannelListener(Of IReplyChannel)(bindingParameters)

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
            ' </Snippet5>
        End Sub

        Public Shared Sub Snippet6()
            ' <Snippet6>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim bindingParameters(2) As Object
            Dim listener As IChannelListener(Of IReplyChannel)
            listener = binding.BuildChannelListener(Of IReplyChannel)(New Uri("http://localhost/channelApp"), bindingParameters)
            ' </Snippet6>
        End Sub

        Public Shared Sub Snippet7()
            ' <Snippet7>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim paramCollection As BindingParameterCollection = New BindingParameterCollection()
            Dim listener As IChannelListener(Of IReplyChannel)
            listener = binding.BuildChannelListener(Of IReplyChannel)(New Uri("http://localhost/channelApp"), "http://localhost/channelApp/service", paramCollection)
            ' </Snippet7>
        End Sub

        Public Shared Sub Snippet8()
            ' <Snippet8>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim bindingParameters(2) As Object
            Dim listener As IChannelListener(Of IReplyChannel)
            listener = binding.BuildChannelListener(Of IReplyChannel)(New Uri("http://localhost/channelApp"), "http://localhost/channelApp/service", bindingParameters)
            ' </Snippet8>
        End Sub

        Public Shared Sub Snippet9()
            ' <Snippet9>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim paramCollection As BindingParameterCollection = New BindingParameterCollection()
            Dim listener As IChannelListener(Of IReplyChannel)
            listener = binding.BuildChannelListener(Of IReplyChannel)(New Uri("http://localhost/channelApp"), "http://localhost/channelApp/service", ListenUriMode.Explicit, paramCollection)
            ' </Snippet9>
        End Sub

        Public Shared Sub Snippet10()
            ' <Snippet10>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim bindingParameters(2) As Object
            Dim listener As IChannelListener(Of IReplyChannel)
            listener = binding.BuildChannelListener(Of IReplyChannel)(New Uri("http://localhost/channelApp"), "http://localhost/channelApp/service", ListenUriMode.Explicit, bindingParameters)
            '</Snippet10>
        End Sub

        Public Shared Sub Snippet13()
            ' <Snippet13>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim paramCollection As BindingParameterCollection = New BindingParameterCollection()

            binding.CanBuildChannelFactory(Of IReplyChannel)(paramCollection)
            ' </Snippet13>
        End Sub

        Public Shared Sub Snippet14()
            ' <Snippet14>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim bindingParameters(2) As Object

            binding.CanBuildChannelFactory(Of IReplyChannel)(bindingParameters)
            '</Snippet14>
        End Sub

        Public Shared Sub Snippet15()
            ' <Snippet15>
            Dim binding As CustomBinding = New CustomBinding()
            binding.Elements.Add(New HttpTransportBindingElement())
            Dim paramCollection As BindingParameterCollection = New BindingParameterCollection()

            binding.GetProperty(Of IReplyChannel)(paramCollection)
            ' </Snippet15>
        End Sub

    End Class
End Namespace
