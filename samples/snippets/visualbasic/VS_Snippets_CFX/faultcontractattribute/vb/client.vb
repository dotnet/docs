' <snippet3>

Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports Microsoft.WCF.Documentation

Public Class Client
  Public Shared Sub Main()
	' Picks up configuration from the config file.
	Dim wcfClient As New SampleServiceClient()
	Try
	  ' Making calls.
	  Console.WriteLine("Enter the greeting to send: ")
	  Dim greeting As String = Console.ReadLine()
	  Console.WriteLine("The service responded: " & wcfClient.SampleMethod(greeting))

	  Console.WriteLine("Press ENTER to exit:")
	  Console.ReadLine()

	  ' Done with service. 
	  wcfClient.Close()
	  Console.WriteLine("Done!")
	Catch timeProblem As TimeoutException
	  Console.WriteLine("The service operation timed out. " & timeProblem.Message)
	  Console.ReadLine()
	  wcfClient.Abort()
	Catch greetingFault As FaultException(Of GreetingFault)
	  Console.WriteLine(greetingFault.Detail.Message)
	  Console.ReadLine()
	  wcfClient.Abort()
	Catch unknownFault As FaultException
	  Console.WriteLine("An unknown exception was received. " & unknownFault.Message)
	  Console.ReadLine()
	  wcfClient.Abort()
	Catch commProblem As CommunicationException
	  Console.WriteLine("There was a communication problem. " & commProblem.Message + commProblem.StackTrace)
	  Console.ReadLine()
	  wcfClient.Abort()
	End Try
  End Sub
End Class
' </snippet3>
