' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "Yes. This dog is very friendly."
      Dim pattern As String = "((\w+)[\s.])+"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Match: {0}", match.Value)
         For groupCtr As Integer = 0 To match.Groups.Count - 1
            Dim group As Group = match.Groups(groupCtr)
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value)
            For captureCtr As Integer = 0 To group.Captures.Count - 1
               Console.WriteLine("      Capture {0}: {1}", captureCtr, _
                                 group.Captures(captureCtr).Value)
            Next
         Next                      
      Next
   End Sub
End Module
' The example displays the following output:
'       Match: Yes.
'          Group 0: Yes.
'             Capture 0: Yes.
'          Group 1: Yes.
'             Capture 0: Yes.
'          Group 2: Yes
'             Capture 0: Yes
'       Match: This dog is very friendly.
'          Group 0: This dog is very friendly.
'             Capture 0: This dog is very friendly.
'          Group 1: friendly.
'             Capture 0: This
'             Capture 1: dog
'             Capture 2: is
'             Capture 3: very
'             Capture 4: friendly.
'          Group 2: friendly
'             Capture 0: This
'             Capture 1: dog
'             Capture 2: is
'             Capture 3: very
'             Capture 4: friendly
' </Snippet1>
