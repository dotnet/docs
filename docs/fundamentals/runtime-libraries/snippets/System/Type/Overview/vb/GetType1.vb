' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example1
   Public Sub Main()
      Dim values() As Object = { "word", True, 120, 136.34, "a"c }
      For Each value In values
         Console.WriteLine("{0} - type {1}", value, 
                           value.GetType().Name)
      Next
   End Sub
End Module
' The example displays the following output:
'       word - type String
'       True - type Boolean
'       120 - type Int32
'       136.34 - type Double
'       a - type Char
' </Snippet2>
