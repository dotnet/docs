' <Snippet1>
Public Class AppException : Inherits Exception
   Public Sub New(message As String)
      MyBase.New(message)
   End Sub
   
   Public Sub New(message As String, inner As Exception)
      MyBase.New(message, inner)
   End Sub
End Class

Public Class Example
   Public Shared Sub Main()
      Dim testInstance As New Example()
      Try
         testInstance.CatchInner()
      Catch e As AppException
         Console.WriteLine ("In catch block of Main method.")
         Console.WriteLine("Caught: {0}", e.Message)
         If e.InnerException IsNot Nothing Then
            Console.WriteLine("Inner exception: {0}", e.InnerException)
         End If
      End Try
   End Sub
   
   Public Sub ThrowInner()
      Throw New AppException("Exception in ThrowInner method.")
   End Sub
   
   Public Sub CatchInner()
      Try
         Me.ThrowInner()
      Catch e As AppException
         Throw New AppException("Error in CatchInner caused by calling the ThrowInner method.", e)
      End Try
   End Sub
End Class
' The example displays the following output:
'    In catch block of Main method.
'    Caught: Error in CatchInner caused by calling the ThrowInner method.
'    Inner exception: AppException: Exception in ThrowInner method.
'       at Example.CatchInner()
' </Snippet1>