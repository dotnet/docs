' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "^([a-z]+)(\d+)?\.([a-z]+(\d)*)$"
      Dim values() As String = { "AC10", "Za203.CYM", "XYZ.CoA", "ABC.x170" }   
      For Each value In values
         Dim m As Match = Regex.Match(value, pattern, RegexOptions.IgnoreCase)
         If m.Success Then
            Console.WriteLine("Match: '{0}'", m.Value)
            Console.WriteLine("   Number of Capturing Groups: {0}", 
                              m.Groups.Count)
            For gCtr As Integer = 0 To m.Groups.Count - 1
               Dim group As Group = m.Groups(gCtr)
               Console.WriteLine("      Group {0}: {1}", gCtr, 
                                 If(group.Value = "", "<empty>", "'" + group.Value + "'"))   
               Console.WriteLine("         Number of Captures: {0}", 
                                 group.Captures.Count)
           
               For cCtr As Integer = 0 To group.Captures.Count - 1
                  Console.WriteLine("            Capture {0}: {1}", 
                                    cCtr, group.Captures(cCtr).Value)
               Next
            Next
         Else
            Console.WriteLine("No match for {0}: Match.Value is {1}", 
                              value, If(m.Value = String.Empty, "<empty>", m.Value))
         End If
      Next    
   End Sub
End Module
' The example displays the following output:
'       No match for AC10: Match.Value is <empty>
'       Match: 'Za203.CYM'
'          Number of Capturing Groups: 5
'             Group 0: 'Za203.CYM'
'                Number of Captures: 1
'                   Capture 0: Za203.CYM
'             Group 1: 'Za'
'                Number of Captures: 1
'                   Capture 0: Za
'             Group 2: '203'
'                Number of Captures: 1
'                   Capture 0: 203
'             Group 3: 'CYM'
'                Number of Captures: 1
'                   Capture 0: CYM
'             Group 4: <empty>
'                Number of Captures: 0
'       Match: 'XYZ.CoA'
'          Number of Capturing Groups: 5
'             Group 0: 'XYZ.CoA'
'                Number of Captures: 1
'                   Capture 0: XYZ.CoA
'             Group 1: 'XYZ'
'                Number of Captures: 1
'                   Capture 0: XYZ
'             Group 2: <empty>
'                Number of Captures: 0
'             Group 3: 'CoA'
'                Number of Captures: 1
'                   Capture 0: CoA
'             Group 4: <empty>
'                Number of Captures: 0
'       Match: 'ABC.x170'
'          Number of Capturing Groups: 5
'             Group 0: 'ABC.x170'
'                Number of Captures: 1
'                   Capture 0: ABC.x170
'             Group 1: 'ABC'
'                Number of Captures: 1
'                   Capture 0: ABC
'             Group 2: <empty>
'                Number of Captures: 0
'             Group 3: 'x170'
'                Number of Captures: 1
'                   Capture 0: x170
'             Group 4: '0'
'                Number of Captures: 3
'                   Capture 0: 1
'                   Capture 1: 7
'                   Capture 2: 0
' </Snippet1>
