' <Snippet1>
Public Class Example
   Public Shared Sub Main()
      Try
         ' Call a method that throws an exception.
         TypeLoadExceptionDemoClass.GenerateException()
      Catch e As TypeLoadException
         Console.WriteLine("TypeLoadException:{0}   {1}", vbCrLf, e.Message)
      End Try
   End Sub 
End Class 

Class TypeLoadExceptionDemoClass
   Public Shared Function GenerateException() As Boolean
      ' Throw a TypeLoadException with a custom message.
      Throw New TypeLoadException("This is a custom TypeLoadException error message.")
   End Function 
End Class 
' The example displays the following output:
'       TypeLoadException:
'          This is a custom TypeLoadException error message.
' </Snippet1>