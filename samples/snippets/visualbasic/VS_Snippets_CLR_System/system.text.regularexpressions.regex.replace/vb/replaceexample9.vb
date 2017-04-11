' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "Instantiating a New Type" + vbCrLf + _
                            "Generally, there are two ways that an" + vbCrLf + _
                            "instance of a class or structure can" + vbCrLf + _
                            "be instantiated. "
      Dim pattern As String = "^.*$"
      Dim replacement As String = vbCrLf + "$&"
      Dim rgx As New Regex(pattern, RegexOptions.Multiline)
      Dim result As String = String.Empty 
      
      Dim match As Match = rgx.Match(input)
      ' Double space all but the first line.
      If match.Success Then 
         result = rgx.Replace(input, replacement, -1, match.Index + match.Length + 1)
      End If
      Console.WriteLine(result)                      
   End Sub
End Module
' The example displays the following output:
'       Instantiating a New Type
'       
'       Generally, there are two ways that an
'       
'       instance of a class or structure can
'       
'       be instntiated.
' </Snippet9>
