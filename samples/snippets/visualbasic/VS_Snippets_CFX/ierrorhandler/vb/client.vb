' <snippet3>

Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports Microsoft.WCF.Documentation

Public Class Client
  Public Shared Sub Main()
	' Picks up configuration from the configuration file.
	Dim wcfClient As New SampleServiceClient()
	Try
	  ' Making calls.
	  Console.WriteLine("Enter the greeting to send: ")
	  Dim greeting As String = Console.ReadLine()
	  Console.WriteLine("The service responded: " & wcfClient.SampleMethod(greeting))
	  Console.WriteLine("Press ENTER to exit:")
	  Console.ReadLine()
	Catch timeProblem As TimeoutException
	  Console.WriteLine("The service operation timed out. " & timeProblem.Message)
	  wcfClient.Abort()
	  Console.ReadLine()
	' Catch the contractually specified SOAP fault raised here as an exception.
	Catch greetingFault As FaultException(Of GreetingFault)
	  Console.WriteLine(greetingFault.Detail.Message)
	  Console.Read()
	  wcfClient.Abort()
	' Catch unrecognized faults. This handler receives exceptions thrown by WCF
	' services when ServiceDebugBehavior.IncludeExceptionDetailInFaults 
	' is set to true.
	Catch faultEx As FaultException
	  Console.WriteLine("An unknown exception was received. " & faultEx.Message + faultEx.StackTrace)
	  Console.Read()
	  wcfClient.Abort()
	' Standard communication fault handler.
	Catch commProblem As CommunicationException
	  Console.WriteLine("There was a communication problem. " & commProblem.Message + commProblem.StackTrace)
	  Console.Read()
	  wcfClient.Abort()
	End Try
  End Sub
End Class
' </snippet3>
