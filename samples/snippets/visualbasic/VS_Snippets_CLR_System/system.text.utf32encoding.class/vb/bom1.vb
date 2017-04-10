' <Snippet2>
Imports System.IO
Imports System.Text

Class Example
    Public Shared Sub Main()
        ' Create a UTF-32 encoding that supports a BOM.
        Dim enc As New UTF32Encoding()
        
        ' A Unicode string with two characters outside an 8-bit code range.
        Dim s As String = _
            "This Unicode string has 2 characters outside the " &
            "ASCII range: " & vbCrLf &
            "Pi (" & ChrW(&h03A0) & "), and Sigma (" & ChrW(&h03A3) & ")."
        Console.WriteLine("Original string:")
        Console.WriteLine(s)
        Console.WriteLine()
        
        ' Encode the string.
        Dim encodedBytes As Byte() = enc.GetBytes(s)
        Console.WriteLine("The encoded string has {0} bytes.",
                          encodedBytes.Length)
        Console.WriteLine()
        
        ' Write the bytes to a file with a BOM.
        Dim fs As New FileStream(".\UTF32Encoding.txt", FileMode.Create)
        Dim bom() As Byte = enc.GetPreamble()
        fs.Write(bom, 0, bom.Length)
        fs.Write(encodedBytes, 0, encodedBytes.Length)
        Console.WriteLine("Wrote {0} bytes to the file.", fs.Length)
        fs.Close()
        Console.WriteLine()
        
        ' Open the file using StreamReader.
        Dim sr As New StreamReader(".\UTF32Encoding.txt")
        Dim newString As String = sr.ReadToEnd()
        sr.Close()
        Console.WriteLine("String read using StreamReader:")
        Console.WriteLine(newString)
        Console.WriteLine()
        
        ' Open the file as a binary file and decode the bytes back to a string.
        fs = new FileStream(".\Utf32Encoding.txt", FileMode.Open)
        Dim bytes(fs.Length - 1) As Byte
        fs.Read(bytes, 0, fs.Length)
        fs.Close()

        Dim decodedString As String = enc.GetString(encodedBytes)
        Console.WriteLine("Decoded bytes from binary file:")
        Console.WriteLine(decodedString)
    End Sub
End Class
' The example displays the following output:
'    Original string:
'    This Unicode string has 2 characters outside the ASCII range:
'    Pi (π), and Sigma (Σ).
'
'    The encoded string has 344 bytes.
'
'    Wrote 348 bytes to the file.
'
'    String read using StreamReader:
'    This Unicode string has 2 characters outside the ASCII range:
'    Pi (π), and Sigma (Σ).
'
'    Decoded bytes from binary file:
'    This Unicode string has 2 characters outside the ASCII range:
'    Pi (π), and Sigma (Σ).
' </Snippet2>
