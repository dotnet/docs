' The following code example determines the number of bytes required to encode three characters from a character array,
' encodes the characters, and displays the resulting bytes.

' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic

Public Class SamplesEncoding   

   Public Shared Sub Main()

      ' The characters to encode:
      '    Latin Small Letter Z (U+007A)
      '    Latin Small Letter A (U+0061)
      '    Combining Breve (U+0306)
      '    Latin Small Letter AE With Acute (U+01FD)
      '    Greek Small Letter Beta (U+03B2)
      '    a high-surrogate value (U+D8FF)
      '    a low-surrogate value (U+DCFF)
      Dim myChars() As Char = {"z"c, "a"c, ChrW(&H0306), ChrW(&H01FD), ChrW(&H03B2), ChrW(&HD8FF), ChrW(&HDCFF) }

      ' Get different encodings.
      Dim u7 As Encoding = Encoding.UTF7
      Dim u8 As Encoding = Encoding.UTF8
      Dim u16LE As Encoding = Encoding.Unicode
      Dim u16BE As Encoding = Encoding.BigEndianUnicode
      Dim u32 As Encoding = Encoding.UTF32

      ' Encode three characters starting at index 4, and print out the counts and the resulting bytes.
      PrintCountsAndBytes(myChars, 4, 3, u7)
      PrintCountsAndBytes(myChars, 4, 3, u8)
      PrintCountsAndBytes(myChars, 4, 3, u16LE)
      PrintCountsAndBytes(myChars, 4, 3, u16BE)
      PrintCountsAndBytes(myChars, 4, 3, u32)

   End Sub 'Main


   Public Shared Sub PrintCountsAndBytes(chars() As Char, index As Integer, count As Integer, enc As Encoding)

      ' Display the name of the encoding used.
      Console.Write("{0,-30} :", enc.ToString())

      ' Display the exact byte count.
      Dim iBC As Integer = enc.GetByteCount(chars, index, count)
      Console.Write(" {0,-3}", iBC)

      ' Display the maximum byte count.
      Dim iMBC As Integer = enc.GetMaxByteCount(count)
      Console.Write(" {0,-3} :", iMBC)

      ' Encode the array of chars.
      Dim bytes As Byte() = enc.GetBytes(chars, index, count)

      ' The following is an alternative way to encode the array of chars:
      ' NOTE: In VB.NET, arrays contain one extra element by default.
      '       The following line creates the array with the exact number of elements required.
      ' Dim bytes(iBC - 1) As Byte
      ' enc.GetBytes( chars, index, count, bytes, bytes.GetLowerBound(0) )

      ' Display all the encoded bytes.
      PrintHexBytes(bytes)

   End Sub 'PrintCountsAndBytes


   Public Shared Sub PrintHexBytes(bytes() As Byte)

      If bytes Is Nothing OrElse bytes.Length = 0 Then
         Console.WriteLine("<none>")
      Else
         Dim i As Integer
         For i = 0 To bytes.Length - 1
            Console.Write("{0:X2} ", bytes(i))
         Next i
         Console.WriteLine()
      End If

   End Sub 'PrintHexBytes 

End Class 'SamplesEncoding


'This code produces the following output.
'
'System.Text.UTF7Encoding       : 10  11  :2B 41 37 4C 59 2F 39 7A 2F 2D
'System.Text.UTF8Encoding       : 6   12  :CE B2 F1 8F B3 BF
'System.Text.UnicodeEncoding    : 6   8   :B2 03 FF D8 FF DC
'System.Text.UnicodeEncoding    : 6   8   :03 B2 D8 FF DC FF
'System.Text.UTF32Encoding      : 8   16  :B2 03 00 00 FF FC 04 00

' </Snippet1>
