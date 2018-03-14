' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example
   Public Sub Main()
      Dim chars() As Char = { ChrW(&h0061), ChrW(&h0308) }
   
      Dim combining As String = New String(chars)
      Console.WriteLine(combining)
      
      combining = combining.Normalize()
      Console.WriteLine(combining)
   End Sub
End Module
' The example displays the following output:
'       a"
'       ä
' </Snippet5>
