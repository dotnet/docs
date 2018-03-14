Option Strict On

' <Snippet1>
Imports System.Text

Public Module Example
   Public Sub Main()
      ' Create a UTF32Encoding object with error detection enabled.
      Dim encExc As New UTF32Encoding(Not BitConverter.IsLittleEndian, True, True)
      ' Create a UTF32Encoding object with error detection disabled.
      Dim encRepl As New UTF32Encoding(Not BitConverter.IsLittleEndian, True, False)

      ' Create a byte arrays from a string, and add an invalid surrogate pair, as follows.
      '    Latin Small Letter Z (U+007A)
      '    Latin Small Letter A (U+0061)
      '    Combining Breve (U+0306)
      '    Latin Small Letter AE With Acute (U+01FD)
      '    Greek Small Letter Beta (U+03B2)
      '    a high-surrogate value (U+D8FF)
      '    an invalid low surrogate (U+01FF)
      Dim s As String = "za" & ChrW(&H0306) & ChrW(&H01FD) & ChrW(&H03B2)

      ' Encode the string using little-endian byte order.
      Dim index As Integer = encExc.GetBytecount(s)
      Dim bytes(index + 3) As Byte
      encExc.GetBytes(s, 0, s.Length, bytes, 0)
      bytes(index) = &hFF
      bytes(index + 1) = &hD8
      bytes(index + 2) = &hFF
      bytes(index + 3) = &h01

      ' Decode the byte array with error detection.
      Console.WriteLine("Decoding with error detection:")
      PrintDecodedString(bytes, encExc)

      ' Decode the byte array without error detection.
      Console.WriteLine("Decoding without error detection:")
      PrintDecodedString(bytes, encRepl)
   End Sub

   ' Decode the bytes and display the string.
   Public Sub PrintDecodedString(bytes() As Byte, enc As Encoding)
      Try
         Console.WriteLine("   Decoded string: {0}", enc.GetString(bytes, 0, bytes.Length))
      Catch e As DecoderFallbackException
         Console.WriteLine(e.ToString())
      End Try
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'    Decoding with error detection:
'    System.Text.DecoderFallbackException: Unable to translate bytes [FF][D8][FF][01] at index
'    20 from specified code page to Unicode.
'       at System.Text.DecoderExceptionFallbackBuffer.Throw(Byte[] bytesUnknown, Int32 index)
'       at System.Text.DecoderExceptionFallbackBuffer.Fallback(Byte[] bytesUnknown, Int32 index
'    )
'       at System.Text.DecoderFallbackBuffer.InternalFallback(Byte[] bytes, Byte* pBytes)
'       at System.Text.UTF32Encoding.GetCharCount(Byte* bytes, Int32 count, DecoderNLS baseDeco
'    der)
'       at System.Text.UTF32Encoding.GetString(Byte[] bytes, Int32 index, Int32 count)
'       at Example.PrintDecodedString(Byte[] bytes, Encoding enc)
'
'    Decoding without error detection:
'       Decoded string: zăǽβ�
' </Snippet1>



'BUGBUG: Reproduce this output in retail build, then add to the snippet.
'This code produces the following output.
'
'Decoding with error detection:
'System.ArgumentException: Invalid byte was found at byte index 3.
'   at System.Text.UTF32Encoding.GetCharCount(Byte* bytes, Int32 count, DecoderNLS baseDecoder)
'   at System.String.CreateStringFromEncoding(Byte* bytes, Int32 byteLength, Encoding encoding)
'   at System.Text.UTF32Encoding.GetString(Byte[] bytes, Int32 index, Int32 count)
'   at SamplesUTF32Encoding.PrintDecodedString(Byte[] bytes, Encoding enc)
'
'Decoding without error detection:
'   Decoded string:

