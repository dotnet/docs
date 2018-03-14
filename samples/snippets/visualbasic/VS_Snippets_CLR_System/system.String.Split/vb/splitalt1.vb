' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim expressions() As String = { "16 + 21", "31 * 3", "28 / 3",
                                      "42 - 18", "12 * 7",
                                      "2, 4, 6, 8" }

      Dim pattern As String = "(\d+)\s+([-+*/])\s+(\d+)"
      For Each expression In expressions
         For Each m As Match in Regex.Matches(expression, pattern)
            Dim value1 As Integer = Int32.Parse(m.Groups(1).Value)
            Dim value2 As Integer = Int32.Parse(m.Groups(3).Value)
            Select Case m.Groups(2).Value
               Case "+"
                  Console.WriteLine("{0} = {1}", m.Value, value1 + value2)
               Case "-"
                  Console.WriteLine("{0} = {1}", m.Value, value1 - value2)
               Case "*"
                  Console.WriteLine("{0} = {1}", m.Value, value1 * value2)
               Case "/"
                  Console.WriteLine("{0} = {1:N2}", m.Value, value1 / value2)
            End Select
         Next
      Next
   End Sub
End Module
' The example displays the following output:
'       16 + 21 = 37
'       31 * 3 = 93
'       28 / 3 = 9.33
'       42 - 18 = 24
'       12 * 7 = 84
' </Snippet8>

