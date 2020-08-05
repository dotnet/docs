'<snippet5>
Imports System.IO
Imports System.Text

Public Class BinReadWrite
    Public Shared Sub Main()
        Dim testfile As String = "C:\temp\testfile.bin"

        ' create a test file using BinaryWriter
        Dim fs As FileStream = File.Create(testfile)
        Dim utf8 As New UTF8Encoding()

        Dim bw As New BinaryWriter(fs, utf8)
        ' write a series of bytes to the file, each time incrementing
        ' the value from 0 - 127
        Dim pos As Integer

        For pos = 0 to 127
            bw.Write(CType(pos, Byte))
        Next pos

        ' reset the stream position for the next write pass
        bw.Seek(0, SeekOrigin.Begin)
        ' write marks in file with the value of 255 going forward
        For pos = 0 To 119 Step 8
            bw.Seek(7, SeekOrigin.Current)
            bw.Write(CType(255, Byte))
        Next pos

        ' reset the stream position for the next write pass
        bw.Seek(0, SeekOrigin.End)
        ' write marks in file with the value of 254 going backward
        For pos = 128 To 7 Step -6
            bw.Seek(-6, SeekOrigin.Current)
            bw.Write(CType(254, Byte))
            bw.Seek(-1, SeekOrigin.Current)
        Next pos

        ' now dump the contents of the file using the original file stream
        fs.Seek(0, SeekOrigin.Begin)
        Console.WriteLine("Length: {0:d}", fs.Length)
        Dim rawbytes(fs.Length - 1) As Byte
        fs.Read(rawbytes, 0, fs.Length)
        Console.WriteLine("Length: {0:d}", rawbytes.Length)

        Dim i As Integer = 0
        For Each b As Byte In rawbytes
            Select b
                Case 254
                    Console.Write("-%- ")

                Case 255
                    Console.Write("-*- ")

                Case Else
                    Console.Write("{0:d3} ", b)
            End Select
            i = i + 1
            If i = 16 Then
                Console.WriteLine()
                i = 0
            End If
        Next b
        fs.Close()
    End Sub
End Class

' The output from the program is this:
'
' 000 001 -%- 003 004 005 006 -*- -%- 009 010 011 012 013 -%- -*-
' 016 017 018 019 -%- 021 022 -*- 024 025 -%- 027 028 029 030 -*-
' -%- 033 034 035 036 037 -%- -*- 040 041 042 043 -%- 045 046 -*-
' 048 049 -%- 051 052 053 054 -*- -%- 057 058 059 060 061 -%- -*-
' 064 065 066 067 -%- 069 070 -*- 072 073 -%- 075 076 077 078 -*-
' -%- 081 082 083 084 085 -%- -*- 088 089 090 091 -%- 093 094 -*-
' 096 097 -%- 099 100 101 102 -*- -%- 105 106 107 108 109 -%- -*-
' 112 113 114 115 -%- 117 118 -*- 120 121 -%- 123 124 125 126 127
'</snippet5>
