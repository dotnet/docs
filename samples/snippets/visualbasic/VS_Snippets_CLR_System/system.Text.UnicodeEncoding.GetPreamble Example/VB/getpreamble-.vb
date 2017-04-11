' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic

Class UnicodeEncodingExample
    
    Public Shared Sub Main()
        Dim byteOrderMark() As Byte
        Dim b As Byte
        
        byteOrderMark = Encoding.Unicode.GetPreamble()
        Console.WriteLine("Default (little-endian) Unicode Preamble:")
        For Each b In  byteOrderMark
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine(ControlChars.NewLine)
        
        Dim bigEndianUnicode As New UnicodeEncoding(True, True)
        byteOrderMark = bigEndianUnicode.GetPreamble()
        Console.WriteLine("Big-endian Unicode Preamble:")
        For Each b In  byteOrderMark
            Console.Write("[{0}]", b)
        Next b
    End Sub 'Main
End Class 'UnicodeEncodingExample
' </Snippet1>
