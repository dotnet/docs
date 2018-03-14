' <snippet3>

Imports Microsoft.VisualBasic
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Threading

Namespace Microsoft.WCF.Documentation
  Public Class Client
	  Implements SampleDuplexHelloCallback
	Private waitHandle As AutoResetEvent

	Public Sub New()
	  waitHandle = New AutoResetEvent(False)
	End Sub

	Public Sub Run()
	  ' Picks up configuration from the config file.
	  Dim wcfClient As New SampleDuplexHelloClient(New InstanceContext(Me))
	  Try
		Console.ForegroundColor = ConsoleColor.White
		Console.WriteLine("Enter a greeting to send and press ENTER: ")
		Console.Write(">>> ")
		Console.ForegroundColor = ConsoleColor.Green
                Dim greeting = Console.ReadLine()
		Console.ForegroundColor = ConsoleColor.White
		Console.WriteLine("Called service with: " & Constants.vbCrLf & Constants.vbTab & greeting)
		wcfClient.Hello(greeting)
		Console.WriteLine("Execution passes service call and moves to the WaitHandle.")
		Me.waitHandle.WaitOne()
		Console.ForegroundColor = ConsoleColor.Blue
		Console.WriteLine("Set was called.")
		Console.Write("Press ")
		Console.ForegroundColor = ConsoleColor.Red
		Console.Write("ENTER")
		Console.ForegroundColor = ConsoleColor.Blue
		Console.Write(" to exit...")
		Console.ReadLine()
		wcfClient.Close()
	  Catch timeProblem As TimeoutException
		Console.WriteLine("The service operation timed out. " & timeProblem.Message)
		Console.ReadLine()
		wcfClient.Abort()
	  Catch commProblem As CommunicationException
		Console.WriteLine("There was a communication problem. " & commProblem.Message)
		Console.ReadLine()
		wcfClient.Abort()
	  End Try
	End Sub

	Public Shared Sub Main()
	  Dim client As New Client()
	  client.Run()
	End Sub

	Public Sub Reply(ByVal response As String) Implements SampleDuplexHelloCallback.Reply
	  Console.WriteLine("Received output.")
	  Console.WriteLine(Constants.vbCrLf & Constants.vbTab & response)
	  Me.waitHandle.Set()
	End Sub
  End Class
End Namespace
' </snippet3>
