' <snippet2>

Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration

Namespace ProgrammingChannels
    Friend Class Client

        Private Shared Sub RunClient()
            'Step1: Create a binding with just HTTP.
            Dim bindingElements(1) As BindingElement = {New TextMessageEncodingBindingElement(), _
                                                        New HttpTransportBindingElement()}
            Dim binding As New CustomBinding(bindingElements)

            'Step2: Use the binding to build the channel factory.
            Dim factory = binding.BuildChannelFactory(Of IRequestChannel)(New BindingParameterCollection())
            'Open the channel factory.
            factory.Open()

            'Step3: Use the channel factory to create a channel.
            Dim channel = factory.CreateChannel(New EndpointAddress("http://localhost:8080/channelapp"))
            channel.Open()

            'Step4: Create a message.
            Dim requestmessage = Message.CreateMessage(binding.MessageVersion, _
                                                       "http://contoso.com/someaction", _
                                                       "This is the body data")
            'Send message.
            Dim replymessage = channel.Request(requestmessage)
            Console.WriteLine("Reply message received")
            Console.WriteLine("Reply action: {0}", replymessage.Headers.Action)
            Dim data = replymessage.GetBody(Of String)()
            Console.WriteLine("Reply content: {0}", data)

            'Step5: Do not forget to close the message.
            replymessage.Close()
            'Do not forget to close the channel.
            channel.Close()
            'Do not forget to close the factory.
            factory.Close()
        End Sub

        Public Shared Sub Main()

            Console.WriteLine("Press [ENTER] when service is ready")
            Console.ReadLine()
            RunClient()
            Console.WriteLine("Press [ENTER] to exit")
            Console.ReadLine()

        End Sub
    End Class
End Namespace
' </snippet2>