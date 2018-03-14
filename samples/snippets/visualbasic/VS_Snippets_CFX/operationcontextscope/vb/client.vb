' <snippet3>
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Threading

Public Class Client
	Implements ISampleServiceCallback
  Private wait As ManualResetEvent = Nothing

  Private Sub New()
	Me.wait = New ManualResetEvent(False)
  End Sub

  Public Shared Sub Main()
	Dim client As New Client()
	client.Run()
  End Sub

  Private Sub Run()
	' Picks up configuration from the config file.
	' <snippet4>
	Dim wcfClient As New SampleServiceClient(New InstanceContext(Me))
	Try
	  Using scope As New OperationContextScope(wcfClient.InnerChannel)
                Dim header As MessageHeader = MessageHeader.CreateHeader("Service-Bound-CustomHeader", _
                                    "http://Microsoft.WCF.Documentation", "Custom Happy Value.")
		OperationContext.Current.OutgoingMessageHeaders.Add(header)

		' Making calls.
		Console.WriteLine("Enter the greeting to send: ")
		Dim greeting As String = Console.ReadLine()

		'Console.ReadLine();
                header = MessageHeader.CreateHeader("Service-Bound-OneWayHeader", _
                                                    "http://Microsoft.WCF.Documentation", "Different Happy Value.")
		OperationContext.Current.OutgoingMessageHeaders.Add(header)

		' One-way
		wcfClient.Push(greeting)
		Me.wait.WaitOne()

		' Done with service. 
		wcfClient.Close()
		Console.WriteLine("Done!")
		Console.ReadLine()
	  End Using
	Catch timeProblem As TimeoutException
	  Console.WriteLine("The service operation timed out. " & timeProblem.Message)
	  Console.ReadLine()
	  wcfClient.Abort()
	Catch commProblem As CommunicationException
	  Console.WriteLine("There was a communication problem. " & commProblem.Message)
	  Console.ReadLine()
	  wcfClient.Abort()
	End Try
	' </snippet4>
  End Sub

  ' <snippet5>

  #Region "ISampleServiceCallback Members"

  Public Sub PushBack(ByVal msg As String) Implements ISampleServiceCallback.PushBack
	Console.WriteLine("Service said: " & msg)
	Me.WriteHeaders(OperationContext.Current.IncomingMessageHeaders)
	Me.wait.Set()
  End Sub

  Private Sub WriteHeaders(ByVal headers As MessageHeaders)
	Console.ForegroundColor = ConsoleColor.Red
	Console.WriteLine("IncomingHeader:")
	Console.ForegroundColor = ConsoleColor.Blue
	For Each h As MessageHeaderInfo In headers
	  If Not h.Actor.Equals(String.Empty) Then
		Console.WriteLine(vbTab & h.Actor)
	  End If
	  Console.ForegroundColor = ConsoleColor.White
	  Console.WriteLine(vbTab & h.Name)
	  Console.ForegroundColor = ConsoleColor.Blue
	  Console.WriteLine(vbTab & h.Namespace)
	  Console.WriteLine(vbTab & h.Relay)
	  If h.IsReferenceParameter = True Then
		Console.WriteLine("IsReferenceParameter header detected: " & h.ToString())
	  End If
	Next h
	Console.ResetColor()
  End Sub
  #End Region
  ' </snippet5>

End Class
' </snippet3>
