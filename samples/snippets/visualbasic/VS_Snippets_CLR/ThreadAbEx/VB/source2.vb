Imports System
Imports System.Threading
Imports System.Security.Permissions

Public Class ThreadWork
    Public Shared Sub DoWork()
        '<Snippet2>
        Try
            ' Code that is executing when the thread is aborted.
            ' Simulated thread work...
            Thread.Sleep(2000)
        Catch ex As ThreadAbortException
            ' Clean-up code can go here.
            ' If there is no Finally clause, ThreadAbortException is
            ' re-thrown by the system at the end of the Catch clause.
            If Not (ex.ExceptionState Is Nothing) Then
                Console.WriteLine("Exception State: {0}", ex.ExceptionState)
            End If
        Finally
            ' Clean-up code can go here.
        End Try
        ' Do not put clean-up code here, because the exception
        ' is rethrown at the end of the Finally clause.
        '</Snippet2>
    End Sub
End Class

Class ThreadAbortTest
    Public Shared Sub Main()
        Dim myThreadDelegate As New ThreadStart(AddressOf ThreadWork.DoWork)
        Dim myThread As New Thread(myThreadDelegate)
        myThread.Start()
        Thread.Sleep(1000)
        myThread.Abort("You are finished!")
        myThread.Join()
    End Sub
End Class
