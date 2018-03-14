' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim values() As Object = { True, 12.632, 17908, "stringValue",
                                 "a"c, 16907.32d }
      For Each value In values
         Console.WriteLine(value)
      Next                           
   End Sub
End Module
' The example displays the following output:
'    True
'    12.632
'    17908
'    stringValue
'    a
'    16907.32
' </Snippet3>
