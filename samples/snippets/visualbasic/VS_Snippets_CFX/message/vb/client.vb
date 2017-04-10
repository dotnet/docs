'<snippet0>


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization

Namespace ConsoleApplication1
	Friend Class client


		Private Shared Sub RunClient()
			'Step1: create a binding with just HTTP
			Dim binding As New CustomBinding()
			binding.Elements.Add(New HttpTransportBindingElement())
			'Step2: use the binding to build the channel factory
			Dim factory As IChannelFactory(Of IRequestChannel) = binding.BuildChannelFactory(Of IRequestChannel)(New BindingParameterCollection())
			'open the channel factory
			factory.Open()
			'Step3: use the channel factory to create a channel
			Dim channel As IRequestChannel = factory.CreateChannel(New EndpointAddress("http://localhost:8080/channelapp"))
			channel.Open()
			'Step4: create a message
			Dim requestmessage As Message = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "http://contoso.com/someaction", "This is the body data")
			'send message
			Dim replymessage As Message = channel.Request(requestmessage)
			Console.WriteLine("Reply message received")
			Console.WriteLine("Reply action: {0}", replymessage.Headers.Action)
            Dim data = replymessage.GetBody(Of String)()
			Console.WriteLine("Reply content: {0}", data)
			'Step5: don't forget to close the message
			requestmessage.Close()
			replymessage.Close()
			'don't forget to close the channel
			channel.Close()
			'don't forget to close the factory
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
'</snippet0>