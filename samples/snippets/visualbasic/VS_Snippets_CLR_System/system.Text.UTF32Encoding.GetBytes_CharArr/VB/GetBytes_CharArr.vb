' The following code example determines the number of bytes required to encode three characters from a character array,
' then encodes the characters and displays the resulting bytes.

' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic

Public Class SamplesUTF32Encoding   

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

      ' Create instances of different encodings.
      Dim u7 As New UTF7Encoding()
      Dim u8Nobom As New UTF8Encoding(False, True)
      Dim u8Bom As New UTF8Encoding(True, True)
      Dim u32Nobom As New UTF32Encoding(False, False, True)
      Dim u32Bom As New UTF32Encoding(False, True, True)

      ' Encode three characters starting at index 4 and print out the counts and the resulting bytes.
      PrintCountsAndBytes(myChars, 4, 3, u7)
      PrintCountsAndBytes(myChars, 4, 3, u8Nobom)
      PrintCountsAndBytes(myChars, 4, 3, u8Bom)
      PrintCountsAndBytes(myChars, 4, 3, u32Nobom)
      PrintCountsAndBytes(myChars, 4, 3, u32Bom)

   End Sub 'Main


   Public Shared Sub PrintCountsAndBytes(chars() As Char, index As Integer, count As Integer, enc As Encoding)

      ' Display the name of the encoding used.
      Console.Write("{0,-25} :", enc.ToString())

      ' Display the exact byte count.
      Dim iBC As Integer = enc.GetByteCount(chars, index, count)
      Console.Write(" {0,-3}", iBC)

      ' Display the maximum byte count.
      Dim iMBC As Integer = enc.GetMaxByteCount(count)
      Console.Write(" {0,-3} :", iMBC)

      ' Get the byte order mark, if any.
      Dim preamble As Byte() = enc.GetPreamble()

      ' Combine the preamble and the encoded bytes.
      ' NOTE: In Visual Basic, arrays contain one extra element by default.
      '       The following line creates an array with the exact number of elements required.
      Dim bytes(preamble.Length + iBC - 1) As Byte
      Array.Copy(preamble, bytes, preamble.Length)
      enc.GetBytes(chars, index, count, bytes, preamble.Length)

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

End Class 'SamplesUTF32Encoding


'This code produces the following output.
'
'System.Text.UTF7Encoding  : 10  11  :2B 41 37 4C 59 2F 39 7A 2F 2D
'System.Text.UTF8Encoding  : 6   12  :CE B2 F1 8F B3 BF
'System.Text.UTF8Encoding  : 6   12  :EF BB BF CE B2 F1 8F B3 BF
'System.Text.UTF32Encoding : 8   12  :B2 03 00 00 FF FC 04 00
'System.Text.UTF32Encoding : 8   12  :FF FE 00 00 B2 03 00 00 FF FC 04 00

' </Snippet1>
