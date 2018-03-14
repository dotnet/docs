' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\b(\w+?)[,:;]?\s?)+[?.!]"
      Dim input As String = "This is one sentence. This is a second sentence."

      Dim match As Match = Regex.Match(input, pattern)
      Console.WriteLine("Match: " + match.Value)
      Dim groupCtr As Integer = 0
      For Each group As Group In match.Groups
         groupCtr += 1
         Console.WriteLine("   Group {0}: '{1}'", groupCtr, group.Value)
         Dim captureCtr As Integer = 0
         For Each capture As Capture In group.Captures
            captureCtr += 1
            Console.WriteLine("      Capture {0}: '{1}'", captureCtr, capture.Value)
         Next
      Next   
   End Sub
End Module
' The example displays the following output:
'       Match: This is one sentence.
'          Group 1: 'This is one sentence.'
'             Capture 1: 'This is one sentence.'
'          Group 2: 'sentence'
'             Capture 1: 'This '
'             Capture 2: 'is '
'             Capture 3: 'one '
'             Capture 4: 'sentence'
'          Group 3: 'sentence'
'             Capture 1: 'This'
'             Capture 2: 'is'
'             Capture 3: 'one'
'             Capture 4: 'sentence'
' </Snippet1>
