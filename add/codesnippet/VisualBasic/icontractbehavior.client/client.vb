Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels

Public Class Client
  Public Shared Sub Main()
	' Picks up configuration from the config file.
	Dim wcfClient As New SampleServiceClient()
	Try
	  ' Making calls.
	  Console.WriteLine("Enter the greeting to send: ")
	  Dim greeting As String = Console.ReadLine()
	  Console.WriteLine("The service responded: " & wcfClient.SampleMethod(greeting))

	  ' Done with service. 
	  wcfClient.Close()
	  Console.WriteLine("Done!")
	Catch timeProblem As TimeoutException
	  Console.WriteLine("The service operation timed out. " & timeProblem.StackTrace)
	  wcfClient.Abort()
	Catch commProblem As CommunicationException
	  Console.WriteLine("There was a communication problem. " & commProblem.StackTrace)
	  wcfClient.Abort()
	Finally
	  Console.WriteLine("Press ENTER to exit:")
	  Console.ReadLine()
	End Try
  End Sub
End Class
