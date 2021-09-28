' <snippet3>

Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Threading

Namespace Microsoft.WCF.Documentation
    <CallbackBehaviorAttribute(IncludeExceptionDetailInFaults:=True, UseSynchronizationContext:=True, ValidateMustUnderstand:=True)> _
    Public Class Client
        Implements SampleDuplexHelloCallback
        Private waitHandle As AutoResetEvent

        Public Sub New()
            waitHandle = New AutoResetEvent(False)
        End Sub

        Public Sub Run()
            ' Picks up configuration from the configuration file.
            Dim wcfClient As New SampleDuplexHelloClient(New InstanceContext(Me), "WSDualHttpBinding_SampleDuplexHello")
            Try
                Console.ForegroundColor = ConsoleColor.White
                Console.WriteLine("Enter a greeting to send and press ENTER: ")
                Console.Write(">>> ")
                Console.ForegroundColor = ConsoleColor.Green
                Dim greeting As String = Console.ReadLine()
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
            Catch timeProblem As TimeoutException
                Console.WriteLine("The service operation timed out. " & timeProblem.Message)
                Console.ReadLine()
            Catch commProblem As CommunicationException
                Console.WriteLine("There was a communication problem. " & commProblem.Message)
                Console.ReadLine()
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
