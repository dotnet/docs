Imports System
Imports System.ServiceModel.Channels
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples
	' <Snippet10>
	' This is the hosting application. This code can appear directly in the service class as well.
	Friend Class HostApp
		' Host the service within this EXE console application.
		Public Shared Sub Main()
			' <Snippet3>
			' Get MSMQ queue name from appsettings in configuration.
			Dim queueName As String = ConfigurationManager.AppSettings("queueName")

			' Create the transacted MSMQ queue if necessary.
			If (Not MessageQueue.Exists(queueName)) Then
				MessageQueue.Create(queueName, True)
			End If
			' </Snippet3>

			' <Snippet5>
			' Get the base address that is used to listen for WS-MetaDataExchange requests.
			' This is useful to generate a proxy for the client.
			Dim baseAddress As String = ConfigurationManager.AppSettings("baseAddress")

			' Create a ServiceHost for the CalculatorService type.
			Using serviceHost As New ServiceHost(GetType(CalculatorService), New Uri(baseAddress))
				' Open the ServiceHostBase to create listeners and start listening for messages.
				serviceHost.Open()

				' The service can now be accessed.
				Console.WriteLine("The service is ready.")
				Console.WriteLine("Press <ENTER> to terminate service.")
				Console.WriteLine()
				Console.ReadLine()

				' Close the ServiceHostBase to shutdown the service.
				serviceHost.Close()
			End Using
			' </Snippet5>
		End Sub
	End Class
	' </Snippet10>
End Namespace
