' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim task1 = Task.Run(Sub()
                                 Dim nestedTask1 = Task.Run(Sub()
                                                                Throw New CustomException("Detached child task faulted.")
                                                            End Sub)
                                 ' Here the exception will be escalated back to joining thread.
                                 ' We could use try/catch here to prevent that.
                                 nestedTask1.Wait()
                             End Sub)

        Try
            task1.Wait()
        Catch ae As AggregateException
            For Each ex In ae.Flatten().InnerExceptions
                If TypeOf ex Is CustomException Then
                    ' Recover from the exception. Here we just
                    ' print the message for demonstration purposes.
                    Console.WriteLine(ex.Message)
                End If
            Next
        End Try
    End Sub
End Module

Class CustomException : Inherits Exception
    Public Sub New(s As String)
        MyBase.New(s)
    End Sub
End Class
' The example displays the following output:
'       Detached child task faulted.
' </Snippet3>


