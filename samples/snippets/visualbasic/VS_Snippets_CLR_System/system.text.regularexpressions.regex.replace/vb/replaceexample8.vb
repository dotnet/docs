' Visual Basic .NET Document
' Illustrate Replace(String, String, Int32)
Option Strict On

' <Snippet8>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim str As String = "aabccdeefgghiijkklmm"
      Dim pattern As String = "(\w)\1" 
      Dim replacement As String = "$1" 
      Dim rgx As New Regex(pattern)

      Dim result As String = rgx.Replace(str, replacement, 5)
      Console.WriteLine("Original String:    '{0}'", str)
      Console.WriteLine("Replacement String: '{0}'", result)                             
   End Sub
End Module
' The example displays the following output:
'       Original String:    'aabccdeefgghiijkklmm'
'       Replacement String: 'abcdefghijkklmm'
' </Snippet8>
