' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Public Module Example
   Public Sub Main()
      Dim string1 As String = "brother"
      Dim string2 As String = "Brother"
      Dim relation As String
      Dim result As Integer

      ' Cultural (linguistic) comparison.
      result = String.Compare(string1, string2, _
                              New CultureInfo("en-US"), CompareOptions.None)
      If result > 0 Then
         relation = "comes after"
      ElseIf result = 0 Then
         relation = "is the same as"
      Else
         relation = "comes before"
      End If
      Console.WriteLine("'{0}' {1} '{2}'.", string1, relation, string2)

      ' Cultural (linguistic) case-insensitive comparison.
      result = String.Compare(string1, string2, _
                              New CultureInfo("en-US"), CompareOptions.IgnoreCase)
      If result > 0 Then
         relation = "comes after"
      ElseIf result = 0 Then
         relation = "is the same as"
      Else
         relation = "comes before"
      End If
      Console.WriteLine("'{0}' {1} '{2}'.", string1, relation, string2)

      ' Culture-insensitive ordinal comparison.
      result = String.CompareOrdinal(string1, string2)
      If result > 0 Then
         relation = "comes after"
      ElseIf result = 0 Then
         relation = "is the same as"
      Else
         relation = "comes before"
      End If
      Console.WriteLine("'{0}' {1} '{2}'.", string1, relation, string2)
   End Sub
End Module
' The example produces the following output:
'    'brother' comes before 'Brother'.   
'    'brother' is the same as 'Brother'.
'    'brother' comes after 'Brother'.
' </Snippet1>
