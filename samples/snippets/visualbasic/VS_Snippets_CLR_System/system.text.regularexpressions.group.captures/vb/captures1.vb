' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(\w+)\b"
      Dim input As String = "This is one sentence."
      Dim match As Match = Regex.Match(input, pattern)
      If match.Success Then
         Console.WriteLine("Matched text: {0}", match.Value)
         For ctr As Integer = 1 To match.Groups.Count - 1
            Console.WriteLine("   Group {0}:  {1}", ctr, match.Groups(ctr).Value)
            Dim captureCtr As Integer = 0
            For Each capture As Capture In match.Groups(ctr).Captures
               Console.WriteLine("      Capture {0}: {1}", _
                                 captureCtr, capture.Value)
               captureCtr += 1                  
            Next
         Next
      End If   
   End Sub
End Module
' The example displays the following output:
'       Matched text: This
'          Group 1:  This
'             Capture 0: This
' </Snippet1>
