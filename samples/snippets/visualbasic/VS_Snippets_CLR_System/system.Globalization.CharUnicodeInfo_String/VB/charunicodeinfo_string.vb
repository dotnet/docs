' The following code example shows the values returned by each method for different types of characters.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesCharUnicodeInfo   

   Public Shared Sub Main()

      ' The String to get information for.
      Dim s As [String] = "a9\u0393\u00B2\u00BC\u0BEF\u0BF0\u2788"
      Console.WriteLine("String: {0}", s)

      ' Print the values for each of the characters in the string.
      Console.WriteLine("index c  Num   Dig   Dec   UnicodeCategory")
      Dim i As Integer
      For i = 0 To s.Length - 1
         Console.Write("{0,-5} {1,-3}", i, s(i))
         Console.Write(" {0,-5}", CharUnicodeInfo.GetNumericValue(s, i))
         Console.Write(" {0,-5}", CharUnicodeInfo.GetDigitValue(s, i))
         Console.Write(" {0,-5}", CharUnicodeInfo.GetDecimalDigitValue(s, i))
         Console.WriteLine("{0}", CharUnicodeInfo.GetUnicodeCategory(s, i))
      Next i

   End Sub 'Main 

End Class 'SamplesCharUnicodeInfo


'This code produces the following output.  Some characters might not display at the console.
'
'String: a9\u0393\u00B2\u00BC\u0BEF\u0BF0\u2788
'index c  Num   Dig   Dec   UnicodeCategory
'0     a   -1    -1    -1   LowercaseLetter
'1     9   9     9     9    DecimalDigitNumber
'2     \u0393   -1    -1    -1   UppercaseLetter
'3     \u00B2   2     2     2    OtherNumber
'4     \u00BC   0.25  -1    -1   OtherNumber
'5     \u0BEF   9     9     9    DecimalDigitNumber
'6     \u0BF0   10    -1    -1   OtherNumber
'7     \u2788   9     9     -1   OtherNumber

' </snippet1>
