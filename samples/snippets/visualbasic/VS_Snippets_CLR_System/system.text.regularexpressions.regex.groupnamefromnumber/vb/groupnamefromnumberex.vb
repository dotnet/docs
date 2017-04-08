' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(?<city>[A-Za-z\s]+), (?<state>[A-Za-z]{2}) (?<zip>\d{5}(-\d{4})?)"
      Dim cityLines() As String = {"New York, NY 10003", "Brooklyn, NY 11238", "Detroit, MI 48204", _
                                   "San Francisco, CA 94109", "Seattle, WA 98109" }
      Dim rgx As New Regex(pattern)
      Dim names As New List(Of String)      
      Dim ctr As Integer = 1
      Dim exitFlag As Boolean = False
      ' Get group names.
      Do 
         Dim name As String = rgx.GroupNameFromNumber(ctr)
         If Not String.IsNullOrEmpty(name) Then
            ctr += 1
            names.Add(name)
         Else
            exitFlag = True
         End If
      Loop While Not exitFlag
      
      For Each cityLine As String In cityLines
         Dim match As Match = rgx.Match(cityLine)
         If match.Success Then
            Console.WriteLine("Zip code {0} is in {1}, {2}.", _
                               match.Groups.Item(names.Item(3)), _
                               match.Groups.Item(names.Item(1)), _
                               match.Groups.Item(names.Item(2)))
         End If   
      Next 
   End Sub
End Module
' The example displays the following output:
'       Zip code 10003 is in New York, NY.
'       Zip code 11238 is in Brooklyn, NY.
'       Zip code 48204 is in Detroit, MI.
'       Zip code 94109 is in San Francisco, CA.
'       Zip code 98109 is in Seattle, WA.
' </Snippet1>
