' The following code example determines the number of bytes required to encode a character array,
' encodes the characters, and displays the resulting bytes.

' <Snippet2>
Imports System.Text

Public Module Example
   Public Sub Main()
      ' Create a character array.
      Dim gkNumber As String = Char.ConvertFromUtf32(&h10154)
      Dim chars() As Char = {"z"c, "a"c, ChrW(&H0306), ChrW(&H01FD), 
                             ChrW(&H03B2), gkNumber(0), gkNumber(1) }
 
      ' Get UTF-8 and UTF-16 encoders.
      Dim utf8 As Encoding = Encoding.UTF8
      Dim utf16 As Encoding = Encoding.Unicode

      ' Display the original characters' code units.
      Console.WriteLine("Original UTF-16 code units:")
      Dim utf16Bytes() As Byte = utf16.GetBytes(chars)
      For Each utf16Byte In utf16Bytes
         Console.Write("{0:X2} ", utf16Byte)
      Next
      Console.WriteLine()

      Console.WriteLine()
      ' Display the number of bytes required to encode the array.
      Dim reqBytes As Integer = utf8.GetByteCount(chars)
      Console.WriteLine("Exact number of bytes required: {0}", 
                        reqBytes)

      ' Display the maximum byte count.
      Dim maxBytes As Integer = utf8.GetMaxByteCount(chars.Length)
      Console.WriteLine("Maximum number of bytes required: {0}", 
                        maxBytes)
      Console.WriteLine()
      
      ' Encode the array of characters.
      Dim utf8Bytes() As Byte = utf8.GetBytes(chars)

      ' Display all the UTF-8-encoded bytes.
      Console.WriteLine("UTF-8-encoded code units:")
      For Each utf8Byte In utf8Bytes
         Console.Write("{0:X2} ", utf8Byte)
      Next
      Console.WriteLine()
   End Sub 
End Module 
' The example displays the following output:
'    Original UTF-16 code units:
'    7A 00 61 00 06 03 FD 01 B2 03 00 D8 54 DD
'    
'    Exact number of bytes required: 12
'    Maximum number of bytes required: 24
'    
'    UTF-8-encoded code units:
'    7A 61 CC 86 C7 BD CE B2 F0 90 85 94
' </Snippet2>
