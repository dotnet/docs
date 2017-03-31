'<snippet1>
' This example demonstrates the EncoderReplacementFallback class.
Imports System
Imports System.Text

Class Sample
    Public Shared Sub Main() 
        
        ' Create an encoding, which is equivalent to calling the 
        ' ASCIIEncoding class constructor. 
        ' The EncoderReplacementFallback parameter specifies that the 
        ' string, "(unknown)", replace characters that cannot be encoded. 
        ' A decoder replacement fallback is also specified, but in this 
        ' code example the decoding operation cannot fail.  

        Dim erf As New EncoderReplacementFallback("(unknown)")
        Dim drf As New DecoderReplacementFallback("(error)")
        Dim ae As Encoding = Encoding.GetEncoding("us-ascii", erf, drf)
        
        ' The input string consists of the Unicode characters LEFT POINTING 
        ' DOUBLE ANGLE QUOTATION MARK (U+00AB), 'X' (U+0058), and RIGHT POINTING 
        ' DOUBLE ANGLE QUOTATION MARK (U+00BB). 
        ' The encoding can only encode characters in the US-ASCII range of U+0000 
        ' through U+007F. Consequently, the characters bracketing the 'X' character
        ' are replaced with the fallback replacement string, "(unknown)".

        Dim inputString As String = "«X»"
        Dim decodedString As String
        Dim twoNewLines As String = vbCrLf & vbCrLf
        Dim ix As Integer = 0
        Dim numberOfEncodedBytes As Integer = ae.GetByteCount(inputString)
        ' Counteract the compiler adding an extra byte to the array.
        Dim encodedBytes(numberOfEncodedBytes - 1) As Byte
        
        ' --------------------------------------------------------------------------
        Console.Clear()
        
        ' Display the name of the encoding.
        Console.WriteLine("The name of the encoding is ""{0}""." & vbCrLf, ae.WebName)
        
        ' Display the input string in text.
        Console.WriteLine("Input string ({0} characters): ""{1}""", _
                           inputString.Length, inputString)
        
        ' Display the input string in hexadecimal. 
        ' Each element is converted to an integer with Convert.ToInt32.
        Console.Write("Input string in hexadecimal: ")
        Dim c As Char
        For Each c In inputString.ToCharArray()
            Console.Write("0x{0:X2} ", Convert.ToInt32(c))
        Next c
        Console.Write(twoNewLines)
        
        ' --------------------------------------------------------------------------
        ' Encode the input string. 
        Console.WriteLine("Encode the input string...")
        numberOfEncodedBytes = ae.GetBytes(inputString, 0, inputString.Length, _
                                           encodedBytes, 0)
        
        ' Display the encoded bytes. 
        ' Each element is converted to an integer with Convert.ToInt32.
        Console.WriteLine("Encoded bytes in hexadecimal ({0} bytes):" & vbCrLf, _
                           numberOfEncodedBytes)
        ix = 0
        Dim b As Byte
        For Each b In encodedBytes
            Console.Write("0x{0:X2} ", Convert.ToInt32(b))
            ix += 1
            If 0 = ix Mod 6 Then
                Console.WriteLine()
            End If
        Next b
        Console.Write(twoNewLines)
        
        ' --------------------------------------------------------------------------
        ' Decode the encoded bytes, yielding a reconstituted string.
        Console.WriteLine("Decode the encoded bytes...")
        decodedString = ae.GetString(encodedBytes)
        
        ' Display the input string and the decoded string for comparison.
        Console.WriteLine("Input string:  ""{0}""", inputString)
        Console.WriteLine("Decoded string:""{0}""", decodedString)
    
    End Sub 'Main
End Class 'Sample
'
'This code example produces the following results:
'
'The name of the encoding is "us-ascii".
'
'Input string (3 characters): "X"
'Input string in hexadecimal: 0xAB 0x58 0xBB
'
'Encode the input string...
'Encoded bytes in hexadecimal (19 bytes):
'
'0x28 0x75 0x6E 0x6B 0x6E 0x6F
'0x77 0x6E 0x29 0x58 0x28 0x75
'0x6E 0x6B 0x6E 0x6F 0x77 0x6E
'0x29
'
'Decode the encoded bytes...
'Input string:  "X"
'Decoded string:"(unknown)X(unknown)"
'
'</snippet1>