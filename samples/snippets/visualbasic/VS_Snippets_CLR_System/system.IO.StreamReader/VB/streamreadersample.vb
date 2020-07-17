'<snippet1>
Imports System.IO

Namespace StreamReaderSample
    Public Class StreamReaderSample
        Inherits TextReader
        '</snippet1> 
        Public Sub New()
            printInfo()
            usePeek()
            usePosition()
            useNull()
            useReadLine()
            useReadToEnd()
        End Sub

        'All Overloaded Constructors for StreamReader
        '<snippet2> 
        Private Sub getNewStreamReader()
            Dim S As Stream = File.OpenRead("C:\Temp\Test.txt")
            'Get a new StreamReader in ASCII format from a
            'file using a buffer and byte order mark detection
            Dim SrAsciiFromFileFalse512 As StreamReader = New StreamReader("C:\Temp\Test.txt", _
                System.Text.Encoding.ASCII, False, 512)
            'Get a new StreamReader in ASCII format from a
            'file with byte order mark detection = false
            Dim SrAsciiFromFileFalse As StreamReader = New StreamReader("C:\Temp\Test.txt", _
                System.Text.Encoding.ASCII, False)
            'Get a new StreamReader in ASCII format from a file 
            Dim SrAsciiFromFile As StreamReader = New StreamReader("C:\Temp\Test.txt", _
                System.Text.Encoding.ASCII)
            'Get a new StreamReader from a
            'file with byte order mark detection = false        
            Dim SrFromFileFalse As StreamReader = New StreamReader("C:\Temp\Test.txt", False)
            'Get a new StreamReader from a file
            Dim SrFromFile As StreamReader = New StreamReader("C:\Temp\Test.txt")
            'Get a new StreamReader in ASCII format from a
            'FileStream with byte order mark detection = false and a buffer
            Dim SrAsciiFromStreamFalse512 As StreamReader = New StreamReader(S, _
                System.Text.Encoding.ASCII, False, 512)
            'Get a new StreamReader in ASCII format from a
            'FileStream with byte order mark detection = false
            Dim SrAsciiFromStreamFalse = New StreamReader(S, _
                System.Text.Encoding.ASCII, False)
            'Get a new StreamReader in ASCII format from a FileStream
            Dim SrAsciiFromStream As StreamReader = New StreamReader(S, _
                System.Text.Encoding.ASCII)
            'Get a new StreamReader from a
            'FileStream with byte order mark detection = false
            Dim SrFromStreamFalse As StreamReader = New StreamReader(S, False)
            'Get a new StreamReader from a FileStream
            Dim SrFromStream As StreamReader = New StreamReader(S)

        End Sub
        '</snippet2>

        '<snippet3> 
        Private Sub printInfo()
            '</snippet3>
            '<snippet4>  
            Dim SEncoding As Stream
            SEncoding = File.OpenRead("C:\Temp\Test.txt")
            Dim SrEncoding As StreamReader = New StreamReader(SEncoding, _
                System.Text.Encoding.ASCII)
            Console.WriteLine("Encoding: {0}", _
                SrEncoding.CurrentEncoding.EncodingName)
            SrEncoding.Close()
            '</snippet4> 
        End Sub

        Private Sub usePeek()
            '<snippet5> 
            Dim SPeek As Stream
            SPeek = File.OpenRead("C:\Temp\Test.txt")
            Dim SrPeek As StreamReader = New StreamReader(SPeek, _
                System.Text.Encoding.ASCII)
            ' set the file pointer to the beginning
            SrPeek.BaseStream.Seek(0, SeekOrigin.Begin)
            ' cycle while there is a next char
            While (SrPeek.Peek() > -1)
                Console.Write(SrPeek.ReadLine())
            End While
            ' close the reader and the file
            SrPeek.Close()
            '</snippet5>
        End Sub

        Private Sub usePosition()
            '<snippet6> 
            Dim SRead As Stream
            SRead = File.OpenRead("C:\Temp\Test.txt")
            Dim SrRead As StreamReader = New StreamReader(SRead, _
                System.Text.Encoding.ASCII)
            ' set the file pointer to the beginning
            SrRead.BaseStream.Seek(0, SeekOrigin.Begin)
            SrRead.BaseStream.Position = 0
            While (SrRead.BaseStream.Position < SrRead.BaseStream.Length)
                Dim buffer(1) As Char
                SrRead.Read(buffer, 0, 1)
                Console.Write(buffer(0).ToString())
                SrRead.BaseStream.Position = SrRead.BaseStream.Position + 1
            End While
            SrRead.DiscardBufferedData()
            SrRead.Close()
            '</snippet6>
        End Sub

        Private Sub useNull()
            '<snippet7> 
            Dim SNull As Stream
            SNull = File.OpenRead("C:\Temp\Test.txt")
            Dim SrNull As StreamReader = New StreamReader(SNull, _
                System.Text.Encoding.ASCII)
            If (SrNull.Equals(StreamReader.Null) <> True) Then
                SrNull.BaseStream.Seek(0, SeekOrigin.Begin)
                Console.WriteLine(SrNull.ReadToEnd())
            End If
            SrNull.Close()
            '</snippet7>
        End Sub
        Private Sub useReadLine()
            '<snippet8> 
            Dim SReadLine As Stream
            SReadLine = File.OpenRead("C:\Temp\Test.txt")
            Dim SrReadLine As StreamReader = New StreamReader(SReadLine, _
                System.Text.Encoding.ASCII)
            SrReadLine.BaseStream.Seek(0, SeekOrigin.Begin)
            While (SrReadLine.Peek() > -1)
                Console.Write(SrReadLine.ReadLine())
            End While
            SrReadLine.Close()
            '</snippet8>	
        End Sub
        Private Sub useReadToEnd()
            '<snippet9> 
            Dim SReadToEnd As Stream
            SReadToEnd = File.OpenRead("C:\Temp\Test.txt")
            Dim SrReadToEnd As StreamReader = New StreamReader(SReadToEnd, _
                System.Text.Encoding.ASCII)
            SrReadToEnd.BaseStream.Seek(0, SeekOrigin.Begin)
            Console.WriteLine(SrReadToEnd.ReadToEnd())
            SrReadToEnd.Close()
            '</snippet9>
            '<snippet10> 
        End Sub
        '</snippet10>
        '<snippet11> 
    End Class
End Namespace
'</snippet11>
Class EntryPoint
    Shared Sub Main()
        Dim A As New StreamReaderSample.StreamReaderSample()
    End Sub
End Class
