' The following code example determines the number of bytes required to encode a string or a range in the string,
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
      Dim myStr As String = "za" & ChrW(&H0306) & ChrW(&H01FD) & ChrW(&H03B2) & ChrW(&HD8FF) & ChrW(&HDCFF)

      ' Get different encodings.
      Dim u7 As Encoding = Encoding.UTF7
      Dim u8 As Encoding = Encoding.UTF8
      Dim u16LE As Encoding = Encoding.Unicode
      Dim u16BE As Encoding = Encoding.BigEndianUnicode
      Dim u32 As Encoding = Encoding.UTF32

      ' Encode the entire string, and print out the counts and the resulting bytes.
      Console.WriteLine("Encoding the entire string:")
      PrintCountsAndBytes(myStr, u7)
      PrintCountsAndBytes(myStr, u8)
      PrintCountsAndBytes(myStr, u16LE)
      PrintCountsAndBytes(myStr, u16BE)
      PrintCountsAndBytes(myStr, u32)

      Console.WriteLine()

      ' Encode three characters starting at index 4, and print out the counts and the resulting bytes.
      Console.WriteLine("Encoding the characters from index 4 through 6:")
      PrintCountsAndBytes(myStr, 4, 3, u7)
      PrintCountsAndBytes(myStr, 4, 3, u8)
      PrintCountsAndBytes(myStr, 4, 3, u16LE)
      PrintCountsAndBytes(myStr, 4, 3, u16BE)
      PrintCountsAndBytes(myStr, 4, 3, u32)

   End Sub 'Main


   Overloads Public Shared Sub PrintCountsAndBytes(s As String, enc As Encoding)

      ' Display the name of the encoding used.
      Console.Write("{0,-30} :", enc.ToString())

      ' Display the exact byte count.
      Dim iBC As Integer = enc.GetByteCount(s)
      Console.Write(" {0,-3}", iBC)

      ' Display the maximum byte count.
      Dim iMBC As Integer = enc.GetMaxByteCount(s.Length)
      Console.Write(" {0,-3} :", iMBC)

      ' Encode the entire string.
      Dim bytes As Byte() = enc.GetBytes(s)

      ' Display all the encoded bytes.
      PrintHexBytes(bytes)

   End Sub 'PrintCountsAndBytes


   Overloads Public Shared Sub PrintCountsAndBytes(s As String, index As Integer, count As Integer, enc As Encoding)

      ' Display the name of the encoding used.
      Console.Write("{0,-30} :", enc.ToString())

      ' Display the exact byte count.
      Dim iBC As Integer = enc.GetByteCount(s.ToCharArray(), index, count)
      Console.Write(" {0,-3}", iBC)

      ' Display the maximum byte count.
      Dim iMBC As Integer = enc.GetMaxByteCount(count)
      Console.Write(" {0,-3} :", iMBC)

      ' Encode a range of characters in the string.
      ' NOTE: In VB.NET, arrays contain one extra element by default.
      '       The following line creates the array with the exact number of elements required.
      Dim bytes(iBC - 1) As Byte
      enc.GetBytes(s, index, count, bytes, bytes.GetLowerBound(0))

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
'Encoding the entire string:
'System.Text.UTF7Encoding       : 18  23  :7A 61 2B 41 77 59 42 2F 51 4F 79 32 50 2F 63 2F 77 2D
'System.Text.UTF8Encoding       : 12  24  :7A 61 CC 86 C7 BD CE B2 F1 8F B3 BF
'System.Text.UnicodeEncoding    : 14  16  :7A 00 61 00 06 03 FD 01 B2 03 FF D8 FF DC
'System.Text.UnicodeEncoding    : 14  16  :00 7A 00 61 03 06 01 FD 03 B2 D8 FF DC FF
'System.Text.UTF32Encoding      : 24  32  :7A 00 00 00 61 00 00 00 06 03 00 00 FD 01 00 00 B2 03 00 00 FF FC 04 00
'
'Encoding the characters from index 4 through 6:
'System.Text.UTF7Encoding       : 10  11  :2B 41 37 4C 59 2F 39 7A 2F 2D
'System.Text.UTF8Encoding       : 6   12  :CE B2 F1 8F B3 BF
'System.Text.UnicodeEncoding    : 6   8   :B2 03 FF D8 FF DC
'System.Text.UnicodeEncoding    : 6   8   :03 B2 D8 FF DC FF
'System.Text.UTF32Encoding      : 8   16  :B2 03 00 00 FF FC 04 00

' </Snippet1>
