' The following code example shows the values returned by each method for different types of characters.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesCharUnicodeInfo   

   Public Shared Sub Main()

      Console.WriteLine("                                        c  Num   Dig   Dec   UnicodeCategory")

      Console.Write("U+0061 LATIN SMALL LETTER A            ")
      PrintProperties("a"c)

      Console.Write("U+0393 GREEK CAPITAL LETTER GAMMA      ")
      PrintProperties(ChrW(&H0393))

      Console.Write("U+0039 DIGIT NINE                      ")
      PrintProperties("9"c)

      Console.Write("U+00B2 SUPERSCRIPT TWO                 ")
      PrintProperties(ChrW(&H00B2))

      Console.Write("U+00BC VULGAR FRACTION ONE QUARTER     ")
      PrintProperties(ChrW(&H00BC))

      Console.Write("U+0BEF TAMIL DIGIT NINE                ")
      PrintProperties(ChrW(&H0BEF))

      Console.Write("U+0BF0 TAMIL NUMBER TEN                ")
      PrintProperties(ChrW(&H0BF0))

      Console.Write("U+0F33 TIBETAN DIGIT HALF ZERO         ")
      PrintProperties(ChrW(&H0F33))

      Console.Write("U+2788 CIRCLED SANS-SERIF DIGIT NINE   ")
      PrintProperties(ChrW(&H2788))

   End Sub 'Main

   Public Shared Sub PrintProperties(c As Char)
      Console.Write(" {0,-3}", c)
      Console.Write(" {0,-5}", CharUnicodeInfo.GetNumericValue(c))
      Console.Write(" {0,-5}", CharUnicodeInfo.GetDigitValue(c))
      Console.Write(" {0,-5}", CharUnicodeInfo.GetDecimalDigitValue(c))
      Console.WriteLine("{0}", CharUnicodeInfo.GetUnicodeCategory(c))
   End Sub 'PrintProperties

End Class 'SamplesCharUnicodeInfo 


'This code produces the following output.  Some characters might not display at the console.
'
'                                        c  Num   Dig   Dec   UnicodeCategory
'U+0061 LATIN SMALL LETTER A             a   -1    -1    -1   LowercaseLetter
'U+0393 GREEK CAPITAL LETTER GAMMA       \u0393   -1    -1    -1   UppercaseLetter
'U+0039 DIGIT NINE                       9   9     9     9    DecimalDigitNumber
'U+00B2 SUPERSCRIPT TWO                  \u00B2   2     2     2    OtherNumber
'U+00BC VULGAR FRACTION ONE QUARTER      \u00BC   0.25  -1    -1   OtherNumber
'U+0BEF TAMIL DIGIT NINE                 \u0BEF   9     9     9    DecimalDigitNumber
'U+0BF0 TAMIL NUMBER TEN                 \u0BF0   10    -1    -1   OtherNumber
'U+0F33 TIBETAN DIGIT HALF ZERO          \u0F33   -0.5  -1    -1   OtherNumber
'U+2788 CIRCLED SANS-SERIF DIGIT NINE    \u2788   9     9     -1   OtherNumber

' </snippet1>
