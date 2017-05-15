' <snippet3>
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Security.Principal
Imports System.Threading

Namespace Microsoft.WCF.Documentation
  Public Class Client
	Public Sub Run()
	  ' Picks up configuration from the config file.
	  Dim wcfClient As New SampleHelloClient()
	  Try
		' Set the client credentials to permit impersonation. You can do this programmatically or in the configuration file.
		wcfClient.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation

		' Make calls using the proxy.
		Console.ForegroundColor = ConsoleColor.White
		Console.WriteLine("Enter a greeting to send and press ENTER: ")
		Console.Write(">>> ")
		Console.ForegroundColor = ConsoleColor.Green
                Dim greeting = Console.ReadLine()
		Console.ForegroundColor = ConsoleColor.White
		Console.WriteLine("Called service with: " & vbCrLf & vbTab & greeting)
		Console.WriteLine("Service returned: " & wcfClient.Hello(greeting))
		Console.ForegroundColor = ConsoleColor.Blue
		Console.Write("Press ")
		Console.ForegroundColor = ConsoleColor.Red
		Console.Write("ENTER")
		Console.ForegroundColor = ConsoleColor.Blue
		Console.Write(" to exit...")
		Console.ReadLine()
		wcfClient.Close()
	  Catch timeProblem As TimeoutException
		Console.WriteLine("The service operation timed out. " & timeProblem.Message)
		wcfClient.Abort()
		Console.Read()
	  Catch commProblem As CommunicationException
		Console.WriteLine("There was a communication problem. " & commProblem.Message)
		wcfClient.Abort()
		Console.Read()
	  End Try
	End Sub
	Public Shared Sub Main()
	  Dim client As New Client()
	  client.Run()
	End Sub
  End Class
End Namespace
' </snippet3>
