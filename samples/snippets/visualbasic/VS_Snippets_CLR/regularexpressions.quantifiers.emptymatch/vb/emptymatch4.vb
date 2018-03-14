' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern, input As String
       
      pattern = "(a\1|(?(1)\1)){0,2}"
      input = "aaabbb" 

      Console.WriteLine("Regex pattern: {0}", pattern)
      Dim match As Match = Regex.Match(input, pattern)
      Console.WriteLine("Match: '{0}' at position {1}.", 
                        match.Value, match.Index)
      If match.Groups.Count > 1 Then
         For groupCtr As Integer = 1 To match.Groups.Count - 1
            Dim group As Group = match.Groups(groupCtr)         
            Console.WriteLine("   Group: {0}: '{1}' at position {2}.", 
                              groupCtr, group.Value, group.Index)
            Dim captureCtr As Integer = 0
            For Each capture As Capture In group.Captures
               captureCtr += 1
               Console.WriteLine("      Capture: {0}: '{1}' at position {2}.", 
                                 captureCtr, capture.Value, capture.Index)
            Next   
         Next
      End If
      Console.WriteLine()

      pattern = "(a\1|(?(1)\1)){2}"
      Console.WriteLine("Regex pattern: {0}", pattern)
      match = Regex.Match(input, pattern)
         Console.WriteLine("Matched '{0}' at position {1}.", 
                           match.Value, match.Index)
      If match.Groups.Count > 1 Then
         For groupCtr As Integer = 1 To match.Groups.Count - 1
            Dim group As Group = match.Groups(groupCtr)         
            Console.WriteLine("   Group: {0}: '{1}' at position {2}.", 
                              groupCtr, group.Value, group.Index)
            Dim captureCtr As Integer = 0
            For Each capture As Capture In group.Captures
               captureCtr += 1
               Console.WriteLine("      Capture: {0}: '{1}' at position {2}.", 
                                 captureCtr, capture.Value, capture.Index)
            Next   
         Next
      End If
   End Sub
End Module
' The example displays the following output:
'       Regex pattern: (a\1|(?(1)\1)){0,2}
'       Match: '' at position 0.
'          Group: 1: '' at position 0.
'             Capture: 1: '' at position 0.
'       
'       Regex pattern: (a\1|(?(1)\1)){2}
'       Matched 'a' at position 0.
'          Group: 1: 'a' at position 0.
'             Capture: 1: '' at position 0.
'             Capture: 2: 'a' at position 0.
' </Snippet2>
