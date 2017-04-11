' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is a sentence. This is another sentence."
      Dim pattern As String = "\b(\w+\s*)+\."
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
'       Matched text: This is a sentence.
'          Group 1:  sentence
'             Capture 0: This
'             Capture 1: is
'             Capture 2: a
'             Capture 3: sentence
' </Snippet2>
