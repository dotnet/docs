' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Module Example
   Public Sub Main()
       Dim values() As Integer
       For ctr As Integer = 0 To 9
          values(ctr) = ctr * 2
       Next
          
       For Each value In values
          Console.WriteLine(value)
       Next      
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: 
'       System.NullReferenceException: Object reference not set to an instance of an object.
'       at Example.Main()
' </Snippet10>
