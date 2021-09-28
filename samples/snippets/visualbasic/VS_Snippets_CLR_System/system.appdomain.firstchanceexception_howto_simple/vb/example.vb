'<Snippet1>
'<Snippet2>
Imports System.Runtime.ExceptionServices

Class Example

    Shared Sub Main()

        AddHandler AppDomain.CurrentDomain.FirstChanceException,
                   Sub(source As Object, e As FirstChanceExceptionEventArgs)
                       Console.WriteLine("FirstChanceException event raised in {0}: {1}",
                                         AppDomain.CurrentDomain.FriendlyName,
                                         e.Exception.Message)
                   End Sub
        '</Snippet2>

        '<Snippet3>
        Try
            Throw New ArgumentException("Thrown in " & AppDomain.CurrentDomain.FriendlyName)

        Catch ex As ArgumentException

            Console.WriteLine("ArgumentException caught in {0}: {1}",
                AppDomain.CurrentDomain.FriendlyName, ex.Message)
        End Try
        '</Snippet3>

        '<Snippet4>
        Throw New ArgumentException("Thrown in " & AppDomain.CurrentDomain.FriendlyName)
    End Sub
End Class
'</Snippet4>

'<Snippet5>
' This example produces output similar to the following:
'
'FirstChanceException event raised in Example.exe: Thrown in Example.exe
'ArgumentException caught in Example.exe: Thrown in Example.exe
'FirstChanceException event raised in Example.exe: Thrown in Example.exe
'
'Unhandled Exception: System.ArgumentException: Thrown in Example.exe
'   at Example.Main()
'</Snippet5>
'</Snippet1>
