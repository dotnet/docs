'<snippet4>
Imports System.Threading

' The ThreadWithState class contains the information needed for
' a task, the method that executes the task, and a delegate
' to call when the task is complete.
Public Class ThreadWithState
    ' State information used in the task.
    Private boilerplate As String
    Private numberValue As Integer

    ' Delegate used to execute the callback method when the
    ' task is complete.
    Private callback As ExampleCallback

    ' The constructor obtains the state information and the
    ' callback delegate.
    Public Sub New(text As String, number As Integer, _
        callbackDelegate As ExampleCallback)
        boilerplate = text
        numberValue = number
        callback = callbackDelegate
    End Sub

    ' The thread procedure performs the task, such as
    ' formatting and printing a document, and then invokes
    ' the callback delegate with the number of lines printed.
    Public Sub ThreadProc()
        Console.WriteLine(boilerplate, numberValue)
        If Not (callback Is Nothing) Then
            callback(1)
        End If
    End Sub
End Class

' Delegate that defines the signature for the callback method.
'
Public Delegate Sub ExampleCallback(lineCount As Integer)

Public Class Example
    Public Shared Sub Main()
        ' Supply the state information required by the task.
        Dim tws As New ThreadWithState( _
            "This report displays the number {0}.", _
            42, _
            AddressOf ResultCallback)

        Dim t As New Thread(AddressOf tws.ThreadProc)
        t.Start()
        Console.WriteLine("Main thread does some work, then waits.")
        t.Join()
        Console.WriteLine( _
            "Independent task has completed; main thread ends.")
    End Sub

    Public Shared Sub ResultCallback(lineCount As Integer)
        Console.WriteLine( _
            "Independent task printed {0} lines.", lineCount)
    End Sub
End Class
' The example displays the following output:
'       Main thread does some work, then waits.
'       This report displays the number 42.
'       Independent task printed 1 lines.
'       Independent task has completed; main thread ends.
' </snippet4>
