'<snippet4>
Imports System.IO
Imports System.Text

Public Class BinReadWrite
    Public Shared Sub Main()
        Dim testfile As String = "C:\testfile.bin"

        ' create a test file using BinaryWriter
        Dim fs As FileStream = File.Create(testfile)
        Dim utf8 As New UTF8Encoding()

        Dim bw As New BinaryWriter(fs, utf8)
        Dim bstring As String

        bstring = "This is line #1 of text written as a binary stream." + vbNewLine
        bstring = bstring + "This is line #2 of text written as a binary stream." + vbNewLine
        bstring = bstring + "This is line #3 of text written as a binary stream." + vbNewLine
        bw.Write(bstring)

        ' reset the stream position for reading
        fs.Seek(0, SeekOrigin.Begin)

        ' Read the string as raw bytes using FileStream...
        ' The first series of bytes is the UTF7 encoded length of the
        ' string. In this case, however, it is just the first two bytes.
        Dim len As Integer = fs.ReadByte() And 127
        len = len + fs.ReadByte() * 128
        ' read the string as bytes of length = len
        Dim rawbytes(len) As Byte
        fs.Read(rawbytes, 0, len)

        ' display the string
        Console.WriteLine("Read from FileStream:   " + vbNewLine + utf8.GetString(rawbytes))
        Console.WriteLine()

        ' Now, read the string using BinaryReader

        ' reset the stream position for reading again
        fs.Seek(0, SeekOrigin.Begin)

        Dim br As New BinaryReader(fs, utf8)
        ' ReadString will read the length prefix and return the string.
        bstring = br.ReadString()
        Console.WriteLine("Read from BinaryReader: " + vbNewLine + bstring)
        fs.Close()
    End Sub
End Class

' The output from the program is this:
'
' Read from FileStream:
' This is line #1 of text written as a binary stream.
' This is line #2 of text written as a binary stream.
' This is line #3 of text written as a binary stream.
'
' Read from BinaryReader:
' This is line #1 of text written as a binary stream.
' This is line #2 of text written as a binary stream.
' This is line #3 of text written as a binary stream.
'</snippet4>
