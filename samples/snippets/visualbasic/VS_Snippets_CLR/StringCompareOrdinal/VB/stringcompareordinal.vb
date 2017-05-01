 '<Snippet1>
Imports System
Imports System.Globalization

Class Test
   
  Public Shared Sub Main(args() As [String])
      Dim strLow As [String] = "abc"
      Dim strCap As [String] = "ABC"
      Dim result As [String] = "equal to "
      Dim x As Integer = 0
      Dim pos As Integer = 1

' The Unicode codepoint for 'b' is greater than the codepoint for 'B'.      
      x = [String].CompareOrdinal(strLow, pos, strCap, pos, 1)
      If x < 0 Then
         result = "less than"
      End If
      If x > 0 Then
         result = "greater than"
      End If

' In U.S. English culture, 'b' is linguistically less than 'B'.
      Console.WriteLine("CompareOrdinal(""{0}"".Chars({2}), ""{1}"".Chars({2})):", strLow, strCap, pos)
      
      Console.WriteLine("   '{0}' is {1} '{2}'", strLow.Chars(pos), result, strCap.Chars(pos))
      
      x = [String].Compare(strLow, pos, strCap, pos, 1, False, New CultureInfo("en-US"))
      If x < 0 Then
         result = "less than"
      ElseIf x > 0 Then
         result = "greater than"
      End If
      Console.WriteLine("Compare(""{0}"".Chars({2}), ""{1}"".Chars({2})):", strLow, strCap, pos)
      Console.WriteLine("   '{0}' is {1} '{2}'", strLow.Chars(pos), result, strCap.Chars(pos))
   End Sub 'Main
End Class 'Test
'</Snippet1>	