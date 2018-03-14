' Visual Basic .NET Document
Option Strict On

' <Snippet29>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim task1 = Task.Run(Sub() Throw New CustomException("This exception is expected!"))

      While Not task1.IsCompleted
      End While

      If task1.Status = TaskStatus.Faulted Then
         For Each ex In task1.Exception.InnerExceptions
            ' Handle the custom exception.
            If TypeOf ex Is CustomException Then
               Console.WriteLine(ex.Message)
            ' Rethrow any other exception.
            Else
               Throw ex
            End If
         Next
      End If
   End Sub
End Module

Class CustomException : Inherits Exception
   Public Sub New(s As String)
      MyBase.New(s)
   End Sub
End Class
' The example displays the following output:
'       This exception is expected!
' </Snippet29>
