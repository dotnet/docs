Imports System.ServiceModel
Imports System.ServiceModel.Channels

Public Class Client
  Public Shared Sub Main()
	' Picks up configuration from the config file.
	Dim wcfClient As New SampleServiceClient()
	Try
	  ' Making calls.
	  Console.WriteLine("Enter the greeting to send: ")
            Dim greeting = Console.ReadLine()
	  Console.WriteLine("The service responded: " & wcfClient.OCAMethod(greeting))

	  Console.WriteLine("Press ENTER to exit:")
	  Console.ReadLine()

	  ' Done with service. 
	  wcfClient.Close()
	  Console.WriteLine("Done!")
	Catch timeProblem As TimeoutException
	  Console.WriteLine("The service operation timed out. " & timeProblem.Message)
	  Console.Read()
	  wcfClient.Abort()
	Catch commProblem As CommunicationException
	  Console.WriteLine("There was a communication problem. " & commProblem.Message)
	  Console.Read()
	  wcfClient.Abort()
	End Try
  End Sub
End Class
