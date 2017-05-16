' <Snippet1>
Imports System.Text

Class Example
   Shared Sub Main()
      Dim unicodeString As String = "This string contains the unicode character Pi (" & ChrW(&H03A0) & ")"

      ' Create two different encodings.
      Dim ascii As Encoding = Encoding.ASCII
      Dim unicode As Encoding = Encoding.Unicode

      ' Convert the string into a byte array.
      Dim unicodeBytes As Byte() = unicode.GetBytes(unicodeString)

      ' Perform the conversion from one encoding to the other.
      Dim asciiBytes As Byte() = Encoding.Convert(unicode, ascii, unicodeBytes)

      ' Convert the new byte array into a char array and then into a string.
      Dim asciiChars(ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)-1) As Char
      ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0)
      Dim asciiString As New String(asciiChars)

      ' Display the strings created before and after the conversion.
      Console.WriteLine("Original string: {0}", unicodeString)
      Console.WriteLine("Ascii converted string: {0}", asciiString)
   End Sub
End Class
' The example displays the following output:
'    Original string: This string contains the unicode character Pi (Π)
'    Ascii converted string: This string contains the unicode character Pi (?)
' </Snippet1>
