'<snippet1>
' This example demonstrates the DecoderReplacementFallback class.
Imports System
Imports System.Text

Class Sample
    Public Shared Sub Main() 
        
        ' Create an encoding, which is equivalent to calling the 
        ' ASCIIEncoding class constructor. 
        ' The DecoderReplacementFallback parameter specifies that the 
        ' string "(error)" is to replace characters that cannot be decoded. 
        ' An encoder replacement fallback is also specified, but in this code
        ' example the encoding operation cannot fail.  

        Dim erf As New EncoderReplacementFallback("(unknown)")
        Dim drf As New DecoderReplacementFallback("(error)")
        Dim ae As Encoding = Encoding.GetEncoding("us-ascii", erf, drf)
        Dim inputString As String = "XYZ"
        Dim decodedString As String
        Dim twoNewLines As String = vbCrLf & vbCrLf
        Dim numberOfEncodedBytes As Integer = ae.GetByteCount(inputString)
        ' Counteract the compiler implicitly adding an extra element.
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
        For Each c In  inputString.ToCharArray()
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
        Dim b As Byte
        For Each b In  encodedBytes
            Console.Write("0x{0:X2} ", Convert.ToInt32(b))
        Next b
        Console.Write(twoNewLines)
        
        ' --------------------------------------------------------------------------
        ' Replace the encoded byte sequences for the characters 'X' and 'Z' with the 
        ' value 0xFF, which is outside the valid range of 0x00 to 0x7F for 
        ' ASCIIEncoding. The resulting byte sequence is actually the beginning of 
        ' this code example because it is the input to the decoder operation, and 
        ' is equivalent to a corrupted or improperly encoded byte sequence. 

        encodedBytes(0) = &HFF
        encodedBytes(2) = &HFF
        
        Console.WriteLine("Display the corrupted byte sequence...")
        Console.WriteLine("Encoded bytes in hexadecimal ({0} bytes):" & vbCrLf, _
                           numberOfEncodedBytes)
        For Each b In  encodedBytes
            Console.Write("0x{0:X2} ", Convert.ToInt32(b))
        Next b
        Console.Write(twoNewLines)
        
        ' --------------------------------------------------------------------------
        ' Decode the encoded bytes.
        Console.WriteLine("Compare the decoded bytes to the input string...")
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
'Input string (3 characters): "XYZ"
'Input string in hexadecimal: 0x58 0x59 0x5A
'
'Encode the input string...
'Encoded bytes in hexadecimal (3 bytes):
'
'0x58 0x59 0x5A
'
'Display the corrupted byte sequence...
'Encoded bytes in hexadecimal (3 bytes):
'
'0xFF 0x59 0xFF
'
'Compare the decoded bytes to the input string...
'Input string:  "XYZ"
'Decoded string:"(error)Y(error)"
'
'</snippet1>