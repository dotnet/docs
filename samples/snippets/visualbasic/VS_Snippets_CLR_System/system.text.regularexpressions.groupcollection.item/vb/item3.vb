' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\d+)*(\w)\2"
      Dim input As String = "AA"
      Dim match As Match = Regex.Match(input, pattern)
      
      ' Get the first named group.
      Dim group1 As Group = match.Groups.Item(1)
      Console.WriteLine("Group 1 value: {0}", If(group1.Success, group1.Value, "Empty"))
      
      ' Get the second named group.
      Dim group2 As Group = match.Groups.Item(2)
      Console.WriteLine("Group 2 value: {0}", If(group2.Success, group2.Value, "Empty"))
      
      ' Get a non-existent group.
      Dim group3 As Group = match.Groups.Item(3)
      Console.WriteLine("Group 3 value: {0}", If(group3.Success, group3.Value, "Empty"))
   End Sub
End Module
' The example displays the following output:
'       Group 1 value: Empty
'       Group 2 value: A
'       Group 3 value: Empty
' </Snippet2>
