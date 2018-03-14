' <snippet4>
Imports System
Imports System.Threading

' The ThreadWithState class contains the information needed for
' a task, the method that executes the task, and a delegate
' to call when the task is complete.
'
Public Class ThreadWithState
    ' State information used in the task.
    Private boilerplate As String
    Private value As Integer

    ' Delegate used to execute the callback method when the
    ' task is complete.
    Private callback As ExampleCallback

    ' The constructor obtains the state information and the
    ' callback delegate.
    Public Sub New(ByVal text As String, ByVal number As Integer, _
                   ByVal callbackDelegate As ExampleCallback)
        boilerplate = text
        value = number
        callback = callbackDelegate
    End Sub

    ' The thread procedure performs the task, such as
    ' formatting and printing a document, and then invokes
    ' the callback delegate with the number of lines printed.
    Public Sub ThreadProc()
        Console.WriteLine(boilerplate, value) 
        If Not callback Is Nothing Then callback(1)
    End Sub
End Class

' Delegate that defines the signature for the callback method.
'
Public Delegate Sub ExampleCallback(ByVal lineCount As Integer)

' Entry point for the example.
'
Public Class Example
    Public Shared Sub Main()
        ' Supply the state information required by the task.
        Dim tws As New ThreadWithState( _
            "This report displays the number {0}.", _
            42, _
            New ExampleCallback(AddressOf ResultCallback) _
        )

        Dim t As New Thread(AddressOf tws.ThreadProc)
        t.Start()
        Console.WriteLine("Main thread does some work, then waits.")
        t.Join()
        Console.WriteLine( _
            "Independent task has completed; main thread ends.")  
    End Sub

    ' The callback method must match the signature of the
    ' callback delegate.
    '
    Public Shared Sub ResultCallback(ByVal lineCount As Integer)
        Console.WriteLine("Independent task printed {0} lines.", _
            lineCount)  
    End Sub
End Class
' </snippet4>
