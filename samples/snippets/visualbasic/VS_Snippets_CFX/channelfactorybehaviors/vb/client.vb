
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels

Imports microsoft.wcf.documentation



' <snippet10>
Public Class Client
  Public Shared Sub Main()
	Try
	  ' Picks up configuration from the config file.
	  Dim factory As New ChannelFactory(Of ISampleServiceChannel)("WSHttpBinding_ISampleService")

	  ' Add the client side behavior programmatically to all created channels.
	  factory.Endpoint.Behaviors.Add(New EndpointBehaviorMessageInspector())

	  Dim wcfClientChannel As ISampleServiceChannel = factory.CreateChannel()

	  ' Making calls.
	  Console.WriteLine("Enter the greeting to send: ")
            Dim greeting As String = Console.ReadLine()
	  Console.WriteLine("The service responded: " & wcfClientChannel.SampleMethod(greeting))

	  Console.WriteLine("Press ENTER to exit:")
	  Console.ReadLine()

	  ' Done with service. 
	  wcfClientChannel.Close()
	  Console.WriteLine("Done!")
	Catch timeProblem As TimeoutException
	  Console.WriteLine("The service operation timed out. " & timeProblem.Message)
	  Console.Read()
	Catch fault As FaultException(Of SampleFault)
	  Console.WriteLine("SampleFault fault occurred: {0}", fault.Detail.FaultMessage)
	  Console.Read()
	Catch commProblem As CommunicationException
	  Console.WriteLine("There was a communication problem. " & commProblem.Message)
	  Console.Read()
	End Try
  End Sub
  ' </snippet10>
End Class
