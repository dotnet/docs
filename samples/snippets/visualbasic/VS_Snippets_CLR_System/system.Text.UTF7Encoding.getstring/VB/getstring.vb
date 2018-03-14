' The following code example encodes a string into an array of bytes, and then decodes the bytes back into a string.

' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic

Public Class SamplesUTF7Encoding

   Public Shared Sub Main()

      ' Create an instance of UTF7Encoding.
      Dim u7 As New UTF7Encoding(True)

      ' Create byte arrays from the same string containing the following characters:
      '    Latin Small Letter Z (U+007A)
      '    Latin Small Letter A (U+0061)
      '    Combining Breve (U+0306)
      '    Latin Small Letter AE With Acute (U+01FD)
      '    Greek Small Letter Beta (U+03B2)
      Dim myStr As String = "za" & ChrW(&H0306) & ChrW(&H01FD) & ChrW(&H03B2)

      ' Encode the string.
      Dim myBArr(u7.GetByteCount(myStr)) As Byte
      u7.GetBytes(myStr, 0, myStr.Length, myBArr, 0)

      ' Decode the byte array.
      Console.WriteLine("The new string is: {0}", u7.GetString(myBArr, 0, myBArr.Length))

   End Sub 'Main 

End Class 'SamplesUTF7Encoding


'This code produces the following output.  The question marks take the place of characters that cannot be displayed at the console.
'
'The new string is: za??ß


' </Snippet1>