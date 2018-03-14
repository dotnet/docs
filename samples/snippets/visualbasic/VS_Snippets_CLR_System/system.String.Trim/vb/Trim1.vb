' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim charsToTrim() As Char = { "*"c, " "c, "'"c}
      Dim banner As String = "*** Much Ado About Nothing ***"
      Dim result As String = banner.Trim(charsToTrim)
      Console.WriteLine("Trimmmed{0}   {1}{0}to{0}   '{2}'", _
                        vbCrLf, banner, result)
   End Sub
End Module
' The example displays the following output:
'       Trimmmed
'          *** Much Ado About Nothing ***
'       to
'          'Much Ado About Nothing'
' </Snippet1>
