' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading

Class CancelableObject
    Public id As String

    Public Sub New(id As String)
        Me.id = id
    End Sub

    Public Sub Cancel()
        Console.WriteLine("Object {0} Cancel callback", id)
        ' Perform object cancellation here.
    End Sub
End Class

Module ExampleOb1
    Public Sub MainOb1()
        Dim cts As New CancellationTokenSource()
        Dim token As CancellationToken = cts.Token

        ' User defined Class with its own method for cancellation
        Dim obj1 As New CancelableObject("1")
        Dim obj2 As New CancelableObject("2")
        Dim obj3 As New CancelableObject("3")

        ' Register the object's cancel method with the token's
        ' cancellation request.
        token.Register(Sub() obj1.Cancel())
        token.Register(Sub() obj2.Cancel())
        token.Register(Sub() obj3.Cancel())

        ' Request cancellation on the token.
        cts.Cancel()
        ' Call Dispose when we're done with the CancellationTokenSource.
        cts.Dispose()
    End Sub
End Module
' The example displays output like the following:
'       Object 3 Cancel callback
'       Object 2 Cancel callback
'       Object 1 Cancel callback
' </Snippet2>

