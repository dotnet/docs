' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As String = { Nothing, String.Empty, "ABCDE", 
                                 New String(" "c, 20), "  " + vbTab + "   ", 
                                 New String(ChrW(&h2000), 10) }
      For Each value As String In values
         Console.WriteLine(String.IsNullOrWhiteSpace(value))
      Next
   End Sub
End Module
' The example displays the following output:
'       True
'       True
'       False
'       True
'       True
'       True
' </Snippet1>
