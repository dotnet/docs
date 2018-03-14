' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String= "\b((?<word>\w+)\s*)+(?<end>[.?!])"
      Dim input As String = "This is a sentence. This is a second sentence."
      
      Dim rgx As New Regex(pattern)
      Dim groupNumbers() As Integer = rgx.GetGroupNumbers()
      Dim m As Match = rgx.Match(input)
      If m.Success Then
         Console.WriteLine("Match: {0}", m.Value)
         For Each groupNumber In groupNumbers
            Dim name As String = rgx.GroupNameFromNumber(groupNumber)
            Dim number As Integer
            Console.WriteLine("   Group {0}{1}: '{2}'", 
                              groupNumber, 
                              If(Not String.IsNullOrEmpty(name) And 
                              Not Int32.TryParse(name, number),
                                 " (" + name + ")", String.Empty), 
                              m.Groups(groupNumber).Value)
         Next
      End If 
   End Sub
End Module
' The example displays the following output:
'       Match: This is a sentence.
'          Group 0: 'This is a sentence.'
'          Group 1: 'sentence'
'          Group 2 (word): 'sentence'
'          Group 3 (end): '.'
' </Snippet1>
