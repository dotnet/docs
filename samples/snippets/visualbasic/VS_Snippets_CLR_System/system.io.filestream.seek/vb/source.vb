' <Snippet1>
Imports System
Imports System.IO

Public Class FSSeek
    Public Shared Sub Main()
        Dim offset As Long
        Dim nextByte As Integer

        ' alphabet.txt contains "abcdefghijklmnopqrstuvwxyz"
        Using fs As New FileStream("c:\temp\alphabet.txt", FileMode.Open, FileAccess.Read)

            For offset = 1 To fs.Length
                fs.Seek(-offset, SeekOrigin.End)
                Console.Write(Convert.ToChar(fs.ReadByte()))
            Next offset
            Console.WriteLine()

            fs.Seek(20, SeekOrigin.Begin)

            nextByte = fs.ReadByte()
            While (nextByte > 0)
                Console.Write(Convert.ToChar(nextByte))
                nextByte = fs.ReadByte()
            End While
            Console.WriteLine()

        End Using
    End Sub
End Class

' This code example displays the following output:
'
' zyxwvutsrqponmlkjihgfedcba
' uvwxyz
' </Snippet1>