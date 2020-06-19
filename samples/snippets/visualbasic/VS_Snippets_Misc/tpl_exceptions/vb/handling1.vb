' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim task1 = Task.Run(Sub() Throw New CustomException("This exception is expected!"))

        Try
            task1.Wait()
        Catch ae As AggregateException
            For Each ex In ae.InnerExceptions
                ' Handle the custom exception.
                If TypeOf ex Is CustomException Then
                    Console.WriteLine(ex.Message)
                    ' Rethrow any other exception.
                Else
                    Throw
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
'       This exception is expected!
' </Snippet1>
