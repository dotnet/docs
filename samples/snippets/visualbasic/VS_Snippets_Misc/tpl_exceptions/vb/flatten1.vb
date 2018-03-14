' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim task1 = Task.Factory.StartNew(Sub()
                                           Dim child1 = Task.Factory.StartNew(Sub()
                                                                                 Dim child2 = Task.Factory.StartNew(Sub()
                                                                                                                       Throw New CustomException("Attached child2 faulted.")
                                                                                                                    End Sub,
                                                                                                                    TaskCreationOptions.AttachedToParent)
                                                                                                                    Throw New CustomException("Attached child1 faulted.")
                                                                              End Sub,
                                                                              TaskCreationOptions.AttachedToParent)
                                        End Sub)

      Try
         task1.Wait()
      Catch ae As AggregateException
         For Each ex In ae.Flatten().InnerExceptions
            If TypeOf ex Is CustomException Then
               Console.WriteLine(ex.Message)
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
'       Attached child1 faulted.
'       Attached child2 faulted.
' </Snippet2>

