'<snippet1>
' This code example demonstrates the Encoder.Convert() and Decoder.Convert methods. 
' This example uses files for input and output, but any source that can be expressed
' as a stream can be used instead.

Imports System
Imports System.Text
Imports System.IO

Public Class Sample
    Shared Sub Main(ByVal args() As String) 
        ' Create a large file of UTF-16 encoded Unicode characters. The file is named Example.txt, 
        ' and is used as input to the Encoder.Convert() method. 
        CreateTestFile("Example.txt")
        
        
        ' Using an input file of UTF-16 encoded characters named Example.txt, create an output file 
        ' of UTF-8 encoded bytes named UTF8.txt.
        EncoderConvert("Example.txt", "UTF8.txt", Encoding.UTF8)
        
        ' Using an input file of UTF-8 encoded bytes named UTF8.txt, create an output file 
        ' of UTF-16 encoded characters named UTF16.txt.
        DecoderConvert("UTF8.txt", "UTF16.txt", Encoding.UTF8)
    
    End Sub 'Main
    
    ' --------------------------------------------------------------------------------------------
    ' Use the Encoder.Convert() method to convert a file of characters to a file of encoded bytes.
    ' --------------------------------------------------------------------------------------------
    Shared Sub EncoderConvert(ByVal inputFileName As String, ByVal outputFileName As String, ByVal enc As Encoding) 
        ' Convert an input file of characters to an output file of encoded bytes.
        ' StreamWriter could convert the input file for us, but we'll perform the conversion 
        ' ourselves.
        Dim fs As New FileStream(outputFileName, FileMode.Create)
        Dim outputFile As New BinaryWriter(fs)
        
        ' StreamReader will detect Unicode encoding from the Byte Order Mark that heads the input file.
        Dim inputFile As New StreamReader(inputFileName)
        
        ' Get an Encoder.
        Dim encoder As Encoder = enc.GetEncoder()
        
        ' Guarantee the output buffer large enough to convert a few characters.
        Dim UseBufferSize As Integer = 64
        If UseBufferSize < enc.GetMaxByteCount(10) Then
            UseBufferSize = enc.GetMaxByteCount(10)
        End If
        Dim bytes(UseBufferSize) As Byte
        
        ' Intentionally make the input character buffer larger than the output byte buffer so the 
        ' conversion loop executes more than one cycle. 
        Dim chars(UseBufferSize * 4) As Char
        Dim charsRead As Integer
        Do
            ' Read at most the number of characters that will fit in the input buffer. The return 
            ' value is the actual number of characters read, or zero if no characters remain. 
            charsRead = inputFile.Read(chars, 0, UseBufferSize * 4)
            
            Dim completed As Boolean = False
            Dim charIndex As Integer = 0
            Dim charsUsed As Integer
            Dim bytesUsed As Integer
            
            While Not completed
                ' If this is the last input data, flush the encoder's internal buffer and state.
                Dim flush As Boolean = charsRead = 0
                encoder.Convert(chars, charIndex, charsRead - charIndex, bytes, 0, UseBufferSize, flush, charsUsed, bytesUsed, completed)
                
                ' The conversion produced the number of bytes indicated by bytesUsed. Write that number
                ' of bytes to the output file.
                outputFile.Write(bytes, 0, bytesUsed)
                
                ' Increment charIndex to the next block of characters in the input buffer, if any, to convert.
                charIndex += charsUsed
            End While
        Loop While charsRead <> 0
        
        outputFile.Close()
        fs.Close()
        inputFile.Close()
    
    End Sub 'EncoderConvert
    
    ' --------------------------------------------------------------------------------------------
    ' Use the Decoder.Convert() method to convert a file of encoded bytes to a file of characters.
    ' --------------------------------------------------------------------------------------------
    Shared Sub DecoderConvert(ByVal inputFileName As String, ByVal outputFileName As String, ByVal enc As Encoding) 
        ' Convert an input file of of encoded bytes to an output file characters.
        ' StreamWriter could convert the input file for us, but we'll perform the conversion 
        ' ourselves.
        Dim outputFile As New StreamWriter(outputFileName, False, Encoding.Unicode)
        
        ' Read the input as a binary file so we can detect the Byte Order Mark.
        Dim fs As New FileStream(inputFileName, FileMode.Open)
        Dim inputFile As New BinaryReader(fs)
        
        ' Get a Decoder.
        Dim decoder As Decoder = enc.GetDecoder()
        
        ' Guarantee the output buffer large enough to convert a few characters.
        Dim UseBufferSize As Integer = 64
        If UseBufferSize < enc.GetMaxCharCount(10) Then
            UseBufferSize = enc.GetMaxCharCount(10)
        End If
        Dim chars(UseBufferSize) As Char
        
        ' Intentionally make the input byte buffer larger than the output character buffer so the 
        ' conversion loop executes more than one cycle. 
        Dim bytes(UseBufferSize * 4) As Byte
        Dim bytesRead As Integer
        Do
            ' Read at most the number of bytes that will fit in the input buffer. The 
            ' return value is the actual number of bytes read, or zero if no bytes remain. 
            bytesRead = inputFile.Read(bytes, 0, UseBufferSize * 4)
            
            Dim completed As Boolean = False
            Dim byteIndex As Integer = 0
            Dim bytesUsed As Integer
            Dim charsUsed As Integer
            
            While Not completed
                ' If this is the last input data, flush the decoder's internal buffer and state.
                Dim flush As Boolean = bytesRead = 0
                decoder.Convert(bytes, byteIndex, bytesRead - byteIndex, chars, 0, UseBufferSize, flush, bytesUsed, charsUsed, completed)
                
                ' The conversion produced the number of characters indicated by charsUsed. Write that number
                ' of characters to the output file.
                outputFile.Write(chars, 0, charsUsed)
                
                ' Increment byteIndex to the next block of bytes in the input buffer, if any, to convert.
                byteIndex += bytesUsed
            End While
        Loop While bytesRead <> 0
        
        outputFile.Close()
        fs.Close()
        inputFile.Close()
    
    End Sub 'DecoderConvert
    
    ' --------------------------------------------------------------------------------------------
    ' Create a large file of UTF-16 encoded Unicode characters. 
    ' --------------------------------------------------------------------------------------------
    Shared Sub CreateTestFile(ByVal FileName As String) 
        ' StreamWriter defaults to UTF-8 encoding so explicitly specify Unicode, that is, 
        ' UTF-16, encoding.
        Dim file As New StreamWriter(FileName, False, Encoding.Unicode)
        
        ' Write a line of text 100 times.
        Dim i As Integer
        For i = 0 To 99
            file.WriteLine("This is an example input file used by the convert example.")
        Next i
        
        ' Write Unicode characters from U+0000 to, but not including, the surrogate character range.
        Dim c As Integer
        For c = 0 To &HD800
            file.Write(ChrW(c))
        Next c
        file.Close()
    
    End Sub 'CreateTestFile
End Class 'Sample

'
'This code example produces the following results:
'
'(Execute the -dir- console window command and examine the files created.)
'
'Example.txt, which contains 122,594 bytes (61,297 UTF-16 encoded characters).
'UTF8.txt, which contains 169,712 UTF-8 encoded bytes.
'UTF16.txt, which contains 122,594 bytes (61,297 UTF-16 encoded characters).
'
'(Execute the -comp- console window command and compare the two Unicode files.)
'
'>comp example.txt utf16.txt /L
'Comparing example.txt and utf16.txt...
'Files compare OK
'
'(The two files are equal.)
'
'</snippet1>