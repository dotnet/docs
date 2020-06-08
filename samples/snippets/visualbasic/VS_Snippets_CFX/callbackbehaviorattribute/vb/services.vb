' <snippet1>

Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Threading

Namespace Microsoft.WCF.Documentation
    <ServiceContract(Name:="SampleDuplexHello", Namespace:="http://microsoft.wcf.documentation", CallbackContract:=GetType(IHelloCallbackContract), SessionMode:=SessionMode.Required)> _
    Public Interface IDuplexHello
        <OperationContract(IsOneWay:=True)> _
        Sub Hello(ByVal greeting As String)
    End Interface

    Public Interface IHelloCallbackContract
        <OperationContract(IsOneWay:=True)> _
        Sub Reply(ByVal responseToGreeting As String)
    End Interface

    Public Class DuplexHello
        Implements IDuplexHello

        Public Sub New()
            Console.WriteLine("Service object created: " & Me.GetHashCode().ToString())
        End Sub

        Protected Overrides Sub Finalize()
            Console.WriteLine("Service object destroyed: " & Me.GetHashCode().ToString())
        End Sub

        Public Sub Hello(ByVal greeting As String) Implements IDuplexHello.Hello
            Console.WriteLine("Caller sent: " & greeting)
            Console.WriteLine("Session ID: " & OperationContext.Current.SessionId)
            Console.WriteLine("Waiting two seconds before returning call.")
            ' Put a slight delay to demonstrate asynchronous behavior on client.
            Thread.Sleep(2000)
            Dim callerProxy As IHelloCallbackContract = OperationContext.Current.GetCallbackChannel(Of IHelloCallbackContract)()
            Dim response As String = "Service object " & Me.GetHashCode().ToString() & " received: " & greeting
            Console.WriteLine("Sending back: " & response)
            callerProxy.Reply(response)
        End Sub
    End Class
End Namespace
' </snippet1>
