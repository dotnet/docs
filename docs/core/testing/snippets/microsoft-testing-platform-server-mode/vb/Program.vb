' <RunClient>
Imports System
Imports TestClientSample

Module Program
    Function Main(args As String()) As Integer
        If args.Length <> 1 Then
            Console.Error.WriteLine("Usage: DiscoverAndRun <test-application-path>")
            Return 1
        End If

        Return TestClient.DiscoverAndRunAsync(args(0)).GetAwaiter().GetResult()
    End Function
End Module
' </RunClient>
