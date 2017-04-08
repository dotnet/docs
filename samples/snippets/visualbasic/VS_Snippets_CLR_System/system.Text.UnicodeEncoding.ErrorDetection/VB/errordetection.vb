' The following code example demonstrates the behavior of UnicodeEncoding with error detection enabled and without.

' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic

Public Class SamplesUnicodeEncoding   

   Public Shared Sub Main()

      ' Create an instance of UnicodeEncoding using little-endian byte order.
      ' This will be used for encoding.
      Dim u16LE As New UnicodeEncoding(False, True)

      ' Create two instances of UnicodeEncoding using big-endian byte order: one with error detection and one without.
      ' These will be used for decoding.
      Dim u16withED As New UnicodeEncoding(True, True, True)
      Dim u16noED As New UnicodeEncoding(True, True, False)

      ' Create byte arrays from the same string containing the following characters:
      '    Latin Small Letter Z (U+007A)
      '    Latin Small Letter A (U+0061)
      '    Combining Breve (U+0306)
      '    Latin Small Letter AE With Acute (U+01FD)
      '    Greek Small Letter Beta (U+03B2)
      '    Latin Capital Letter U with  Diaeresis (U+00DC)
      Dim myStr As String = "za" & ChrW(&H0306) & ChrW(&H01FD) & ChrW(&H03B2) & ChrW(&H00DC)

      ' Encode the string using little-endian byte order.
      Dim myBytes(u16LE.GetByteCount(myStr)) As Byte
      u16LE.GetBytes(myStr, 0, myStr.Length, myBytes, 0)

      ' Decode the byte array with error detection.
      Console.WriteLine("Decoding with error detection:")
      PrintDecodedString(myBytes, u16withED)

      ' Decode the byte array without error detection.
      Console.WriteLine("Decoding without error detection:")
      PrintDecodedString(myBytes, u16noED)

   End Sub 'Main


   ' Decode the bytes and display the string.
   Public Shared Sub PrintDecodedString(bytes() As Byte, enc As Encoding)

      Try
         Console.WriteLine("   Decoded string: {0}", enc.GetString(bytes, 0, bytes.Length))
      Catch e As System.ArgumentException
         Console.WriteLine(e.ToString())
      End Try

      Console.WriteLine()

   End Sub 'PrintDecodedString 

End Class 'SamplesUnicodeEncoding

' </Snippet1>



'BUGBUG: Reproduce this output in retail build, then add to the snippet.
'This code produces the following output.
'
'Decoding with error detection:
'System.ArgumentException: Invalid byte was found at byte index 3.
'   at System.Text.UnicodeEncoding.GetCharCount(Byte* bytes, Int32 count, DecoderNLS baseDecoder)
'   at System.String.CreateStringFromEncoding(Byte* bytes, Int32 byteLength, Encoding encoding)
'   at System.Text.UnicodeEncoding.GetString(Byte[] bytes, Int32 index, Int32 count)
'   at SamplesUnicodeEncoding.PrintDecodedString(Byte[] bytes, Encoding enc)
'
'Decoding without error detection:
'   Decoded string:

