' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(?<numbers>\d+)*(?<letter>\w)\k<letter>"
      Dim input As String = "AA"
      Dim match As Match = Regex.Match(input, pattern)
      
      ' Get the first named group.
      Dim group1 As Group = match.Groups.Item("numbers")
      Console.WriteLine("Group 'numbers' value: {0}", If(group1.Success, group1.Value, "Empty"))
      
      ' Get the second named group.
      Dim group2 As Group = match.Groups.Item("letter")
      Console.WriteLine("Group 'letter' value: {0}", If(group2.Success, group2.Value, "Empty"))
      
      ' Get a non-existent group.
      Dim group3 As Group = match.Groups.Item("none")
      Console.WriteLine("Group 'none' value: {0}", If(group3.Success, group3.Value, "Empty"))
   End Sub
End Module
' The example displays the following output:
'       Group 'numbers' value: Empty
'       Group 'letter' value: A
'       Group 'none' value: Empty
' </Snippet1>
