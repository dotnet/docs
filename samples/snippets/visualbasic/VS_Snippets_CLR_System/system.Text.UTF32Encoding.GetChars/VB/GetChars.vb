' The following code example encodes a string into an array of bytes, and then decodes the bytes into an array of characters.

' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic

Public Class SamplesUTF32Encoding   

   Public Shared Sub Main()

      ' Create two instances of UTF32Encoding: one with little-endian byte order and one with big-endian byte order.
      Dim u32LE As New UTF32Encoding(False, True, True)
      Dim u32BE As New UTF32Encoding(True, True, True)


      ' Create byte arrays from the same string containing the following characters:
      '    Latin Small Letter Z (U+007A)
      '    Latin Small Letter A (U+0061)
      '    Combining Breve (U+0306)
      '    Latin Small Letter AE With Acute (U+01FD)
      '    Greek Small Letter Beta (U+03B2)
      '    a high-surrogate value (U+D8FF)
      '    a low-surrogate value (U+DCFF)
      Dim myStr As String = "za" & ChrW(&H0306) & ChrW(&H01FD) & ChrW(&H03B2) & ChrW(&HD8FF) & ChrW(&HDCFF)

      ' barrBE uses the big-endian byte order.
      ' NOTE: In Visual Basic, arrays contain one extra element by default.
      '       The following line creates an array with the exact number of elements required.
      Dim barrBE(u32BE.GetByteCount(myStr) - 1) As Byte
      u32BE.GetBytes(myStr, 0, myStr.Length, barrBE, 0)

      ' barrLE uses the little-endian byte order.
      ' NOTE: In Visual Basic, arrays contain one extra element by default.
      '       The following line creates an array with the exact number of elements required.
      Dim barrLE(u32LE.GetByteCount(myStr) - 1) As Byte
      u32LE.GetBytes(myStr, 0, myStr.Length, barrLE, 0)


      ' Get the char counts and decode the byte arrays.
      Console.Write("BE array with BE encoding : ")
      PrintCountsAndChars(barrBE, u32BE)
      Console.Write("LE array with LE encoding : ")
      PrintCountsAndChars(barrLE, u32LE)


      ' Decode the byte arrays using an encoding with a different byte order.
      Console.Write("BE array with LE encoding : ")
      Try
         PrintCountsAndChars(barrBE, u32LE)
      Catch e As System.ArgumentException
         Console.WriteLine(e.Message)
      End Try

      Console.Write("LE array with BE encoding : ")
      Try
         PrintCountsAndChars(barrLE, u32BE)
      Catch e As System.ArgumentException
         Console.WriteLine(e.Message)
      End Try

   End Sub 'Main


   Public Shared Sub PrintCountsAndChars(bytes() As Byte, enc As Encoding)

      ' Display the name of the encoding used.
      Console.Write("{0,-25} :", enc.ToString())

      ' Display the exact character count.
      Dim iCC As Integer = enc.GetCharCount(bytes)
      Console.Write(" {0,-3}", iCC)

      ' Display the maximum character count.
      Dim iMCC As Integer = enc.GetMaxCharCount(bytes.Length)
      Console.Write(" {0,-3} :", iMCC)

      ' Decode the bytes and display the characters.
      Dim chars(iCC) As Char
      enc.GetChars(bytes, 0, bytes.Length, chars, 0)
      Console.WriteLine(chars)

   End Sub 'PrintCountsAndChars 

End Class 'SamplesUTF32Encoding

' </Snippet1>



'BUGBUG: Reproduce this output in retail build, then add to the snippet.
'This code produces the following output.  The question marks take the place of characters that cannot be displayed at the console.
'
'BE array with BE encoding : System.Text.UTF32Encoding : 7   14  :za??ß?
'LE array with LE encoding : System.Text.UTF32Encoding : 7   14  :za??ß?
'BE array with LE encoding : System.Text.UTF32Encoding :Invalid byte was found at byte index 3.
'LE array with BE encoding : System.Text.UTF32Encoding :Invalid byte was found at byte index 3.

