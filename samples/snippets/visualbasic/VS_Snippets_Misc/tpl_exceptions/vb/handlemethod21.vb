' Visual Basic .NET Document
Option Strict On

' <Snippet26>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim task1 = Task.Run(Sub() Throw New CustomException("This exception is expected!"))

      Try
         task1.Wait()
      Catch ae As AggregateException
         ' Call the Handle method to handle the custom exception,
         ' otherwise rethrow the exception.
         ae.Handle(Function(e)
                      If TypeOf e Is CustomException Then
                         Console.WriteLine(e.Message)
                      End If
                      Return TypeOf e Is CustomException
                   End Function)
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
' </Snippet26>

