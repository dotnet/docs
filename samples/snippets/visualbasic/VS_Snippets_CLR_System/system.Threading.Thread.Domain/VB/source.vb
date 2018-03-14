' <Snippet1>
Imports System
Imports System.Threading

Public Class Test

    <MTAThread> _
    Shared Sub Main()
        Dim newThread As New Thread(AddressOf ThreadMethod)
        newThread.Start()
    End Sub

    Shared Sub ThreadMethod()
        Console.WriteLine( _
            "Thread {0} started in {1} with AppDomainID = {2}.", _
            AppDomain.GetCurrentThreadId().ToString(), _
            Thread.GetDomain().FriendlyName, _
            Thread.GetDomainID().ToString())
    End Sub

End Class
' </Snippet1>