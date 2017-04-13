
Imports System
Imports System.Net
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.Collections.Generic

Namespace CustomHttpHeaderSample
	<ServiceContract> _
	Public Interface IUntypedService
		<OperationContract> _
		Sub ProcessMessage(ByVal input As Message)
	End Interface

	<ServiceContract> _
	Public Interface ITypedService
		<OperationContract> _
		Sub ProcessTypedInput(ByVal input As String)
	End Interface


	Public Class Program
		Implements IUntypedService, ITypedService
		Private Shared serviceHost As ServiceHost
		Private Shared address As New Uri("http://" & Environment.MachineName & ":8000")
		Private Shared epa As New EndpointAddress(address.ToString())

		Shared Sub Main(ByVal args() As String)
			StartService()

			Console.WriteLine("UNTYPED")
			StartUntypedClient()

			Console.WriteLine("TYPED")
			StartTypedClient()

			serviceHost.Close()
			Console.WriteLine("exiting")
			Console.ReadLine()
		End Sub

		Private Shared Sub StartService()
			serviceHost = New ServiceHost(GetType(Program), address)
			Dim binding As New BasicHttpBinding()
			Dim endpoint As New ServiceEndpoint(ContractDescription.GetContract(GetType(IUntypedService)), binding, epa)
			Dim anotherEndpoint As New ServiceEndpoint(ContractDescription.GetContract(GetType(ITypedService)), binding, epa)
			serviceHost.Description.Endpoints.Add(endpoint)
			serviceHost.Description.Endpoints.Add(anotherEndpoint)
			serviceHost.Open()
		End Sub

		Private Shared Sub StartUntypedClient()
            Dim message = BuildMessage()
			Dim channelFactory As New ChannelFactory(Of IUntypedService)(New BasicHttpBinding())
			channelFactory.Open()
            Dim proxy = channelFactory.CreateChannel(epa)

			Try
				proxy.ProcessMessage(message)
				Console.WriteLine("sent untyped message to service")
			Catch e As Exception
				Console.WriteLine("received an exception for the untyped message scenario: " & e.ToString())
			End Try
		End Sub
		' <snippet3>
		Private Shared Function BuildMessage() As Message
            Dim messageToSend As Message = Nothing
			' <snippet2>
			Dim reqProps As New HttpRequestMessageProperty()
			reqProps.SuppressEntityBody = False
			' </snippet2>
			reqProps.Headers.Add("CustomHeader", "Test Value")
			reqProps.Headers.Add(HttpRequestHeader.UserAgent, "my user agent")

			Try
				messageToSend = Message.CreateMessage(MessageVersion.Soap11, "http://tempuri.org/IUntypedService/ProcessMessage", "Hello WCF")
			Catch e As Exception
				Console.WriteLine("got exception when sending message: " & e.ToString())
			End Try

			messageToSend.Properties(HttpRequestMessageProperty.Name) = reqProps
			Return messageToSend
		End Function
		' </snippet3>

		Private Shared Sub StartTypedClient()
			Dim anotherChannelFactory As New ChannelFactory(Of ITypedService)(New BasicHttpBinding())
			anotherChannelFactory.Open()
			Dim typedProxy As ITypedService = anotherChannelFactory.CreateChannel(epa)

			Try
				Dim reqProps As New HttpRequestMessageProperty()
				reqProps.SuppressEntityBody = False
				reqProps.Headers.Add("CustomHeader", "Test Value")
				reqProps.Headers.Add(HttpRequestHeader.UserAgent, "my user agent")
				Using scope As New OperationContextScope(CType(typedProxy, IContextChannel))
					OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, reqProps)
					typedProxy.ProcessTypedInput("this is a typed string message")
				End Using
				Console.WriteLine("sent typed message to service")
			Catch e As Exception
				Console.WriteLine("received an exception for the typed message scenario: " & e.ToString())
			End Try

		End Sub
		' <snippet0>
		Public Sub ProcessMessage(ByVal input As Message) Implements IUntypedService.ProcessMessage
			Try
				Console.WriteLine("ProcessMessage: Message received: " & input.GetBody(Of String)())
                Dim reqProp = CType(input.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)
                Dim customString = reqProp.Headers.Get("CustomHeader")
                Dim userAgent = reqProp.Headers(HttpRequestHeader.UserAgent)
				Console.WriteLine()
				Console.WriteLine("ProcessMessage: Got custom header: {0}, User-Agent: {1}", customString, userAgent)
			Catch e As Exception
				Console.WriteLine("ProcessMessage: got exception: " & e.ToString())
			End Try
		End Sub
		' </snippet0>
		Public Sub ProcessTypedInput(ByVal input As String) Implements ITypedService.ProcessTypedInput
			Try
				Console.WriteLine("ProcessTypedInput: Message received: " & input)
                Dim reqProp = CType(OperationContext.Current.IncomingMessageProperties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)
                Dim customString = reqProp.Headers.Get("CustomHeader")
                Dim userAgent = reqProp.Headers(HttpRequestHeader.UserAgent)

				Console.WriteLine()
				Console.WriteLine("ProcessTypedInput: Got custom header: {0}, User-Agent: {1} ", customString, userAgent)
			Catch e As Exception
				Console.WriteLine("ProcessTypedInput: got exception: " & e.ToString())
			End Try
		End Sub
	End Class
End Namespace

