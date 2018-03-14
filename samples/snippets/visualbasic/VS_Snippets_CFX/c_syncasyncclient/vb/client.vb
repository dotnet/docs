' <snippet5>

Imports System
Imports System.ServiceModel

Public Class Client

  Private Sub Run()
	' Picks up configuration from the config file.
	Using wcfClient As New SampleServiceClient()
	  Try
		' Make asynchronous call.
		Console.WriteLine("Enter the greeting to send asynchronously: ")
                Dim greeting As String = Console.ReadLine()
		Dim waitResult As IAsyncResult = wcfClient.BeginSampleMethod(greeting, New AsyncCallback(AddressOf ProcessResponse), wcfClient)
		Console.ForegroundColor = ConsoleColor.Blue
		Console.WriteLine("Sent asynchronous method. Waiting on the response.")
		waitResult.AsyncWaitHandle.WaitOne()
		Console.ResetColor()

		' Make synchronous call.
		Console.WriteLine("Enter the greeting to send synchronously: ")
		greeting = Console.ReadLine()
		Console.ForegroundColor = ConsoleColor.Blue
		Console.Write("Response: ")
		Console.ForegroundColor = ConsoleColor.Red
		Console.WriteLine(wcfClient.SampleMethod(greeting))
		Console.ResetColor()

		' Make synchronous call on asynchronous method.
		Console.WriteLine("Enter the greeting to send synchronously to async service operation: ")
		greeting = Console.ReadLine()
		Console.ForegroundColor = ConsoleColor.Blue
		Console.Write("Response: ")
		Console.ForegroundColor = ConsoleColor.Red
		Console.WriteLine(wcfClient.ServiceAsyncMethod(greeting))
		Console.ResetColor()

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
	End Using
  End Sub

  Private Sub ProcessResponse(ByVal result As IAsyncResult)
	Try
	  Console.ForegroundColor = ConsoleColor.Blue
	  Console.WriteLine("In the async response handler.")
	  Dim responseClient As SampleServiceClient = CType(result.AsyncState, SampleServiceClient)
            Dim response As String = responseClient.EndSampleMethod(result)
	  Console.Write("ProcessResponse: ")
	  Console.ForegroundColor = ConsoleColor.Red
	  Console.WriteLine(response)
	  Console.ResetColor()
	Catch timeProblem As TimeoutException
	  Console.WriteLine("The service operation timed out. " & timeProblem.Message)
	Catch commProblem As CommunicationException
	  Console.WriteLine("There was a communication problem. " & commProblem.Message)
	Catch e As Exception
	  Console.WriteLine("There was an exception: " & e.Message)
	End Try
  End Sub

  Public Shared Sub Main()
	Dim thisClient As New Client()
	thisClient.Run()
  End Sub
End Class
' </snippet5>
