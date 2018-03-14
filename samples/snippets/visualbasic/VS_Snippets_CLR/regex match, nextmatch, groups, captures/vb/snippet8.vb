' <Snippet8>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim text As String = "One car red car blue car"
      Dim pattern As String = "(\w+)\s+(car)"

      ' Instantiate the regular expression object.
      Dim r As Regex = new Regex(pattern, RegexOptions.IgnoreCase)

      ' Match the regular expression pattern against a text string.
      Dim m As Match = r.Match(text)
      Dim matchcount as Integer = 0
      Do While m.Success
         matchCount += 1
         Console.WriteLine("Match" & (matchCount))
         Dim i As Integer
         For i = 1 to 2
            Dim g as Group = m.Groups(i)
            Console.WriteLine("Group" & i & "='" & g.ToString() & "'")
            Dim cc As CaptureCollection = g.Captures
            Dim j As Integer 
            For j = 0 to cc.Count - 1
      	      Dim c As Capture = cc(j)
               Console.WriteLine("Capture" & j & "='" & c.ToString() _
                  & "', Position=" & c.Index)
            Next 
         Next 
         m = m.NextMatch()
      Loop
   End Sub
End Module
' This example displays the following output:
'       Match1
'       Group1='One'
'       Capture0='One', Position=0
'       Group2='car'
'       Capture0='car', Position=4
'       Match2
'       Group1='red'
'       Capture0='red', Position=8
'       Group2='car'
'       Capture0='car', Position=12
'       Match3
'       Group1='blue'
'       Capture0='blue', Position=16
'       Group2='car'
'       Capture0='car', Position=21
' </Snippet8>

