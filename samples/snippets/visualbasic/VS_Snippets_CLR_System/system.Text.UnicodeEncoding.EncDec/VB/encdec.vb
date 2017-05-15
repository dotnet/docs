' The following code example uses an encoder and a decoder to encode a string into an array of bytes,
' and then decode the bytes into an array of characters.

' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic

Public Class SamplesUnicodeEncoding   

   Public Shared Sub Main()

      ' Get an encoder and a decoder from UnicodeEncoding.
      Dim u16 As New UnicodeEncoding(False, True, True)
      Dim myEnc As Encoder = u16.GetEncoder()
      Dim myDec As Decoder = u16.GetDecoder()

      ' The characters to encode:
      '    Latin Small Letter Z (U+007A)
      '    Latin Small Letter A (U+0061)
      '    Combining Breve (U+0306)
      '    Latin Small Letter AE With Acute (U+01FD)
      '    Greek Small Letter Beta (U+03B2)
      Dim myChars() As Char = {"z"c, "a"c, ChrW(&H0306), ChrW(&H01FD), ChrW(&H03B2)}
      Console.Write("The original characters : ")
      Console.WriteLine(myChars)

      ' Encode the character array.
      Dim iBC As Integer = myEnc.GetByteCount(myChars, 0, myChars.Length, True)
      ' NOTE: In Visual Basic, arrays contain one extra element by default.
      '       The following line creates an array with the exact number of elements required.
      Dim myBytes(iBC - 1) As Byte
      myEnc.GetBytes(myChars, 0, myChars.Length, myBytes, 0, True)

      ' Print the resulting bytes.
      Console.Write("Using the encoder       : ")
      Dim i As Integer
      For i = 0 To myBytes.Length - 1
         Console.Write("{0:X2} ", myBytes(i))
      Next i
      Console.WriteLine()

      ' Decode the byte array back into an array of characters.
      Dim iCC As Integer = myDec.GetCharCount(myBytes, 0, myBytes.Length, True)
      ' NOTE: In Visual Basic, arrays contain one extra element by default.
      '       The following line creates an array with the exact number of elements required.
      Dim myDecodedChars(iCC - 1) As Char
      myDec.GetChars(myBytes, 0, myBytes.Length, myDecodedChars, 0, True)

      ' Print the resulting characters.
      Console.Write("Using the decoder       : ")
      Console.WriteLine(myDecodedChars)

   End Sub 'Main 

End Class 'SamplesUnicodeEncoding


'This code produces the following output.  The question marks take the place of characters that cannot be displayed at the console.
'
'The original characters : za??ß
'Using the encoder       : 7A 00 61 00 06 03 FD 01 B2 03
'Using the decoder       : za??ß

' </Snippet1>
