' <snippet1>
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://Microsoft.WCF.Documentation", CallbackContract:=GetType(IClientCallbackContract), SessionMode:=SessionMode.Required)> _
  Public Interface ISampleService
	<OperationContract(IsOneWay:=True)> _
	Sub Push(ByVal msg As String)
  End Interface

  Friend Interface IClientCallbackContract
	<OperationContract(IsOneWay := True)> _
	Sub PushBack(ByVal msg As String)
  End Interface

  ' <snippet2>
  Friend Class SampleService
	  Implements ISampleService
  #Region "ISampleService Members"

	Public Sub Push(ByVal msg As String) Implements ISampleService.Push
		 Console.WriteLine("Proxy: " & msg)
	  Me.WriteHeaders(OperationContext.Current.IncomingMessageHeaders)
	  Dim outBoundHeader As MessageHeader = MessageHeader.CreateHeader("Client-Bound-One-Way-Header", "http://Microsoft.WCF.Documentation", "Custom Outbound Header")
	  OperationContext.Current.OutgoingMessageHeaders.Add(outBoundHeader)
	  Console.ForegroundColor = ConsoleColor.Red
	  Console.WriteLine("OutgoingHeader:")
	  Console.Write(vbTab)
	  Console.ForegroundColor = ConsoleColor.Blue
	  Console.WriteLine(outBoundHeader.ToString())
	  Console.ResetColor()
	  OperationContext.Current.GetCallbackChannel(Of IClientCallbackContract)().PushBack("Here's something to examine in response.")
	End Sub

	Private Sub WriteHeaders(ByVal headers As MessageHeaders)
	  Console.ForegroundColor = ConsoleColor.Red
	  Console.WriteLine("IncomingHeader:")
	  Console.ForegroundColor = ConsoleColor.Blue
            For Each h In headers
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
	' </snippet2>

  #End Region
  End Class
End Namespace
' </snippet1>