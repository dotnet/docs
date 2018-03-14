' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      Dim s As String = "0001"
      ConvertNumericString(s)
   End Sub
   
   ' <Snippet1>
   Private Function ConvertNumericString(s As String) As Integer
      Dim number As Integer
      If s.Trim().Length = 8 Then
         Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber,
                        Nothing, number)
      Else
         Int32.TryParse(s, number)
      End If   
      Return number
   End Function   
   ' </Snippet1>
End Module

