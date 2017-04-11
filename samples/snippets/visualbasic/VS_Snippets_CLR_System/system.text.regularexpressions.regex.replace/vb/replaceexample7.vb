' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String =  "(\p{Sc}\s?)?(\d+\.?((?<=\.)\d+)?)(?(1)|\s?\p{Sc})?"
      Dim input As String = "$17.43  €2 16.33  £0.98  0.43   £43   12€  17"
      Dim replacement As String = "$2"
      Dim rgx As New Regex(pattern)
      Dim result As String = rgx.Replace(input, replacement)

      Console.WriteLine("Original String:    '{0}'", input)
      Console.WriteLine("Replacement String: '{0}'", result)                             
   End Sub
End Module
' The example displays the following output:
'       Original String:    '$17.43  €2 16.33  £0.98  0.43   £43   12€  17'
'       Replacement String: '17.43  2 16.33  0.98  0.43   43   12  17'
' </Snippet7>
