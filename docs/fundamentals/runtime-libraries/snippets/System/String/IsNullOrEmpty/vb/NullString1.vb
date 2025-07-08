' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim s As String

      Console.WriteLine("The value of the string is '{0}'", s)

      Try 
         Console.WriteLine("String length is {0}", s.Length)
      Catch e As NullReferenceException
         Console.WriteLine(e.Message)
      End Try   
   End Sub
End Module
' The example displays the following output:
'     The value of the string is ''
'     Object reference not set to an instance of an object.
' </Snippet2>

Public Class Empty
   Public Sub Test()
      ' <Snippet3>
      Dim s As String = ""
      Console.WriteLine("The length of '{0}' is {1}.", s, s.Length)
      ' The example displays the following output:
      '        The length of '' is 0.      
      ' </Snippet3>
   End Sub
End Class


