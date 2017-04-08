' Visual Basic .NET Document
Option Strict On

' Both Match.Captures and Group.Captures return a CaptureCollection object. 
' What is the difference?

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String  
      Dim input As String = "The young, hairy, and tall dog slowly walked across the yard."
      Dim match As Match

      ' Match a word with a pattern that has no capturing groups.
      pattern = "\b\w+\W{1,2}"
      match = Regex.Match(input, pattern)
      Console.WriteLine("Pattern: " + pattern)
      Console.WriteLine("Match: " + match.Value)
      Console.WriteLine("  Match.Captures: {0}", match.Captures.Count)
      For ctr As Integer = 0 To match.Captures.Count - 1
         Console.WriteLine("    {0}: '{1}'", ctr, match.Captures(ctr).Value)
      Next
      Console.WriteLine("  Match.Groups: {0}", match.Groups.Count)
      For groupCtr As Integer = 0 To match.Groups.Count - 1
         Console.WriteLine("    Group {0}: '{1}'", groupCtr, match.Groups(groupCtr).Value)
         Console.WriteLine("    Group({0}).Captures: {1}", _
                           groupCtr, match.Groups(groupCtr).Captures.Count)
         For captureCtr As Integer = 0 To match.Groups(groupCtr).Captures.Count - 1
            Console.WriteLine("      Capture {0}: '{1}'", _
                              captureCtr, _
                              match.Groups(groupCtr).Captures(captureCtr).Value)
         Next
      Next
      Console.WriteLine("-----")
      Console.WriteLine()

      ' Match a sentence with a pattern that has a quantifier that 
      ' applies to the entire group.
      pattern = "(\b\w+\W{1,2})+"
      match = Regex.Match(input, pattern)
      Console.WriteLine("Pattern: " + pattern)
      Console.WriteLine("Match: " + match.Value)
      Console.WriteLine("  Match.Captures: {0}", match.Captures.Count)
      For ctr As Integer = 0 To match.Captures.Count - 1
         Console.WriteLine("    {0}: '{1}'", ctr, match.Captures(ctr).Value)
      Next
      Console.WriteLine("  Match.Groups: {0}", match.Groups.Count)
      For groupCtr As Integer = 0 To match.Groups.Count - 1
         Console.WriteLine("    Group {0}: '{1}'", groupCtr, match.Groups(groupCtr).Value)
         Console.WriteLine("    Group({0}).Captures: {1}", _
                           groupCtr, match.Groups(groupCtr).Captures.Count)
         For captureCtr As Integer = 0 To match.Groups(groupCtr).Captures.Count - 1
            Console.WriteLine("      Capture {0}: '{1}'", captureCtr, match.Groups(groupCtr).Captures(captureCtr).Value)
         Next
      Next
   End Sub
End Module
' The example displays the following output:
'    Pattern: \b\w+\W{1,2}
'    Match: The
'      Match.Captures: 1
'        0: 'The '
'      Match.Groups: 1
'        Group 0: 'The '
'        Group(0).Captures: 1
'          Capture 0: 'The '
'    -----
'    
'    Pattern: (\b\w+\W{1,2})+
'    Match: The young, hairy, and tall dog slowly walked across the yard.
'      Match.Captures: 1
'        0: 'The young, hairy, and tall dog slowly walked across the yard.'
'      Match.Groups: 2
'        Group 0: 'The young, hairy, and tall dog slowly walked across the yard.'
'        Group(0).Captures: 1
'          Capture 0: 'The young, hairy, and tall dog slowly walked across the yard.'
'        Group 1: 'yard.'
'        Group(1).Captures: 11
'          Capture 0: 'The '
'          Capture 1: 'young, '
'          Capture 2: 'hairy, '
'          Capture 3: 'and '
'          Capture 4: 'tall '
'          Capture 5: 'dog '
'          Capture 6: 'slowly '
'          Capture 7: 'walked '
'          Capture 8: 'across '
'          Capture 9: 'the '
'          Capture 10: 'yard.'
' </Snippet1>
