'<snippet3>
Imports System.Threading

' The ThreadWithState class contains the information needed for
' a task, and the method that executes the task.
Public Class ThreadWithState
    ' State information used in the task.
    Private boilerplate As String
    Private value As Integer

    ' The constructor obtains the state information.
    Public Sub New(text As String, number As Integer)
        boilerplate = text
        value = number
    End Sub

    ' The thread procedure performs the task, such as formatting
    ' and printing a document.
    Public Sub ThreadProc()
        Console.WriteLine(boilerplate, value)
    End Sub
End Class

' Entry point for the example.
'
Public Class Example
    Public Shared Sub Main()
        ' Supply the state information required by the task.
        Dim tws As New ThreadWithState( _
            "This report displays the number {0}.", 42)

        ' Create a thread to execute the task, and then
        ' start the thread.
        Dim t As New Thread(New ThreadStart(AddressOf tws.ThreadProc))
        t.Start()
        Console.WriteLine("Main thread does some work, then waits.")
        t.Join()
        Console.WriteLine( _
            "Independent task has completed main thread ends.")
    End Sub
End Class
' The example displays the following output:
'       Main thread does some work, then waits.
'       This report displays the number 42.
'       Independent task has completed; main thread ends.
'</snippet3>
