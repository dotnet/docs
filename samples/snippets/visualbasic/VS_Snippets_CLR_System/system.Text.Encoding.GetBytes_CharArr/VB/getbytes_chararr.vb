' The following code example determines the number of bytes required to encode a character array,
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
      Dim myChars() As Char = {"z"c, "a"c, ChrW(&H0306), ChrW(&H01FD), ChrW(&H03B2), ChrW(&HD8FF), ChrW(&HDCFF)}
 

      ' Get different encodings.
      Dim u7 As Encoding = Encoding.UTF7
      Dim u8 As Encoding = Encoding.UTF8
      Dim u16LE As Encoding = Encoding.Unicode
      Dim u16BE As Encoding = Encoding.BigEndianUnicode
      Dim u32 As Encoding = Encoding.UTF32

      ' Encode the entire array, and print out the counts and the resulting bytes.
      PrintCountsAndBytes(myChars, u7)
      PrintCountsAndBytes(myChars, u8)
      PrintCountsAndBytes(myChars, u16LE)
      PrintCountsAndBytes(myChars, u16BE)
      PrintCountsAndBytes(myChars, u32)

   End Sub 'Main


   Public Shared Sub PrintCountsAndBytes(chars() As Char, enc As Encoding)

      ' Display the name of the encoding used.
      Console.Write("{0,-30} :", enc.ToString())

      ' Display the exact byte count.
      Dim iBC As Integer = enc.GetByteCount(chars)
      Console.Write(" {0,-3}", iBC)

      ' Display the maximum byte count.
      Dim iMBC As Integer = enc.GetMaxByteCount(chars.Length)
      Console.Write(" {0,-3} :", iMBC)

      ' Encode the array of chars.
      Dim bytes As Byte() = enc.GetBytes(chars)

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
'System.Text.UTF7Encoding       : 18  23  :7A 61 2B 41 77 59 42 2F 51 4F 79 32 50 2F 63 2F 77 2D
'System.Text.UTF8Encoding       : 12  24  :7A 61 CC 86 C7 BD CE B2 F1 8F B3 BF
'System.Text.UnicodeEncoding    : 14  16  :7A 00 61 00 06 03 FD 01 B2 03 FF D8 FF DC
'System.Text.UnicodeEncoding    : 14  16  :00 7A 00 61 03 06 01 FD 03 B2 D8 FF DC FF
'System.Text.UTF32Encoding      : 24  32  :7A 00 00 00 61 00 00 00 06 03 00 00 FD 01 00 00 B2 03 00 00 FF FC 04 00

' </Snippet1>
